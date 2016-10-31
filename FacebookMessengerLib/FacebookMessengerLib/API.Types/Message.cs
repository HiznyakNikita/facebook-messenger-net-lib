using FacebookMessengerLib.API.Types.Attachments;
using FacebookMessengerLib.API.Types.Attachments.Parts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types
{
    [JsonObject]
    public class Message
    {
        [JsonProperty(PropertyName = "text", Required = Required.Default)]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "attachment", Required = Required.Default)]
        public Attachment Attachment { get; set; }
        [JsonProperty(PropertyName = "quick_replies", Required = Required.Default)]
        public IList<QuickReply> QuickReplies { get; set; }
    }
}
