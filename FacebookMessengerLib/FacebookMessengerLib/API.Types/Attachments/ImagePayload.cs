using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    [JsonObject]
    public class ImagePayload : IPayload
    {
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public String Url { get; set; }
    }
}
