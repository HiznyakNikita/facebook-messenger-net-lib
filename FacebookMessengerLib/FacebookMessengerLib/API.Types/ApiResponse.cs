using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types
{
    [JsonObject]
    public class ApiResponse<T>
    {
        [JsonProperty(PropertyName = "result", Required = Required.Default)]
        public T Result { get; internal set; }

        [JsonProperty(PropertyName = "recipient_id", Required = Required.Default)]
        public int RecipientId { get; internal set; }

        [JsonProperty(PropertyName = "message_id", Required = Required.Default)]
        public int MessageId { get; internal set; }

        [JsonProperty(PropertyName = "error", Required = Required.Default)]
        public ApiError Error { get; internal set; }
    }
}
