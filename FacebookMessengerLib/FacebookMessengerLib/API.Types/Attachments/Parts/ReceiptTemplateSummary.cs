using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    public class ReceiptTemplateSummary
    {
        public double Subtotal { get; set; }
        public double ShippingCost { get; set; }
        public double TotalTax { get; set; }
        public double TotalCost { get; set; }
    }
}
