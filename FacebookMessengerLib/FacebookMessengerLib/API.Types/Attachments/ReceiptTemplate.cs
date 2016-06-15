using FacebookMessengerLib.API.Types.Attachments.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public class ReceiptTemplate : TemplatePayload
    {
        public string RecipientName { get; set; }
        public string OrderNumber { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string Timestamp { get; set; }
        public string OrderUrl { get; set; }
        public IList<ReceiptTemplateElement> Elements { get; set; }
        public ReceiptTemplateSummary Summary { get; set; }
        public Address Address { get; set; }
        public IList<ReceiptAdjustments> Adjustments { get; set; }
    }
}
