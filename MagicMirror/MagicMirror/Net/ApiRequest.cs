using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMirror.Net
{
    /// <summary>
    ///     请求对象，带泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiRequest<T> : ApiRequest
    {
        /// <summary>
        /// </summary>
        public ApiRequest()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="apiRequest"></param>
        public ApiRequest(ApiRequest apiRequest)
        {
            ServerAddress = apiRequest.ServerAddress;
            ApiPath = apiRequest.ApiPath;
            Method = apiRequest.Method;
            AppKey = apiRequest.AppKey;
        }

        //public T Param { get; set; }
    }

    public class ApiRequest
    {

        public ApiRequest()
        {
        }

        public ApiRequest(string serverAddress, string apiPath, Method method = Method.Post, string appkey = null)
        {
            ServerAddress = serverAddress;
            ApiPath = apiPath;
            Method = method;
            AppKey = appkey;
        }

        /// <summary>
        ///     服务器地址，如：http://192.168.1.1:8080/
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        ///     请求地址，如：api/login
        /// </summary>
        public string ApiPath { get; set; }

        /// <summary>
        ///     请求方法
        /// </summary>
        public Method Method { get; set; }

        public string AppKey { get; set; }

        /// <summary>
        ///     AppKey
        /// </summary>
        public KeyValuePair<string, string> AppKeyPair
        {
            get { return new KeyValuePair<string, string>("APP_KEYS", AppKey); }
        }

        public object Param { get; set; }
    }
}
