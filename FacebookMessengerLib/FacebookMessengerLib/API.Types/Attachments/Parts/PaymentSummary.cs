using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    public enum PaymentType
    {
        FIXED_AMOUNT,
        FLEXIBLE_AMOUNT
    }

    [JsonObject]
    public class PaymentSummary
    {
        [DefaultValue("")]
        [JsonProperty(PropertyName = "currency", Required = Required.Default)]
        public string Currency { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "payment_type", Required = Required.Always)]
        public PaymentType PaymentType { get; set; }
        [DefaultValue("")]
        [JsonProperty(PropertyName = "merchant_name", Required = Required.Default)]
        public string MerchantName { get; set; }
        [DefaultValue("")]
        [JsonProperty(PropertyName = "requested_user_info", Required = Required.Default)]
        public IList<string> RequestedUserInfo { get; set; }
        [DefaultValue("")]
        [JsonProperty(PropertyName = "price_list", Required = Required.Default)]
        public IList<PricelistItem> PriceList { get; set; }

        public PaymentSummary()
        {
            RequestedUserInfo = new List<string>();
            PriceList = new List<PricelistItem>();
        }
    }
}
