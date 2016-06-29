using FacebookMessengerLib.API.Types;
using FacebookMessengerLib.API.Types.Attachments;
using FacebookMessengerLib.API.Types.Attachments.Parts;
using FacebookMessengerLib.GeneralUtils;
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
        private WebRequestSender _messagesRequestsSender;
        private WebRequestSender _settingsRequestsSender;

        public MessengerAPI(string token)
        {
            _token = token;
            _messagesRequestsSender = new WebRequestSender(Settings.Default.BaseMessagesApiUrl, _token);
            _settingsRequestsSender = new WebRequestSender(Settings.Default.BaseSettingsApiUrl, _token);
        }

        public async Task SendTextMessageAsync(long userId, string text)
        {
            Message message = new Message() { Text = text };
            await SendApiMessagesParameters(userId, message);
        }

        public async Task SendButtonTemplateMessageAsync(long userId, string text, List<MessageButton> buttons)
        {
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, new ButtonTemplate(text, buttons)) };
            await SendApiMessagesParameters(userId, message);
        }

        public async Task SendGenericTemplateMessageAsync(long userId, List<GenericTemplateElement> elements)
        {
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, new GenericTemplate(elements)) };
            await SendApiMessagesParameters(userId, message);
        }

        public async Task SendReceiptTemplateMessageAsync(long userId, ReceiptTemplate receipt)
        {
            Message message = new Message() { Attachment = new Attachment(AttachmentType.Template, receipt) };
            await SendApiMessagesParameters(userId, message);
        }

        public async Task SendWelcomeMessageAsync(WelcomeMessage welcomeMessage)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"setting_type", welcomeMessage.SettingType},
                {"thread_state", welcomeMessage.ThreadState},
                {"call_to_actions", welcomeMessage.CallToActions }
            };
            await _settingsRequestsSender.SendWebRequestAsync<string>("", parameters);
        }

        private async Task SendApiMessagesParameters(long userId, Message message)
        {
            Recipient recipient = new Recipient(userId);
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _messagesRequestsSender.SendWebRequestAsync<string>("", parameters);
        }
    }
}
