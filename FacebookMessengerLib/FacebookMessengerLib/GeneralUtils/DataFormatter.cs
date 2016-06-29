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
        public byte[] FormWebRequestPostData(Dictionary<string, object> parameters = null)
        {
            try
            {
                var postData = JsonConvert.SerializeObject(parameters, Newtonsoft.Json.Formatting.None,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore,
                                    DefaultValueHandling = DefaultValueHandling.Ignore
                                }).ToLower();
                var data = Encoding.ASCII.GetBytes(postData);
                return data;
            }
            catch (JsonSerializationException e)
            {
                throw e;
            }
        }

        //TODO delete after testing exception type of BadRequest and other non-typical server exceptions
        public int FormServerApiErrorCode(string serverErrorMessage)
        {
            if (serverErrorMessage.Contains("400"))
                return 400;
            else
                return 0;
        }

        public ApiResponse<T> ParseResponseString<T>(string responseString)
        {
            try
            {
                var responseObject = JsonConvert.DeserializeObject<ApiResponse<T>>(responseString);
                return responseObject;
            }
            catch (JsonSerializationException)
            {
                var responseError = JsonConvert.DeserializeObject<ApiError>(responseString);
                throw new ApiRequestException(responseError.Message, responseError);
            }
        }
    }
}
