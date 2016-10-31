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
    public class PricelistItem
    {
        [DefaultValue("")]
        [JsonProperty(PropertyName = "label", Required = Required.Default)]
        public string Label { get; set; }
        [DefaultValue("")]
        [JsonProperty(PropertyName = "amount", Required = Required.Default)]
        public double Amount { get; set; }
    }
}
