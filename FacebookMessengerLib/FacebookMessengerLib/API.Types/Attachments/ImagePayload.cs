using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    /// <summary>
    /// Payload for all types of objects which can be attached:
    /// Audio,Video,File,Image
    /// </summary>
    [JsonObject]
    public class ObjectPayload : IPayload
    {
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public String Url { get; set; }
    }
}
