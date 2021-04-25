using Newtonsoft.Json;
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
    /// 用户登录测试
    /// </summary>
    public class LoginTest : AbstractServer
    {
        class ResponseBodyModel
        {
            public int Id { get; set; } = 999;
            public string Name { get; set; } = "贾宝玉";
            public bool Sex { get; set; } = true;
            public string Birthday { get; set; } = DateTime.Today.AddYears(-300).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 该服务响应的请求类型
        /// </summary>
        public override string ServerMode { get; set; } = "POST/GET";

        /// <summary>
        /// 是否按字节数组接收BODY报文，用于上传文件
        /// </summary>
        public override bool IsBytesBody { get; set; } = true;

        /// <summary>
        /// 客户端请求的上下文，要在构造函数中赋值
        /// </summary>
        public override HttpListenerContext Ctx { get; set; }

        /// <summary>
        /// 测试登录构造函数
        /// </summary>
        /// <param name="ctx">客户端请求的上下文</param>
        public LoginTest(HttpListenerContext ctx)
        {
            Ctx = ctx;
        }

        /// <summary>
        /// 用户登录测试
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

            action?.Invoke($"{ContextModel.RequestMode} ------ {Ctx.Request.Url}");
            action?.Invoke($"URL中的查询键值对：\r\n {JsonConvert.SerializeObject(ContextModel.QueryKeyValues)}");
            action?.Invoke($"客户端请求头键值对：\r\n {JsonConvert.SerializeObject(ContextModel.HeaderKeyValues)}");
            action?.Invoke($"客户端请求的BODY：\r\n {ContextModel.RequestBody}");

            string responseBody = JsonConvert.SerializeObject(new ResponseBodyModel());
            action?.Invoke($"返回给客户端的BODY：\r\n {responseBody}");
            WriteResponseBody(responseBody);
        }
    }
}
