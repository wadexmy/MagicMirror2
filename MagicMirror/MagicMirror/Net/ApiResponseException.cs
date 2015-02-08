using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MagicMirror.Net
{
    public class ApiResponseException : ApiException
    {
        private readonly string _errorMessage;
        private readonly HttpStatusCode _httpStatusCode;

        /// <summary>
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="errorMessage"></param>
        public ApiResponseException(HttpStatusCode httpStatusCode, string errorMessage)
            : base(errorMessage)
        {
            _httpStatusCode = httpStatusCode;
            _errorMessage = errorMessage;
        }

        /// <summary>
        ///     状态码
        /// </summary>
        public HttpStatusCode HttpStatusCode
        {
            get { return _httpStatusCode; }
        }

        /// <summary>
        ///     状态码
        /// </summary>
        public int StatusCode
        {
            get { return Convert.ToInt32(HttpStatusCode); }
        }

        /// <summary>
        ///     错误信息
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}
