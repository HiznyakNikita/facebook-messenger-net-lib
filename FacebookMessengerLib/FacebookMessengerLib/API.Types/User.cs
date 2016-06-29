using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types
{
    public class User
    {
        [JsonProperty(PropertyName = "first_name", Required = Required.Default)]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name", Required = Required.Default)]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "profile_pic", Required = Required.Default)]
        public string ProfilePicture { get; set; }
        [JsonProperty(PropertyName = "locale", Required = Required.Default)]
        public string Locale { get; set; }
        [JsonProperty(PropertyName = "timezone", Required = Required.Default)]
        public string Timezone { get; set; }
        [JsonProperty(PropertyName = "gender", Required = Required.Default)]
        public string Gender { get; set; }
    }
}
