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
    public class BuyButton : MessageButton
    {
        [DefaultValue("")]
        [JsonProperty(PropertyName = "payment_summary", Required = Required.Default)]
        public PaymentSummary PaymentSummary { get; set; }
    }
}
