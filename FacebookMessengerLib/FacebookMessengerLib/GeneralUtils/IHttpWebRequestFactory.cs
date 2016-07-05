using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.GeneralUtils
{
    public interface IHttpWebRequestFactory
    {
        HttpWebRequest Create(string url, Dictionary<string, object> parameters = null, string method = "POST");
    }
}
