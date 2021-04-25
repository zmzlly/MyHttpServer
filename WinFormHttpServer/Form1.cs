using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HttpServer;
using static WinFormHttpServer.StaticMethAndVar;

namespace WinFormHttpServer
{
   
    public partial class Form1 : Form
    {
        public class user
        {
            public string Name { get; set; } = "郑勉忠";
            public string password { get; set; } = "zmz098765lly";
            public string account { get; set; } = "zmzlly;";
        }

        private string _str_tmp;
        private HttpListener _httpListener;

        /// <summary>
        /// 监听异步任务
        /// </summary>
        private Task _taskListener = null;


        private void Display(RichTextBox rich, string Msg, string str_color="黑")
        {
            if (rich.InvokeRequired) 
                rich.Invoke(new Action<RichTextBox, string, string>(Display), new object[] { rich, Msg, str_color });
            else
            {
                Color color = str_color == "红" ? Color.Red : (str_color == "绿" ? Color.Green : Color.Black);
                rich.ScrollToCaret();
                rich.SelectionLength = 0;
                rich.SelectionColor = color;
                rich.AppendText($"{Msg.Replace("</br>", "\r\n")}\r\n");
            }
        }

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            Action<string> actionDisplay = (Msg) =>
            {
                RtBox_S_Msg.Invoke(new Action<RichTextBox, string, string>(Display),
                    new object[] { RtBox_S_Msg, Msg.Replace("</br>", "\r\n"), ""});
            };

            Assembly assembly = Assembly.Load("HttpServer");
            var types = assembly.GetTypes().Where(t => t.BaseType.Name == "AbstractServer" && t.Name != "Default");
           
            try
            {
                _httpListener = new HttpListener
                {
                    AuthenticationSchemes = AuthenticationSchemes.Anonymous
                };
                _httpListener.Prefixes.Add($"http://{S_IP}:{S_Port}/");
                _httpListener.Start();

                _taskListener = new Task(() => {
                    Display(RtBox_S_Msg, "监听线程已启动 。。。。。。");
                    while(true)
                    {
                        HttpListenerContext ctx;
                        try { ctx = _httpListener.GetContext(); }
                        catch 
                        {
                            Display(RtBox_S_Msg, "监听线程已停止 。。。。。。", "红");
                            break; 
                        }

                        Task taskClient = new Task(() =>
                        {
                            try
                            {
                                string method = ctx.Request.RawUrl.Split('&')[0].Split('/')[1].Split('?')[0];
                                if (method == "favicon.ico") return;
                                AbstractServer @server;
                                if (string.IsNullOrEmpty(method) || method.ToLower() == "default") @server = new Default(ctx, $"当前可提供的服务：", types);
                                else
                                {
                                    Type type = types.FirstOrDefault(t => t.Name.ToUpper() == method.ToUpper());
                                    if (type == null) @server = new Default(ctx, $"请求的服务【{method}】不存在！</br> 当前可提供的服务：", types);
                                    else
                                    {
                                        @server = (AbstractServer)Activator.CreateInstance(type, new object[] { ctx });
                                        string errMsg = @server.CheckQueryKeyValue();
                                        if (errMsg != "OK") @server = new Default(ctx, $"{errMsg}</br> 当前可提供的服务：", types);
                                    }
                                }
                                @server.ServerMethod(actionDisplay);
                            }
                            catch (Exception ex)
                            {
                                Display(RtBox_S_Msg, $"处理Http请求异常！！！{ex.Message}", "红");
                                ctx.Response.ContentType = "text/plain;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
                                ctx.Response.AddHeader("Content-type", "text/plain");//添加响应头信息
                                ctx.Response.ContentEncoding = Encoding.UTF8;
                                ctx.Response.StatusDescription = "200";//获取或设置返回给客户端的 HTTP 状态代码的文本说明。
                                ctx.Response.StatusCode = 200;//设置返回给客服端http状态代码
                                using (StreamWriter writer = new StreamWriter(ctx.Response.OutputStream, Encoding.UTF8))
                                {
                                    writer.Write($"处理Http请求异常！！！{ex.Message}");
                                    writer.Close();
                                    ctx.Response.Close();
                                }
                            }
                            
                        });
                        taskClient.Start();
                    }
                });
                _taskListener.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"服务器启动失败 ！{ex.Message}");
                return;
            }

            Btn_Start.Enabled = false;
            Btn_Stop.Enabled = true;
            TextBox_S_IP.Enabled = false;
            TextBox_S_Port.Enabled = false;
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            _httpListener.Stop();
            Btn_Start.Enabled = true;
            Btn_Stop.Enabled = false;
            TextBox_S_IP.Enabled = true;
            TextBox_S_Port.Enabled = true;
        }

        
        private void TextBox_S_IP_Enter(object sender, EventArgs e)
        {
            _str_tmp = TextBox_S_IP.Text;
        }

        private void TextBox_S_IP_Leave(object sender, EventArgs e)
        {
            if(!IPAddress.TryParse(TextBox_S_IP.Text,out IPAddress ip))
            {
                MessageBox.Show($"非法的IP地址！【{TextBox_S_IP.Text}】");
                TextBox_S_IP.Text = _str_tmp;
                return;
            }
            S_IP = TextBox_S_IP.Text;
        }

        private void TextBox_S_Port_Enter(object sender, EventArgs e)
        {
            _str_tmp = TextBox_S_Port.Text;
        }

        private void TextBox_S_Port_Leave(object sender, EventArgs e)
        {
            ushort.TryParse(TextBox_S_Port.Text, out ushort us);
            if (us < 5000 || us > 9999)
            {
                MessageBox.Show($"要求端口号在【5000-9999】！【{TextBox_S_Port.Text}】");
                TextBox_S_Port.Text = _str_tmp;
                return;
            }
            S_Port = us;
        }
    }
}
