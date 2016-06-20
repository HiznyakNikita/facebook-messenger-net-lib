using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum AttachmentType
    {
        Image,
        Template
    }

    public class Attachment
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public AttachmentType Type { get; set; }
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public IPayload Payload { get; set; }

        public Attachment(AttachmentType type, IPayload payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}
