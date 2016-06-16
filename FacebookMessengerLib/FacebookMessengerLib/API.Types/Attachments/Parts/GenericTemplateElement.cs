using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    [JsonObject]
    public class GenericTemplateElement
    {
        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "item_url", Required = Required.Always)]
        public string ItemUrl { get; set; }
        [JsonProperty(PropertyName = "image_url", Required = Required.Always)]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "subtitle", Required = Required.Always)]
        public string Subtitle { get; set; }
        [JsonProperty(PropertyName = "buttons", Required = Required.Always)]
        public IList<MessageButton> Buttons { get; set; }
    }
}
