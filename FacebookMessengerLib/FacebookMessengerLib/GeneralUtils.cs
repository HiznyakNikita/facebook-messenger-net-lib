using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib
{
    /// <summary>
    /// General methods for work with API
    /// Contains not specific oriented methods
    /// </summary>
    public class GeneralUtils
    {
        private string _baseUrl = "";
        private string _token = "";

        public GeneralUtils(string baseUrl, string token)
        {
            _baseUrl = baseUrl;
            _token = token;
        }

        //TODO: Use ApiResponse.Result as returned type
        //Use custom types in operations
        public async Task<string> SendWebRequestAsync(string method, Dictionary<string, object> parameters = null)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_baseUrl + _token);
                var postData = JsonConvert.SerializeObject(parameters).ToLower();
                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)(await request.GetResponseAsync());
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (Exception e) 
            {
                return e.Message;
            }
        }
    }
}
