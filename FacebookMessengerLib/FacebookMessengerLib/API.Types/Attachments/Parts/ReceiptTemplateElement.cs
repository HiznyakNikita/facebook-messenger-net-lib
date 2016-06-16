using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    [JsonObject]
    public class ReceiptTemplateElement
    {
        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "subtitle", Required = Required.Always)]
        public string Subtitle { get; set; }
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        public double Quantity { get; set; }
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public double Price { get; set; }
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "image_url", Required = Required.Always)]
        public string ImageUrl { get; set; }
    }
}
