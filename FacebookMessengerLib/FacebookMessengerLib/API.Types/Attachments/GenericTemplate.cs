using FacebookMessengerLib.API.Types.Attachments.Parts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    [JsonObject]
    public class GenericTemplate : TemplatePayload
    {
        [JsonProperty(PropertyName = "elements", Required = Required.Always)]
        public IList<GenericTemplateElement> Elements { get; set; }

        public GenericTemplate(List<GenericTemplateElement> elements)
        {
            Elements = elements;
            TemplateType = TemplatePayloadType.Generic;
        }
    }
}
