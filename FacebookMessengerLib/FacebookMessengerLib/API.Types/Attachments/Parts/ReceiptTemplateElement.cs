using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    public class ReceiptTemplateElement
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string ImageUrl { get; set; }
    }
}
