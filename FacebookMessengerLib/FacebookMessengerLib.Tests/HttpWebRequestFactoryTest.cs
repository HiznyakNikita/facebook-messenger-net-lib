using FacebookMessengerLib.GeneralUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.Tests
{
    [TestClass]
    public class HttpWebRequestFactoryTest
    {
        private HttpWebRequestFactory _factory;

        [TestInitialize]
        public void Init()
        {
            _factory = new HttpWebRequestFactory();
        }

        [TestMethod]
        public void Create_GetRequest_Correct()
        {
            var request = _factory.Create(
                "http://fakeurl.com",
                new Dictionary<string, object>()
                {
                    {"param","test"}
                },
                "GET");
            Assert.IsNotNull(request);
            Assert.AreEqual("http://fakeurl.com/", request.RequestUri.AbsoluteUri);
            Assert.AreEqual(-1, request.ContentLength);
        }

        [TestMethod]
        public void Create_PostRequest_Correct()
        {
            var request = _factory.Create(
                "http://fakeurl.com",
                new Dictionary<string, object>()
                {
                    {"param","test"}
                });
            Assert.IsNotNull(request);
            Assert.AreEqual("http://fakeurl.com/", request.RequestUri.AbsoluteUri);
            Assert.AreNotEqual(0, request.ContentLength);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void Create_InvalidUrlRequest_ThrowsUriFormatException()
        {
            var request = _factory.Create(
                "http:/fakeurl.com",
                new Dictionary<string, object>()
                {
                    {"param","test"}
                });
        }
    }
}
