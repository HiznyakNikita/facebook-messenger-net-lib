﻿using FacebookMessengerLib.API.Types;
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
    }
}
