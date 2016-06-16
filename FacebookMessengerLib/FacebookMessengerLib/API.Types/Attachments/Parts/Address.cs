using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.API.Types.Attachments.Parts
{
    [JsonObject]
    public class Address
    {
        [JsonProperty(PropertyName = "street_1", Required = Required.Always)]
        public string FirstStreetName { get; set; }
        [JsonProperty(PropertyName = "street_2", Required = Required.Always)]
        public string SecondStreetName { get; set; }
        [JsonProperty(PropertyName = "city", Required = Required.Always)]
        public string City { get; set; }
        [JsonProperty(PropertyName = "postal_code", Required = Required.Always)]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "state", Required = Required.Always)]
        public string State { get; set; }
        [JsonProperty(PropertyName = "country", Required = Required.Always)]
        public string Country { get; set; }
    }
}
