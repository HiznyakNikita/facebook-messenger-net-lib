using FacebookMessengerLib.API.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Exceptions
{
    public class ApiRequestException : Exception
    {
        public ApiError ApiError { get; set; }
        public int ErrorCode { get; set; }

        public ApiRequestException(string message)
            : base(message)
        {
        }

        public ApiRequestException(string message, int errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ApiRequestException(string message, ApiError apiError) : base(message)
        {
            ApiError = apiError;
        }

        public ApiRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiRequestException(string message, ApiError apiError, Exception innerException) : base(message, innerException)
        {
            ApiError = apiError;
        }
    }
}
