using FacebookMessengerLib.API.Types;
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
        public async Task<T> SendWebRequestAsync<T>(string method, Dictionary<string, object> parameters = null)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_baseUrl + _token);
                var postData = JsonConvert.SerializeObject(parameters, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                                DefaultValueHandling = DefaultValueHandling.Ignore
                            }).ToLower();
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
                var responseObject = JsonConvert.DeserializeObject<ApiResponse<T>>(responseString);

                return responseObject.Result;
            }
            catch (Exception e)
            {
                int errorCode = GetServerApiErrorCode(e.Message);
                if (errorCode != 0)
                    throw new ApiError(errorCode);
                else throw;
            }
        }

        private int GetServerApiErrorCode(string serverErrorMessage)
        {
            if (serverErrorMessage.Contains("400"))
                return 400;
            else
                return 0;
        }
    }
}
