using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace CustomLib
{
    public class CustomEncoder : MessageEncoder
    {
        BindingElement bindingElement;
        MessageEncoder innerEncoder;

        public CustomEncoder(BindingElement bindingElement, MessageEncoder innerEncoder)
        {
            this.bindingElement = bindingElement;
            this.innerEncoder = innerEncoder;
        }

        public override string ContentType
        {
            get { return this.innerEncoder.ContentType; }
        }

        public override string MediaType
        {
            get { 
                return this.innerEncoder.MediaType;    
            }
        }

        public override MessageVersion MessageVersion
        {
            get { return this.innerEncoder.MessageVersion; }
        }

       

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            byte[] msgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            MemoryStream stream = new MemoryStream(msgContents);

            XmlReader reader = XmlReader.Create(stream);
            XElement elm = XElement.Load(reader);
            reader.Close();

            var msgElm = elm.Descendants().First();
            XmlReader msgReader = msgElm.CreateReader();
      
            return Message.CreateMessage(msgReader, int.MaxValue, this.MessageVersion);
        }

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            return this.innerEncoder.ReadMessage(stream, maxSizeOfHeaders, contentType);
        }


        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings());
            writer.WriteStartElement("CustomEnvelope", "");
            message.WriteMessage(writer);
            writer.WriteEndElement();
            writer.Close();

            byte[] messageBytes = stream.GetBuffer();
            int messageLength = (int)stream.Position;
            stream.Close();

            int totalLength = messageLength + messageOffset;
            byte[] totalBytes = bufferManager.TakeBuffer(totalLength);
            Array.Copy(messageBytes, 0, totalBytes, messageOffset, messageLength);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);
            return byteArray;
        }

        public override void WriteMessage(Message message, Stream stream)
        {
            innerEncoder.WriteMessage(message, stream);
        }

    }
     
}
