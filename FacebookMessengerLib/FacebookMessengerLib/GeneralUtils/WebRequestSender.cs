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
        private DataFormatter _dataFormatter;
        private IHttpWebRequestFactory _requestFactory;

        public WebRequestSender(IHttpWebRequestFactory factory)
        {
            _dataFormatter = new DataFormatter();
            _requestFactory = factory;
        }

        public async Task<T> SendWebRequestAsync<T>(string url,
            string method = "POST", 
            Dictionary<string, object> parameters = null)
        {
            try
            {
                var request = _requestFactory.Create(url, parameters, method);

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
    }
}
