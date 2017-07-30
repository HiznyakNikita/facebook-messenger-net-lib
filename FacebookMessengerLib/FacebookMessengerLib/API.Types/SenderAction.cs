using Newtonsoft.Json;

namespace FacebookMessengerLib.API.Types
{
    /// <summary>
    /// Set typing indicators or send read receipts using the Send API, to let users know you are processing their request.
    /// </summary>
    [JsonObject]
    public class SenderAction
    {
        /// <summary>
        /// Mark last message as read
        /// </summary>
        public const string MARK_SEEN = "mark_seen";
        /// <summary>
        /// Turn typing indicators on
        /// </summary>
        public const string TYPING_INDICATOR_ON = "typing_on";
        /// <summary>
        /// Turn typing indicators off
        /// </summary>
        public const string TYPING_INDICATOR_OFF = "typing_off";

        /// <summary>
        /// The type of sender action being emitted.
        /// </summary>
        [JsonProperty(PropertyName = "sender_action", Required = Required.Always)]
        public string ActionType { get; set; }
    }
}
