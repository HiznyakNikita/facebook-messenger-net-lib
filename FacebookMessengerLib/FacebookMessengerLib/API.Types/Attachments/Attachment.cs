using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum AttachmentType
    {
        Image,
        Template
    }

    public class Attachment
    {
        public AttachmentType Type { get; set; }
        public IPayload Payload { get; set; }
    }
}
