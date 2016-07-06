using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    [JsonObject]
    public class ButtonTemplate : TemplatePayload
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "buttons", Required = Required.Always)]
        public IList<MessageButton> Buttons { get; set; }

        public ButtonTemplate(string text, List<MessageButton> buttons)
        {
            TemplateType = TemplatePayloadType.Button;
            Text = text;
            Buttons = buttons;
        }
    }
}
