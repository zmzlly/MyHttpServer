
namespace WinFormHttpServer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.TextBox_S_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RtBox_S_Msg = new System.Windows.Forms.RichTextBox();
            this.TextBox_S_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.Btn_Stop);
            this.groupBox1.Controls.Add(this.Btn_Start);
            this.groupBox1.Controls.Add(this.TextBox_S_IP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RtBox_S_Msg);
            this.groupBox1.Controls.Add(this.TextBox_S_Port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 474);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HttpServer";
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Enabled = false;
            this.Btn_Stop.Location = new System.Drawing.Point(493, 35);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(75, 28);
            this.Btn_Stop.TabIndex = 2;
            this.Btn_Stop.Text = "停止服务";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(346, 35);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 28);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "启动服务";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // TextBox_S_IP
            // 
            this.TextBox_S_IP.Location = new System.Drawing.Point(77, 35);
            this.TextBox_S_IP.Name = "TextBox_S_IP";
            this.TextBox_S_IP.Size = new System.Drawing.Size(78, 26);
            this.TextBox_S_IP.TabIndex = 6;
            this.TextBox_S_IP.Text = "127.0.0.1";
            this.TextBox_S_IP.Enter += new System.EventHandler(this.TextBox_S_IP_Enter);
            this.TextBox_S_IP.Leave += new System.EventHandler(this.TextBox_S_IP_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "服务地址：";
            // 
            // RtBox_S_Msg
            // 
            this.RtBox_S_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RtBox_S_Msg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RtBox_S_Msg.Location = new System.Drawing.Point(8, 75);
            this.RtBox_S_Msg.Name = "RtBox_S_Msg";
            this.RtBox_S_Msg.ReadOnly = true;
            this.RtBox_S_Msg.Size = new System.Drawing.Size(673, 393);
            this.RtBox_S_Msg.TabIndex = 4;
            this.RtBox_S_Msg.Text = "";
            // 
            // TextBox_S_Port
            // 
            this.TextBox_S_Port.Location = new System.Drawing.Point(219, 35);
            this.TextBox_S_Port.Name = "TextBox_S_Port";
            this.TextBox_S_Port.Size = new System.Drawing.Size(51, 26);
            this.TextBox_S_Port.TabIndex = 300;
            this.TextBox_S_Port.Text = "6666";
            this.TextBox_S_Port.Enter += new System.EventHandler(this.TextBox_S_Port_Enter);
            this.TextBox_S_Port.Leave += new System.EventHandler(this.TextBox_S_Port_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口号：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 499);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "WinForm实现HttpServer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextBox_S_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RtBox_S_Msg;
        private System.Windows.Forms.TextBox TextBox_S_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.Button Btn_Start;
    }
}

