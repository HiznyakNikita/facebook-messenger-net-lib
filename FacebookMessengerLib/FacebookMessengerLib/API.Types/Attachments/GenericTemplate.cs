using FacebookMessengerLib.API.Types.Attachments.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public class GenericTemplate : TemplatePayload
    {
        public IList<GenericTemplateElement> Elements { get; set; }
    }
}
