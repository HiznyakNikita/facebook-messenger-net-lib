using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types
{
    /// <summary>
    /// Specify error type of API
    /// </summary>
    [JsonObject]
    public class ApiError : Exception
    {
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public string Message
        {
            get
            {
                return GetErrorMessage(ErrorCode);
            }
            internal set
            {
                Message = value;
            }
        }
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; internal set; }
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public int ErrorCode { get; internal set; }

        public ApiError()
        {
        }

        public ApiError(int errorCode)
        {
            ErrorCode = errorCode;
        }

        private string GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 400:
                    return "Server has an error Bad Request";
                default:
                    return "No errors!";
            }
        }
    }
}
