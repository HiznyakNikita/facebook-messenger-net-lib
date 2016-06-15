using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments
{
    public enum MessageButtonType
    {
        WebUrl,
        Postback
    }

    public class MessageButton
    {
        public MessageButtonType Type { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public IPayload Payload { get; set; }
    }
}
