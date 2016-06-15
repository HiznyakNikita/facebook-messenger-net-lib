using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum TemplatePayloadType
    {
        Generic,
        Button,
        Receipt
    }

    public abstract class TemplatePayload : IPayload
    {
        public TemplatePayloadType TemplateType { get; set; }
    }
}
