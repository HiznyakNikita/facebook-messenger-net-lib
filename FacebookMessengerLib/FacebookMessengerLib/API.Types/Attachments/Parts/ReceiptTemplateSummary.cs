using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    [JsonObject]
    public class ReceiptTemplateSummary
    {
        [JsonProperty(PropertyName = "subtotal", Required = Required.Always)]
        public double Subtotal { get; set; }
        [JsonProperty(PropertyName = "shipping_cost", Required = Required.Always)]
        public double ShippingCost { get; set; }
        [JsonProperty(PropertyName = "total_tax", Required = Required.Always)]
        public double TotalTax { get; set; }
        [JsonProperty(PropertyName = "total_cost", Required = Required.Always)]
        public double TotalCost { get; set; }
    }
}
