using FacebookMessengerLib.API.Types.Attachments.Parts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    [JsonObject]
    public class ReceiptTemplate : TemplatePayload
    {
        [JsonProperty(PropertyName = "recipient_name", Required = Required.Always)]
        [DefaultValue("")]
        public string RecipientName { get; set; }
        [JsonProperty(PropertyName = "order_number", Required = Required.Always)]
        [DefaultValue("")]
        public string OrderNumber { get; set; }
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        [DefaultValue("")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "payment_method", Required = Required.Always)]
        [DefaultValue("")]
        public string PaymentMethod { get; set; }
        [JsonProperty(PropertyName = "timestamp", Required = Required.Default)]
        [DefaultValue("")]
        public string Timestamp { get; set; }
        [JsonProperty(PropertyName = "order_url", Required = Required.Default)]
        [DefaultValue("")]
        public string OrderUrl { get; set; }
        [JsonProperty(PropertyName = "elements", Required = Required.Always)]
        public IList<ReceiptTemplateElement> Elements { get; set; }
        [JsonProperty(PropertyName = "summary", Required = Required.Always)]
        public ReceiptTemplateSummary Summary { get; set; }
        [JsonProperty(PropertyName = "address", Required = Required.Default)]
        public Address Address { get; set; }
        [JsonProperty(PropertyName = "adjustments", Required = Required.Default)]
        public IList<ReceiptAdjustments> Adjustments { get; set; }

        public ReceiptTemplate(
            string recipientName, 
            string orderNum, 
            string currency, 
            string paymentMethod, 
            List<ReceiptTemplateElement> elements,
            ReceiptTemplateSummary summary,
            string timestamp = "",
            string orderUrl = "",
            Address address = null,
            List<ReceiptAdjustments> adjustments = null)
        {
            TemplateType = TemplatePayloadType.Receipt;
            RecipientName = recipientName;
            OrderNumber = orderNum;
            Currency = currency;
            PaymentMethod = paymentMethod;
            Elements = elements;
            Summary = summary;
            Timestamp = timestamp;
            OrderUrl = orderUrl;
            Address = address;
            Adjustments = adjustments;
        }
    }
}
