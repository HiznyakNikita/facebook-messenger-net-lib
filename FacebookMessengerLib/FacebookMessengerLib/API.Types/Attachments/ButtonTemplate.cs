using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    [JsonObject]
    public class ButtonTemplate
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "buttons", Required = Required.Always)]
        public IList<MessageButton> Buttons { get; set; }
    }
}
