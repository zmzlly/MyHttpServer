using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace HttpServer
{
    /// <summary>
    /// 客户端请求上下文的有关内容
    /// </summary>
    public class RequestContextModel
    {
        /// <summary>
        /// 请求模式：GET、POST。。。。。。
        /// </summary>
        public string RequestMode { get; set; }
        /// <summary>
        /// 客户端请求的URL
        /// </summary>
        public Uri RequestUrL { get; set; }
        /// <summary>
        /// 客户端请求 URL 中的查询键值对
        /// </summary>
        public Dictionary<string, string> QueryKeyValues { get; private set; } = new Dictionary<string, string>();
        /// <summary>
        /// 客户端请求的头键值对，键对应的值是字符串数组
        /// </summary>
        public Dictionary<string, string[]> HeaderKeyValues { get; private set; } = new Dictionary<string, string[]>();
        /// <summary>
        ///  客户端请求的Body
        /// </summary>
        public string RequestBody { get; set; } = "";

        /// <summary>
        /// 客户端请求的byte数组，用于上传文件
        /// </summary>
        public byte[] RequestBytesBody { get; set; }
    }
    /// <summary>
    /// <br>Http服务的抽象类，注意事项：</br>
    /// <br>1. 派生类的构造函数必须接收 HttpListenerContext 的对象，并且要给重写的 Ctx 属性赋值；</br>
    /// <br>2. 派生类的类名要和 Url 中的路径对应；</br>
    /// <br>3. Http的监听线程是根据客户端请求的Url中的路径，寻找对应的服务类（派生类）。</br>
    /// </summary>
    public abstract class AbstractServer
    {
        /// <summary>
        /// 服务方式：GET、POST、。。。，用于限定客户端的访问方式。
        /// </summary>
        public abstract string ServerMode { get; set; }

        /// <summary>
        /// 是否按字节数组接收BODY报文，用于上传文件
        /// </summary>
        public abstract bool IsBytesBody { get; set; }

        /// <summary>
        /// 客户端请求的上下文
        /// </summary>
        public abstract HttpListenerContext Ctx { get; set; }

        /// <summary>
        /// 根据不同的业务需求重写该方法。
        /// </summary>
        /// <param name="action">若要反馈执行结果必须回调该函数 </param>
        public abstract void ServerMethod(Action<string> action = null);

        /// <summary>
        /// 客户端请求上下文的有关内容
        /// </summary>
        public RequestContextModel ContextModel { get; set; } = new RequestContextModel();

        /// <summary>
        /// 检查url中的查询键值对的合法性并处理请求的上下文
        /// </summary>
        /// <returns></returns>
        public string CheckQueryKeyValue()
        {
            string errMsg = "OK";
            int index = Ctx.Request.RawUrl.IndexOf('?');

            if (index > 0)
            {
                if (index == Ctx.Request.RawUrl.Length - 1) return $"在问号后面没有查询字符串！【{Ctx.Request.RawUrl}】";
                string[] arry = Ctx.Request.RawUrl.Substring(index + 1).Split('&');
                foreach (string str_PV in arry)
                {
                    string[] arry_PV = str_PV.Split('=');
                    if (arry_PV.Length != 2) return $"非法的查询键值对！【{str_PV}】";
                    if (ContextModel.QueryKeyValues.ContainsKey(arry_PV[0])) return $"有重复的查询键！【{arry_PV[0]}】";
                    ContextModel.QueryKeyValues.Add(arry_PV[0], HttpUtility.UrlDecode(arry_PV[1], Encoding.UTF8));
                }
            }
            
            ContextModel.RequestMode = Ctx.Request.HttpMethod;
            ContextModel.RequestUrL = Ctx.Request.Url;

            string[] keys = Ctx.Request.Headers.AllKeys;
            foreach (string key in keys) ContextModel.HeaderKeyValues.Add(key, Ctx.Request.Headers.GetValues(key));

            Stream stream = Ctx.Request.InputStream;

            if(IsBytesBody)
            {
                List<byte> listByte = new List<byte>();
                byte[] arryByte = new byte[1024];
                while (true)
                {
                    int len = stream.Read(arryByte, 0, 1024);
                    if (len <=0) break;
                    for (int i = 0; i < len; i++) listByte.Add(arryByte[i]);
                }
                ContextModel.RequestBytesBody = listByte.ToArray();
            }
            else
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                ContextModel.RequestBody = reader.ReadToEnd();
            }
            return errMsg;
        }

        /// <summary>
        /// 使用Writer输出http响应代码,UTF8格式
        /// </summary>
        /// <param name="strBody"></param>
        public void WriteResponseBody(string strBody)
        {
            Ctx.Response.ContentType = "text/plain;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
            Ctx.Response.AddHeader("Content-type", "text/plain");//添加响应头信息
            Ctx.Response.ContentEncoding = Encoding.UTF8;
            Ctx.Response.StatusDescription = "200";//获取或设置返回给客户端的 HTTP 状态代码的文本说明。
            Ctx.Response.StatusCode = 200;//设置返回给客服端http状态代码
            using (StreamWriter writer = new StreamWriter(Ctx.Response.OutputStream, Encoding.UTF8))
            {
                writer.Write(strBody);
                writer.Close();
                Ctx.Response.Close();
            }
        }
    }
}
