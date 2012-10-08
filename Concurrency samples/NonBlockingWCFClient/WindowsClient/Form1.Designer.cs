namespace WindowsClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(54, 37);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(257, 23);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Call service normally";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(54, 87);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(257, 23);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Call service with Async pattern";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(54, 139);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(257, 23);
            this.btnThread.TabIndex = 2;
            this.btnThread.Text = "Call service with background thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 263);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnThread;
    }
}

