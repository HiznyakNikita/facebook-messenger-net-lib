using FacebookMessengerLib.API.Types.Attachments.Parts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    [JsonObject]
    public class ReceiptTemplate : TemplatePayload
    {
        [JsonProperty(PropertyName = "recipient_name", Required = Required.Always)]
        public string RecipientName { get; set; }
        [JsonProperty(PropertyName = "order_number", Required = Required.Always)]
        public string OrderNumber { get; set; }
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "payment_method", Required = Required.Always)]
        public string PaymentMethod { get; set; }
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public string Timestamp { get; set; }
        [JsonProperty(PropertyName = "order_url", Required = Required.Always)]
        public string OrderUrl { get; set; }
        [JsonProperty(PropertyName = "elements", Required = Required.Always)]
        public IList<ReceiptTemplateElement> Elements { get; set; }
        [JsonProperty(PropertyName = "summary", Required = Required.Always)]
        public ReceiptTemplateSummary Summary { get; set; }
        [JsonProperty(PropertyName = "address", Required = Required.Always)]
        public Address Address { get; set; }
        [JsonProperty(PropertyName = "adjustments", Required = Required.Always)]
        public IList<ReceiptAdjustments> Adjustments { get; set; }

        public ReceiptTemplate()
        {
            TemplateType = TemplatePayloadType.Receipt;
        }
    }
}
