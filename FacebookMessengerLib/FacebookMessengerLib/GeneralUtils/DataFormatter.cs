using FacebookMessengerLib.API.Exceptions;
using FacebookMessengerLib.API.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.GeneralUtils
{
    public class DataFormatter
    {
        public byte[] SerializeAndGetBytesOfWebRequestPostData(Dictionary<string, object> parameters = null)
        {
            var postData = SerializeWebRequestParams(parameters);
            var data = Encoding.UTF8.GetBytes(postData);
            return data;
        }

        //TODO delete after testing exception type of BadRequest and other non-typical server exceptions
        public int FormServerApiErrorCode(string serverErrorMessage)
        {
            if (serverErrorMessage.Contains("400"))
            {
                return 400;
            }

            return 0;
        }

        //TODO if sending subscribeApp request get success: true response 
        //what to do in this situation
        public ApiResponse<T> ParseResponseString<T>(string responseString)
        {
            try
            {
                var responseObject = JsonConvert.DeserializeObject<ApiResponse<T>>(responseString);
                return responseObject;
            }
            catch (Exception e)
            {
                throw new ApiRequestException(e.Message);
            }
        }

        private string SerializeWebRequestParams(Dictionary<string, object> parameters)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var postData = JsonConvert.SerializeObject(parameters, Newtonsoft.Json.Formatting.None, serializerSettings);

            return postData;
        }
    }
}
