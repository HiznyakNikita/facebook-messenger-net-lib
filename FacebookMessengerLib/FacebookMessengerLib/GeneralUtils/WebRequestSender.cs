using FacebookMessengerLib.API.Exceptions;
using FacebookMessengerLib.API.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.GeneralUtils
{
    /// <summary>
    /// General methods for work with API
    /// Contains not specific oriented methods
    /// </summary>
    public class WebRequestSender
    {
        private string _baseUrl = "";
        private string _token = "";
        private DataFormatter _dataFormatter;

        public WebRequestSender(string baseUrl, string token)
        {
            _baseUrl = baseUrl;
            _token = token;
            _dataFormatter = new DataFormatter();
        }

        public async Task<T> SendWebRequestAsync<T>(
            string method = "POST", 
            Dictionary<string, object> parameters = null)
        {
            try
            {
                var request = CreateWebRequest(parameters, method);

                var response = (HttpWebResponse)(await request.GetResponseAsync());
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var responseObject = _dataFormatter.ParseResponseString<T>(responseString);
                return responseObject.Result;
            }
            //TODO catch non-general exception for Bad Requests
            catch (Exception e)
            {
                int errorCode = _dataFormatter.FormServerApiErrorCode(e.Message);
                if (errorCode != 0)
                    throw new ApiRequestException(e.Message, errorCode);
                else throw;
            }
        }

        private HttpWebRequest CreateWebRequest(Dictionary<string, object> parameters = null, string method = "POST")
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_baseUrl + _token);
                request.Method = method;
                request.ContentType = "application/json";
                if (method == "POST")
                {
                    var postData = _dataFormatter.FormWebRequestPostData(parameters);
                    request.ContentLength = postData.Length;
                    using (var stream = request.GetRequestStream())
                        stream.Write(postData, 0, postData.Length);
                }

                return request;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
