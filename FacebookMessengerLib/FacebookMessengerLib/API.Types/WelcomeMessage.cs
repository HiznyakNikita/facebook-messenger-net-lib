using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types
{
    public class WelcomeMessage
    {
        [JsonProperty(PropertyName = "setting_type", Required = Required.Always)]
        public string SettingType { get; private set; }
        [JsonProperty(PropertyName = "thread_state", Required = Required.Always)]
        public string ThreadState { get; private set; }
        [JsonProperty(PropertyName = "call_to_actions", Required = Required.Always)]
        public IList<Message> CallToActions { get; set; }

        public WelcomeMessage()
        {
            SettingType = "call_to_actions";
            ThreadState = "new_thread";
        }
        public WelcomeMessage(IList<Message> callToActions)
        {
            SettingType = "call_to_actions";
            ThreadState = "new_thread";
            CallToActions = callToActions;
        }
    }
}
