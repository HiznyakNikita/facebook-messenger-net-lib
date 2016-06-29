using FacebookMessengerLib.API.Types;
using FacebookMessengerLib.API.Types.Attachments;
using FacebookMessengerLib.API.Types.Attachments.Parts;
using FacebookMessengerLib.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib
{
    public class MessengerAPI
    {
        private string _token = "";
        private GeneralUtils _utils;

        public MessengerAPI(string token)
        {
            _token = token;
            _utils = new GeneralUtils(Settings.Default.BaseApiUrl, _token);
        }

        public async Task SendTextMessageAsync(long userId, string text)
        {
            Message message = new Message() { Text = text };
            await SendApiParameters(userId, message);
        }

        public async Task SendButtonTemplateMessageAsync(long userId, string text, List<MessageButton> buttons)
        {
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, new ButtonTemplate(text, buttons)) };
            await SendApiParameters(userId, message);
        }

        public async Task SendGenericTemplateMessageAsync(long userId, List<GenericTemplateElement> elements)
        {
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, new GenericTemplate(elements)) };
            await SendApiParameters(userId, message);
        }

        public async Task SendReceiptTemplateMessageAsync(long userId, ReceiptTemplate receipt)
        {
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, receipt) };
            await SendApiParameters(userId, message);
        }

        private async Task SendApiParameters(long userId, Message message)
        {
            Recipient recipient = new Recipient(userId);
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _utils.SendWebRequestAsync<string>("", parameters);
        }
    }
}
