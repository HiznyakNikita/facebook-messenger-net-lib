using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum MessageButtonType
    {
        WebUrl,
        Postback
    }

    [JsonObject]
    public class MessageButton
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public MessageButtonType Type { get; set; }
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public IPayload Payload { get; set; }
    }
}
