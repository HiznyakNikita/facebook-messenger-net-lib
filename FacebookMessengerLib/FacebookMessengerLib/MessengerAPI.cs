using FacebookMessengerLib.API.Types;
using FacebookMessengerLib.API.Types.Attachments;
using FacebookMessengerLib.API.Types.Attachments.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib
{
    public class MessengerAPI
    {
        private string _baseUrl = "https://graph.facebook.com/v2.6/me/messages?access_token=";
        private string _token = "";
        private GeneralUtils _utils;

        public MessengerAPI (string token)
        {
            _token = token;
            _utils = new GeneralUtils(_baseUrl, _token);
        }

        public async Task SendTextMessageAsync (long userId, string text)
        {
            Recipient recipient = new Recipient(userId);
            Message message = new Message() { Text = text };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _utils.SendWebRequestAsync<string>("",parameters);
        }

        public async Task SendButtonTemplateMessageAsync (long userId, string text, List<MessageButton> buttons)
        {
            Recipient recipient = new Recipient(userId);
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, new ButtonTemplate(text, buttons)) };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _utils.SendWebRequestAsync<string>("", parameters);
        }

        public async Task SendGenericTemplateMessageAsync (long userId, List<GenericTemplateElement> elements)
        {
            Recipient recipient = new Recipient(userId);
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, new GenericTemplate(elements)) };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _utils.SendWebRequestAsync<string>("", parameters);
        }

        public async Task SendReceiptTemplateMessageAsync (long userId, ReceiptTemplate receipt)
        {
            Recipient recipient = new Recipient(userId);
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, receipt) };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _utils.SendWebRequestAsync<string>("", parameters);
        }
    }
}
