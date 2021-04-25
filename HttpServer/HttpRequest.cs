using ICSharpCode.SharpZipLib.GZip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    /// <summary>
    /// Http 客户端
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public static Task<string> PostAsyncJson(string url, string json)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();//用来抛异常的
            return response.Content.ReadAsStringAsync();

        }

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数字符串</param>
        /// <param name="header">头键值对，注意：头键值对中不能有汉字，可以使用utf8编码</param>
        /// <param name="strCookie">cookie值</param>
        /// <returns>返回的字符串</returns>
        public static Task<string> PostAsync(string url, string data, Dictionary<string, string[]> header = null, string strCookie = null)
        {
            //HttpClient client = new HttpClient(new HttpClientHandler(){ UseCookies = true });//自动带Cookies
            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });//要手工加Cookies
            HttpContent content = new StringContent(data);
            if (!string.IsNullOrEmpty(strCookie))content.Headers.Add("Cookie", strCookie);//手工加Cookies
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string PostFileUpload(string url, byte[] bytes)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("file", "IMG.jpg");
            request.Timeout = 60000;//一分钟
            request.ReadWriteTimeout = 60000;//一分钟
            request.KeepAlive = false;
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }



        /// <summary>
        /// 使用get方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="header">头键值对，注意：头键值对中不能有汉字，可以使用utf8编码</param>
        /// <returns>返回的字符串</returns>
        public static Task<string> GetAsync(string url, Dictionary<string, string[]> header = null)
        {

            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = client.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<T> PostObjectAsync<T, T2>(string url, T2 obj)
        {
            String json = JsonConvert.SerializeObject(obj);
            string responseBody = await PostAsyncJson(url, json); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }

        /// <summary>
        /// 使用Get返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <returns>返回请求的对象</returns>
        public static async Task<T> GetObjectAsync<T>(string url)
        {
            string responseBody = await GetAsync(url); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }
    }
}
