using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    public class GenericTemplateElement
    {
        public string Title { get; set; }
        public string ItemUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Subtitle { get; set; }
        public IList<MessageButton> Buttons { get; set; }
    }
}
