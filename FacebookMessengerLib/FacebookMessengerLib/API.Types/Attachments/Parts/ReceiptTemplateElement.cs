using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    [JsonObject]
    public class ReceiptTemplateElement
    {
        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        [DefaultValue("")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "subtitle", Required = Required.Default)]
        [DefaultValue("")]
        public string Subtitle { get; set; }
        [JsonProperty(PropertyName = "quantity", Required = Required.Default)]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "price", Required = Required.Default)]
        public int Price { get; set; }
        [JsonProperty(PropertyName = "currency", Required = Required.Default)]
        [DefaultValue("")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "image_url", Required = Required.Default)]
        [DefaultValue("")]
        public string ImageUrl { get; set; }
    }
}
