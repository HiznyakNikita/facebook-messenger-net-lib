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
    public class ApiError
    {
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public string Message { get; internal set; }
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; internal set; }
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public int ErrorCode { get; internal set; }
        [JsonProperty(PropertyName = "fbtrace_id", Required = Required.Always)]
        public string TraceId { get; set; }
        [JsonProperty(PropertyName = "error_data", Required = Required.Always)]
        public string ErrorData { get; set; }

        public ApiError()
        {
        }
    }
}
