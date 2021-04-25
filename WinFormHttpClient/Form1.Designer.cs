
namespace WinFormHttpClient
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_FileDownload = new System.Windows.Forms.Button();
            this.TextBox_FileDownload = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_FileUpload = new System.Windows.Forms.Button();
            this.TextBox_FileUpload = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_SendGET = new System.Windows.Forms.Button();
            this.Btn_SendPOST = new System.Windows.Forms.Button();
            this.RtBox_C_Msg = new System.Windows.Forms.RichTextBox();
            this.TextBox_Q_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Btn_FileDownload);
            this.groupBox2.Controls.Add(this.TextBox_FileDownload);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Btn_FileUpload);
            this.groupBox2.Controls.Add(this.TextBox_FileUpload);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Btn_SendGET);
            this.groupBox2.Controls.Add(this.Btn_SendPOST);
            this.groupBox2.Controls.Add(this.RtBox_C_Msg);
            this.groupBox2.Controls.Add(this.TextBox_Q_IP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(19, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 416);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HttpClient";
            // 
            // Btn_FileDownload
            // 
            this.Btn_FileDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_FileDownload.Location = new System.Drawing.Point(601, 119);
            this.Btn_FileDownload.Name = "Btn_FileDownload";
            this.Btn_FileDownload.Size = new System.Drawing.Size(99, 27);
            this.Btn_FileDownload.TabIndex = 308;
            this.Btn_FileDownload.Text = "文件下载";
            this.Btn_FileDownload.UseVisualStyleBackColor = true;
            this.Btn_FileDownload.Click += new System.EventHandler(this.Btn_FileDownload_Click);
            // 
            // TextBox_FileDownload
            // 
            this.TextBox_FileDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_FileDownload.Location = new System.Drawing.Point(79, 121);
            this.TextBox_FileDownload.Name = "TextBox_FileDownload";
            this.TextBox_FileDownload.Size = new System.Drawing.Size(440, 26);
            this.TextBox_FileDownload.TabIndex = 307;
            this.TextBox_FileDownload.Text = "http://localhost:6666/FileUpload?FileName=sm.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 306;
            this.label2.Text = "请求地址：";
            // 
            // Btn_FileUpload
            // 
            this.Btn_FileUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_FileUpload.Location = new System.Drawing.Point(599, 77);
            this.Btn_FileUpload.Name = "Btn_FileUpload";
            this.Btn_FileUpload.Size = new System.Drawing.Size(99, 27);
            this.Btn_FileUpload.TabIndex = 305;
            this.Btn_FileUpload.Text = "文件上传";
            this.Btn_FileUpload.UseVisualStyleBackColor = true;
            this.Btn_FileUpload.Click += new System.EventHandler(this.Btn_FileUpload_Click);
            // 
            // TextBox_FileUpload
            // 
            this.TextBox_FileUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_FileUpload.Location = new System.Drawing.Point(77, 79);
            this.TextBox_FileUpload.Name = "TextBox_FileUpload";
            this.TextBox_FileUpload.Size = new System.Drawing.Size(440, 26);
            this.TextBox_FileUpload.TabIndex = 304;
            this.TextBox_FileUpload.Text = "http://localhost:6666/FileUpload?FileName=IMG.jpg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 303;
            this.label1.Text = "请求地址：";
            // 
            // Btn_SendGET
            // 
            this.Btn_SendGET.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SendGET.Location = new System.Drawing.Point(647, 34);
            this.Btn_SendGET.Name = "Btn_SendGET";
            this.Btn_SendGET.Size = new System.Drawing.Size(110, 27);
            this.Btn_SendGET.TabIndex = 302;
            this.Btn_SendGET.Text = "发送GET请求";
            this.Btn_SendGET.UseVisualStyleBackColor = true;
            this.Btn_SendGET.Click += new System.EventHandler(this.Btn_SendGET_Click);
            // 
            // Btn_SendPOST
            // 
            this.Btn_SendPOST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SendPOST.Location = new System.Drawing.Point(527, 34);
            this.Btn_SendPOST.Name = "Btn_SendPOST";
            this.Btn_SendPOST.Size = new System.Drawing.Size(113, 27);
            this.Btn_SendPOST.TabIndex = 301;
            this.Btn_SendPOST.Text = "发送POST请求";
            this.Btn_SendPOST.UseVisualStyleBackColor = true;
            this.Btn_SendPOST.Click += new System.EventHandler(this.Btn_SendPOST_Click);
            // 
            // RtBox_C_Msg
            // 
            this.RtBox_C_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtBox_C_Msg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RtBox_C_Msg.Location = new System.Drawing.Point(11, 166);
            this.RtBox_C_Msg.Name = "RtBox_C_Msg";
            this.RtBox_C_Msg.ReadOnly = true;
            this.RtBox_C_Msg.Size = new System.Drawing.Size(748, 232);
            this.RtBox_C_Msg.TabIndex = 15;
            this.RtBox_C_Msg.Text = "";
            // 
            // TextBox_Q_IP
            // 
            this.TextBox_Q_IP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Q_IP.Location = new System.Drawing.Point(77, 35);
            this.TextBox_Q_IP.Name = "TextBox_Q_IP";
            this.TextBox_Q_IP.Size = new System.Drawing.Size(440, 26);
            this.TextBox_Q_IP.TabIndex = 12;
            this.TextBox_Q_IP.Text = "http://localhost:6666/LoginTest?Name=郑勉忠&Age=62";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "请求地址：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_SendPOST;
        private System.Windows.Forms.RichTextBox RtBox_C_Msg;
        private System.Windows.Forms.TextBox TextBox_Q_IP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_FileDownload;
        private System.Windows.Forms.TextBox TextBox_FileDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_FileUpload;
        private System.Windows.Forms.TextBox TextBox_FileUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_SendGET;
    }
}

