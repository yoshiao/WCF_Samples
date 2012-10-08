using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            TestProxy.DataServiceClient client = new TestProxy.DataServiceClient();

            string data = client.GetData();

            MessageBox.Show(data);
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            TestProxy.DataServiceClient client = new TestProxy.DataServiceClient();
            client.GetDataCompleted += delegate(object src, TestProxy.GetDataCompletedEventArgs args)
            {
                MessageBox.Show(args.Result);
            };

            client.GetDataAsync();
        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(
                delegate()
                {
                    TestProxy.DataServiceClient client = new TestProxy.DataServiceClient();

                    string data = client.GetData();

                    MessageBox.Show(data);
                }
            );

            th.Start();
        }
    }
}
