using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMirror.Net
{
    public class ApiException : Exception
    {
        public ApiException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ApiException(string message)
            : base(message)
        {
        }
    }
}
