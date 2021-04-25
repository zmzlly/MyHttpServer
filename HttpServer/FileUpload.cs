using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    /// <summary>
    /// 接收上传文件，根据业务需求返回结果，文件大小不能超过2GB！
    /// </summary>
    public class FileUpload : AbstractServer
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
        /// 接收上传文件构造函数
        /// </summary>
        /// <param name="ctx">客户端请求的上下文</param>
        public FileUpload(HttpListenerContext ctx)
        {
            Ctx = ctx;
        }

        /// <summary>
        /// 接收上传文件，根据业务需求返回结果
        /// </summary>
        /// <param name="action">主线程委托，为了解耦并给主线程返回信息</param>
        public override void ServerMethod(Action<string> action = null)
        {
            string errMsg = "";
            if (ServerMode.IndexOf(ContextModel.RequestMode) < 0)
            {
                errMsg = $"本服务只响应【{ServerMode}】请求！";
                action?.Invoke(errMsg);
                WriteResponseBody(errMsg);
                return;
            }
            if (!ContextModel.QueryKeyValues.ContainsKey("FileName"))
            {
                errMsg = "请在请求的URL中添加参数：FileName=xxx，用于指定上传文件名";
                action?.Invoke(errMsg);
                WriteResponseBody(errMsg);
                return;
            }
            string fileName = ContextModel.QueryKeyValues["FileName"];
            FileStream fs = new FileStream($"接收文件目录\\{fileName}", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(ContextModel.RequestBytesBody);
            bw.Close();
            fs.Close();
            errMsg = $"文件【{fileName}】已接收并处理完毕！";
            action?.Invoke(errMsg);
            WriteResponseBody(errMsg);
        }
    }
}
