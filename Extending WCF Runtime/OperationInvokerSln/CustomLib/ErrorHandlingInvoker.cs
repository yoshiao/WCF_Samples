using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Diagnostics;
using System.Diagnostics;

namespace CustomLib
{
    public class ErrorHandlingInvoker : IOperationInvoker
    {
        private IOperationInvoker _baseInvoker = null;

        public ErrorHandlingInvoker(IOperationInvoker baseInvoker)
        {
            // Store the original default invoker
            _baseInvoker = baseInvoker;
        }


        #region IOperationInvoker Members

        public object[] AllocateInputs()
        {
            return _baseInvoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            try
            {
                return _baseInvoker.Invoke(instance, inputs, out outputs);
            }
            catch (Exception ex)
            {
                // Log the exception 
                EventLog.WriteEntry(
                    "WCF ErrorHandling Invoker", 
                    ex.ToString(),
                    EventLogEntryType.Error);

                outputs = new object[0];
                return string.Empty;
            }
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new NotImplementedException("Async Invoking is not supported.");
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new NotImplementedException("Async Invoking is not supported.");
        }

        public bool IsSynchronous
        {
            get { return true; }
        }

        #endregion
    }
}
