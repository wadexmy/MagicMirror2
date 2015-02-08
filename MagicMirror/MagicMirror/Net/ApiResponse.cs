using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MagicMirror.Net
{

    /// <summary>
    ///     响应对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// </summary>
        public ApiResponse()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="apiResponse"></param>
        public ApiResponse(ApiResponse apiResponse)
        {
            Success = apiResponse.Success;
            ErrorMessage = apiResponse.ErrorMessage;
        }

        /// <summary>
        ///     响应内容，如果请求成功，则可能会返回响应的内容
        /// </summary>
        public T Context { get; set; }
    }

    public class ApiResponse
    {
        /// <summary>
        ///     响应结果
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        ///     响应状态码
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        ///     当请求失败时，返回的失败信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
