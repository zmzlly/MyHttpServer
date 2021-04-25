using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HttpServer.HttpRequest;

namespace WinFormHttpClient
{
    public partial class Form1 : Form
    {

        public class user
        {
            public string Name { get; set; } = "郑勉忠";
            public string password { get; set; } = "zmz098765lly";
            public string account { get; set; } = "zmzlly;";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Btn_SendPOST_Click(object sender, EventArgs e)
        {

            string buf = "";
            RtBox_C_Msg.Clear();
            //POST JSON
            //string str = JsonConvert.SerializeObject(new user());
            //string url = TextBox_Q_IP.Text;
            //buf = PostAsyncJson(url, str).Result;
            //try
            //{
            //    buf = PostAsyncJson(url, str).Result;
            //}
            //catch (Exception ex)
            //{
            //    buf = $"请求的URL错误，或Http服务器没有响应！{ex.Message}";
            //}

            //POST TEXT  header
            string data = JsonConvert.SerializeObject(new user()); //"我发送的是字符串";
            string url = TextBox_Q_IP.Text;
            Dictionary<string, string[]> header = new Dictionary<string, string[]>();
            header.Add("H1", new string[] { "aaa", "111" });
            header.Add("H2", new string[] { "bbb", "222" });
            header.Add("H3", new string[] { "ccc", "333", "ppp" });
            try
            {
                buf = PostAsync(url, data, header, "kjshdkjsahdkjsahdqeuqoiueoiwquepoiwq").Result;
            }
            catch (Exception ex)
            {
                buf = $"请求的URL错误，或Http服务器没有响应！{ex.Message}";
            }

            RtBox_C_Msg.ScrollToCaret();
            RtBox_C_Msg.AppendText($"{buf.Replace("</br>", "\r\n")}\r\n");
        }

        private void Btn_SendGET_Click(object sender, EventArgs e)
        {
            string buf = "";
            RtBox_C_Msg.Clear();
            //GET TEXT  header
            string url = TextBox_Q_IP.Text;
            Dictionary<string, string[]> header = new Dictionary<string, string[]>();
            header.Add("H1", new string[] { "aaa", "111" });
            header.Add("H2", new string[] { "bbb", "222" });
            header.Add("H3", new string[] { "ccc", "333", "ppp" });
            try
            {
                buf = GetAsync(url, header).Result;
            }
            catch (Exception ex)
            {
                buf = $"请求的URL错误，或Http服务器没有响应！{ex.Message}";
            }
            RtBox_C_Msg.ScrollToCaret();
            RtBox_C_Msg.AppendText($"{buf.Replace("</br>", "\r\n")}\r\n");
        }

        private void Btn_FileUpload_Click(object sender, EventArgs e)
        {
            string buf = "";
            RtBox_C_Msg.Clear();
            string url = TextBox_FileUpload.Text;
            string fileName = TextBox_FileUpload.Text.Split('=')[1];
            FileStream inStream = new FileStream($"待上传文件\\{fileName}", FileMode.Open, FileAccess.Read);
            long nBytesToRead = inStream.Length;
            byte[] buffer = new byte[nBytesToRead];
            int m = inStream.Read(buffer, 0, buffer.Length);
            inStream.Close();
            try
            {
                buf = PostFileUpload(url, buffer);
                
            }
            catch (Exception ex)
            {
                buf = $"请求的URL错误，或Http服务器没有响应！{ex.Message}";
            }
            RtBox_C_Msg.ScrollToCaret();
            RtBox_C_Msg.AppendText($"{buf.Replace("</br>", "\r\n")}\r\n");
        }

        private void Btn_FileDownload_Click(object sender, EventArgs e)
        {
            string buf = "";
            RtBox_C_Msg.Clear();
            string url = TextBox_FileDownload.Text;
            string fileName = TextBox_FileDownload.Text.Split('=')[1];
        }
    }
}
