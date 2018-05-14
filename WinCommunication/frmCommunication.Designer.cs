namespace WinCommunication
{
    partial class frmCommunication
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bntSend = new System.Windows.Forms.Button();
            this.rtbMsgList = new System.Windows.Forms.RichTextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtProcessIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBin = new System.Windows.Forms.Button();
            this.txtk1 = new System.Windows.Forms.TextBox();
            this.txtk2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bntSend
            // 
            this.bntSend.Font = new System.Drawing.Font("宋体", 13F);
            this.bntSend.Location = new System.Drawing.Point(294, 309);
            this.bntSend.Name = "bntSend";
            this.bntSend.Size = new System.Drawing.Size(89, 27);
            this.bntSend.TabIndex = 8;
            this.bntSend.Text = "发送";
            this.bntSend.UseVisualStyleBackColor = true;
            this.bntSend.Click += new System.EventHandler(this.bntSend_Click);
            // 
            // rtbMsgList
            // 
            this.rtbMsgList.Location = new System.Drawing.Point(1, 31);
            this.rtbMsgList.Name = "rtbMsgList";
            this.rtbMsgList.Size = new System.Drawing.Size(394, 182);
            this.rtbMsgList.TabIndex = 7;
            this.rtbMsgList.Text = "";
            // 
            // txtMsg
            // 
            this.txtMsg.AllowDrop = true;
            this.txtMsg.Location = new System.Drawing.Point(1, 239);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(394, 61);
            this.txtMsg.TabIndex = 6;
            this.txtMsg.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMsg_DragDrop);
            this.txtMsg.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtMsg_DragEnter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 342);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(394, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // txtProcessIP
            // 
            this.txtProcessIP.Location = new System.Drawing.Point(57, 216);
            this.txtProcessIP.Name = "txtProcessIP";
            this.txtProcessIP.Size = new System.Drawing.Size(104, 21);
            this.txtProcessIP.TabIndex = 12;
            this.txtProcessIP.Text = "192.168.43.121";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "远程IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 13;
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Location = new System.Drawing.Point(57, 4);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.Size = new System.Drawing.Size(104, 21);
            this.txtLocalIP.TabIndex = 12;
            this.txtLocalIP.Text = "192.168.43.196";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "本地IP:";
            // 
            // btnBin
            // 
            this.btnBin.Font = new System.Drawing.Font("宋体", 13F);
            this.btnBin.Location = new System.Drawing.Point(284, 2);
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(89, 27);
            this.btnBin.TabIndex = 8;
            this.btnBin.Text = "绑定";
            this.btnBin.UseVisualStyleBackColor = true;
            this.btnBin.Click += new System.EventHandler(this.btnBin_Click);
            // 
            // txtk1
            // 
            this.txtk1.Location = new System.Drawing.Point(167, 4);
            this.txtk1.Name = "txtk1";
            this.txtk1.Size = new System.Drawing.Size(104, 21);
            this.txtk1.TabIndex = 12;
            this.txtk1.Text = "8001";
            // 
            // txtk2
            // 
            this.txtk2.Location = new System.Drawing.Point(167, 216);
            this.txtk2.Name = "txtk2";
            this.txtk2.Size = new System.Drawing.Size(104, 21);
            this.txtk2.TabIndex = 12;
            this.txtk2.Text = "8002";
            // 
            // frmCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 366);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtk2);
            this.Controls.Add(this.txtk1);
            this.Controls.Add(this.txtLocalIP);
            this.Controls.Add(this.txtProcessIP);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnBin);
            this.Controls.Add(this.bntSend);
            this.Controls.Add(this.rtbMsgList);
            this.Controls.Add(this.txtMsg);
            this.Name = "frmCommunication";
            this.Text = "通讯";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntSend;
        private System.Windows.Forms.RichTextBox rtbMsgList;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtProcessIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBin;
        private System.Windows.Forms.TextBox txtk1;
        private System.Windows.Forms.TextBox txtk2;

    }
}

