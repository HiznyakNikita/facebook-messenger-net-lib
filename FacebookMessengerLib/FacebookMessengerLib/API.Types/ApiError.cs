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
        public string Message { get; internal set; }
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; internal set; }
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public int Code { get; internal set; }

        public ApiError()
        {
        }

        public ApiError(string message, int code)
        {
            Message = message;
            Code = code;
        }
    }
}
