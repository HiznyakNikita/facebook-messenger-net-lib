using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum MessageButtonType
    {
        Web_Url,
        Postback,
        PhoneNumber,
        Element_Share,
        Payment
    }

    [JsonObject]
    public class MessageButton
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public MessageButtonType Type { get; set; }
        [DefaultValue("")]
        [JsonProperty(PropertyName = "url", Required = Required.Default)]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "payload", Required = Required.Default)]
        public string Payload { get; set; }

        public MessageButton(MessageButtonType type, string title, string url = "", string payload = "")
        {
            Type = type;
            Title = title;
            Url = url;
            Payload = payload;
        }

        public MessageButton()
        {
        }
    }
}
