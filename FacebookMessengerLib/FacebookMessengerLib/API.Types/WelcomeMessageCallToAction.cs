using FacebookMessengerLib.API.Types.Attachments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types
{
    [JsonObject]
    public class WelcomeMessageCallToAction
    {
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public string Payload { get; set; }
    }
}
