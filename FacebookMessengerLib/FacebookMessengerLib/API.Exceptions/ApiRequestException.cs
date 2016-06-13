using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Exceptions
{
    public class ApiRequestException : Exception
    {
        public int ErrorCode { get; internal set; }

        public ApiRequestException(string message)
            : base(message)
        {
        }

        public ApiRequestException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ApiRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiRequestException(string message, int errorCode, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
