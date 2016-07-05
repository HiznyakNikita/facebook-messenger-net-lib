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
        private WebRequestSender _requestsSender;

        public MessengerAPI(string token)
        {
            IHttpWebRequestFactory requestFactory = new HttpWebRequestFactory();
            _token = token;
            _requestsSender = new WebRequestSender(requestFactory);
        }

        #region Messages API methods

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

        #endregion

        #region Settings API methods

        public async Task SendWelcomeMessageAsync(WelcomeMessage welcomeMessage)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"setting_type", welcomeMessage.SettingType},
                {"thread_state", welcomeMessage.ThreadState},
                {"call_to_actions", welcomeMessage.CallToActions }
            };
            await _requestsSender.SendWebRequestAsync<string>(Settings.Default.BaseSettingsApiUrl + _token, parameters: parameters);
        }

        public async Task DeleteWelcomeMessageAsync()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"setting_type", "call_to_actions"},
                {"thread_state", "new_thread"},
                {"call_to_actions", new List<Message>() }
            };
            await _requestsSender.SendWebRequestAsync<string>(Settings.Default.BaseSettingsApiUrl + _token, parameters: parameters);
        }

        #endregion

        public async Task GetUserProfileData(long userId)
        {
            string userProfileApiUrl = String.Format(@"https://graph.facebook.com/v2.6/{0}?fields=first_name,last_name,locale,timezone,gender&access_token={1}", 
                userId.ToString(), 
                _token);
            await _requestsSender.SendWebRequestAsync<string>(userProfileApiUrl, "GET");
        }

        public async Task SubscibeAppToPage(string accessToken)
        {
            await _requestsSender.SendWebRequestAsync<string>(Settings.Default.BaseSubscibeAppApiUrl + accessToken);
        }

        private async Task SendApiMessagesParameters(long userId, Message message)
        {
            Recipient recipient = new Recipient(userId);
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"recipient", recipient},
                {"message", message}
            };

            await _requestsSender.SendWebRequestAsync<string>(Settings.Default.BaseMessagesApiUrl + _token, parameters: parameters);
        }
    }
}
