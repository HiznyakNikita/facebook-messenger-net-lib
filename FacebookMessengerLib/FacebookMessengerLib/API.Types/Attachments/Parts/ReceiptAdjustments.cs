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
    public class ReceiptAdjustments
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [DefaultValue("")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public int Amount { get; set; }
    }
}
