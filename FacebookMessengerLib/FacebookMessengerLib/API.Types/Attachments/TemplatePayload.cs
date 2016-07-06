using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum TemplatePayloadType
    {
        Generic,
        Button,
        Receipt
    }

    public abstract class TemplatePayload : IPayload
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "template_type", Required = Required.Always)]
        [DefaultValue(null)]
        public TemplatePayloadType TemplateType { get; set; }
    }
}
