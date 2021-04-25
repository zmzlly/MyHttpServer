using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    /// <summary>
    /// 下载用户指定的文件
    /// </summary>
    public class FileDownload : AbstractServer
    {
        /// <summary>
        /// 本服务只接受POST请求
        /// </summary>
        public override string ServerMode { get; set; } = "POST";

        /// <summary>
        /// 是否按字节数组接收BODY报文，用于上传文件
        /// </summary>
        public override bool IsBytesBody { get; set; } = true;

        /// <summary>
        /// 客户端请求的上下文，要在构造函数中赋值
        /// </summary>
        public override HttpListenerContext Ctx { get; set; }

        /// <summary>
        /// 下载用户指定的文件，构造函数
        /// </summary>
        /// <param name="ctx">客户端请求的上下文</param>
        public FileDownload(HttpListenerContext ctx)
        {
            Ctx = ctx;
        }

        /// <summary>
        /// 下载用户指定的文件
        /// </summary>
        /// <param name="action">主线程委托，为了解耦并给主线程返回信息</param>
        public override void ServerMethod(Action<string> action = null)
        {
            if (ServerMode.IndexOf(ContextModel.RequestMode) < 0)
            {
                string errMsg = $"本服务只响应【{ServerMode}】请求！";
                action?.Invoke(errMsg);
                WriteResponseBody(errMsg);
                return;
            }
            if (!ContextModel.QueryKeyValues.ContainsKey("FileName"))
            {
                string errMsg = "请在请求的URL中添加参数：FileName=xxx，用于指定下载文件名";
                action?.Invoke(errMsg);
                WriteResponseBody(errMsg);
                return;
            }
            string fileName = ContextModel.QueryKeyValues["FileName"];

        }
    }
}
