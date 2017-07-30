using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.GeneralUtils
{
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {
        private DataFormatter _dataFormatter;

        public HttpWebRequestFactory()
        {
            _dataFormatter = new DataFormatter();
        }

        public HttpWebRequest Create(string url, Dictionary<string, object> parameters = null, string method = "POST")
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.ContentType = "application/json; charset=utf-8";
                if (method == "POST")
                {
                    var postData = _dataFormatter.SerializeAndGetBytesOfWebRequestPostData(parameters);
                    request.ContentLength = postData.Length;
                    using (var stream = request.GetRequestStream())
                        stream.Write(postData, 0, postData.Length);
                }

                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
