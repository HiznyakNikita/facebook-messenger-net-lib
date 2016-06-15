using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public class ButtonTemplate
    {
        public string Text { get; set; }
        public IList<MessageButton> Buttons { get; set; }
    }
}
