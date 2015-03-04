using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicMirror.Net
{
    public class ApiHelper
    {
        private const string JsonMediaType = "application/json";
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;


        /// <summary>
        ///     初始化HttpClient
        /// </summary>
        /// <param name="apiRequest"></param>
        private static HttpClient CreateHttpClient(ApiRequest apiRequest)
        {
            if (String.IsNullOrEmpty(apiRequest.ServerAddress))
            {
                throw new ArgumentNullException("ServerAddress", "ApiRequest.ServerAddress 为空");
            }
            var client = new HttpClient
            {
                BaseAddress = new Uri(apiRequest.ServerAddress)
            };


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));

            // 添加AppKey到 RequestHeaders
            if (string.IsNullOrEmpty(apiRequest.AppKeyPair.Value) == false)
                client.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue(apiRequest.AppKeyPair.Key, apiRequest.AppKeyPair.Value);

            return client;
        }

        /// <summary>
        ///     调用API，不带请求参数，带响应数据
        /// </summary>
        /// <param name="apiRequest">Api请求</param>
        /// <param name="throwableException">当设置为true时，发生错误会抛出异常</param>
        /// <returns></returns>
        public static Task<ApiResponse<TRsponse>> Execute<TRsponse>(ApiRequest apiRequest, bool throwableException = true)
        {
            return Task<ApiResponse<TRsponse>>.Factory.StartNew(() => DoExecute<TRsponse>(apiRequest, throwableException));
        }

        /// <summary>
        ///     调用API，带请求参数，带响应数据
        /// </summary>
        /// <param name="apiRequest">Api请求</param>
        /// <param name="throwableException">当设置为true时，发生错误会抛出异常</param>
        /// <returns></returns>
        public static Task<ApiResponse<TRsponse>> Execute<TRequest, TRsponse>(ApiRequest<TRequest> apiRequest, bool throwableException = true)
        {
            return Task<ApiResponse<TRsponse>>.Factory.StartNew(() => DoExecute<TRsponse>(apiRequest, throwableException));
        }

        public static Task<ApiResponse> Execute(ApiRequest apiRequest, bool throwableException = true) {
            return Task<ApiResponse>.Factory.StartNew(() => DoExecute(apiRequest, throwableException));
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <typeparam name="TRsponse">返回对象</typeparam>
        /// <param name="apiRequest">请求的对象</param>
        /// <param name="throwableException"></param>
        /// <returns></returns>
        private static ApiResponse<TRsponse> DoExecute<TRsponse>(ApiRequest apiRequest, bool throwableException = false)
        {
            using (var client = CreateHttpClient(apiRequest))
            using (HttpResponseMessage responseMessage = GenerateResponseMessage(client, apiRequest))
            {
                var response = new ApiResponse<TRsponse>
                {
                    Success = responseMessage.IsSuccessStatusCode,
                    HttpStatusCode = responseMessage.StatusCode
                };

                if (response.Success)
                {
                    String result = responseMessage.Content.ReadAsStringAsync().Result;
                    var rsponse = JsonConvert.DeserializeObject<TRsponse>(result);

                    response.Context = rsponse;
                }
                else
                {
                    response.ErrorMessage = responseMessage.Content.ReadAsStringAsync().Result;

                    if (throwableException)
                    {
                        throw new ApiResponseException(response.HttpStatusCode, response.ErrorMessage);
                    }
                }

                return response;
            }
        }

        /// <summary>
        /// 执行请求（无返回值）
        /// </summary>
        /// <param name="apiRequest">请求的对象</param>
        /// <param name="throwableException"></param>
        /// <returns></returns>
        private static ApiResponse DoExecute(ApiRequest apiRequest, bool throwableException = false)
        {
            using (var client = CreateHttpClient(apiRequest))
            using (HttpResponseMessage responseMessage = GenerateResponseMessage(client, apiRequest))
            {
                var response = new ApiResponse
                {
                    Success = responseMessage.IsSuccessStatusCode,
                    HttpStatusCode = responseMessage.StatusCode
                };

                if (response.Success == false)
                {
                    response.ErrorMessage = responseMessage.Content.ReadAsStringAsync().Result;

                    if (throwableException)
                    {
                        throw new ApiResponseException(response.HttpStatusCode, response.ErrorMessage);
                    }
                }

                return response;
            }
        }

        /// <summary>
        ///     获取响应信息
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="apiRequest"></param>
        /// <returns></returns>
        private static HttpResponseMessage GenerateResponseMessage(
            HttpClient client,
            ApiRequest apiRequest)
        {
            var method = apiRequest.Method;
            var apiPath = apiRequest.ApiPath;
            var requestParam = apiRequest.Param;

            switch (method)
            {
                case Method.Get:
                    return client.GetAsync(apiPath).Result;
                case Method.Post:
                    return client.PostAsync(apiPath, SerializeObjectToJson(requestParam)).Result;
                case Method.Put:
                    return client.PutAsync(apiPath, SerializeObjectToJson(requestParam)).Result;
                case Method.Delete:
                    return client.DeleteAsync(apiPath).Result;
                default:
                    throw new ArgumentOutOfRangeException("apiRequest", "apiRequest.Method 类型错误");
            }
        }

        /// <summary>
        ///     序列化对象为JSON字符串
        /// </summary>
        /// <param name="obj">需要转换成JSON的对象</param>
        /// <returns></returns>
        private static StringContent SerializeObjectToJson(object obj)
        {
            var param = JsonConvert.SerializeObject(obj);
            return new StringContent(param, DefaultEncoding, JsonMediaType);
        }
    }
}
