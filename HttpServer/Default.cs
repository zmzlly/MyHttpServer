using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HttpServer
{
    /// <summary>
    /// 当请求的URL没有路径或请求路径对应的服务类不存在时，执行Default服务。
    /// </summary>
    public class Default : AbstractServer
    {
        /// <summary>
        /// 该服务响应的请求类型
        /// </summary>
        public override string ServerMode { get; set; } = "ALL";

        /// <summary>
        /// 是否按字节数组接收BODY报文，用于上传文件
        /// </summary>
        public override bool IsBytesBody { get; set; } = true;

        /// <summary>
        /// 客户端请求的上下文，要在构造函数中赋值
        /// </summary>
        public override HttpListenerContext Ctx { get; set; }

        private string _msg;

        private IEnumerable<Type> _types;

        /// <summary>
        /// 必须给 Ctx 属性赋值
        /// </summary>
        /// <param name="ctx">客户端请求的上下文</param>
        /// <param name="msg">错误信息</param>
        /// <param name="types">所有继承了抽象类AbstractServer的派生类</param>
        public Default(HttpListenerContext ctx, string msg, IEnumerable<Type> types)
        {
            Ctx = ctx;
            _msg = msg;
            _types = types;
        }

        /// <summary>
        /// 根据不同的业务需求，重写该方法
        /// </summary>
        /// <param name="action">主线程委托，为了解耦并给主线程返回信息</param>
        public override void ServerMethod(Action<string> action = null)
        {
            XmlDocument xmlNote = new XmlDocument();
            if (File.Exists("HttpServer.xml")) xmlNote.Load("HttpServer.xml");
            foreach(Type type in _types)
            {
                XmlNode node = xmlNote.SelectSingleNode("doc").SelectSingleNode("members").SelectNodes("member")
                   .Cast<XmlNode>().FirstOrDefault(x => x.Attributes["name"].Value == $"T:{type.FullName}");
                _msg += $"</br>服务名称：{type.Name} ------ ";
                if (node != null) _msg += node.InnerText.Replace("\r\n", "").Replace(" ", "");
            }
            action?.Invoke(_msg);
            WriteResponseBody(_msg);
        }
    }
}
