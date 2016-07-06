using FacebookMessengerLib.API.Exceptions;
using FacebookMessengerLib.GeneralUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.Tests
{
    [TestClass]
    public class WebRequestSenderTest
    {
        private Mock<IHttpWebRequestFactory> _httpWebRequestFactoryMock;
        private WebRequestSender _requestSender;
        private MemoryStream _responseStream;

        [TestInitialize]
        public void Init()
        {
            _httpWebRequestFactoryMock = new Mock<IHttpWebRequestFactory>();
            _requestSender = new WebRequestSender(_httpWebRequestFactoryMock.Object);

            var expected = "{ \"result\" : \"test value\" }";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            _responseStream = new MemoryStream();
            _responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            _responseStream.Seek(0, SeekOrigin.Begin);
        }

        [TestMethod]
        public async Task SendWebRequestAsync_SendGetRequest_IsCorrect()
        {
            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(_responseStream);

            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseAsync()).ReturnsAsync(response.Object);
            var parameters = new Dictionary<string, object>()
            {
                {"param","test_value"}
            };

            _httpWebRequestFactoryMock.Setup(c => c.Create(It.IsAny<string>(),parameters,"GET"))
                .Returns(request.Object);

            var actualRequest = _httpWebRequestFactoryMock.Object.Create("http://www.google.com",parameters,"GET");

            string actual;

            actual = await _requestSender.SendWebRequestAsync<string>("http://www.google.com", "GET", parameters);
            Assert.IsNotNull(actual);
            Assert.AreEqual("test value", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiRequestException))]
        public async Task SendWebRequestAsync_SendRequestWithWrongUrl_ThrowAnyException()
        {
            var response = new Mock<WebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(_responseStream);

            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseAsync()).ReturnsAsync(response.Object);
            var parameters = new Dictionary<string, object>()
            {
                {"param","test_value"}
            };

            _httpWebRequestFactoryMock.Setup(c => c.Create(It.IsAny<string>(), parameters, It.IsAny<string>()))
                .Returns(request.Object);

            var actualRequest = _httpWebRequestFactoryMock.Object.Create("http://www.google.com", parameters);

            string actual;

            actual = await _requestSender.SendWebRequestAsync<string>("http://www.google.com", "POST", parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiRequestException))]
        public async Task SendWebRequestAsync_SendWrongRequest_ThrowBadRequestException()
        {
            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Throws(new Exception("Bad Request: 400"));

            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponse()).Returns(response.Object);
            var parameters = new Dictionary<string, object>()
            {
                {"param","test_value"}
            };

            _httpWebRequestFactoryMock.Setup(c => c.Create(It.IsAny<string>(), parameters, It.IsAny<string>()))
                .Returns(request.Object);

            var actualRequest = _httpWebRequestFactoryMock.Object.Create("http://www.google.com", parameters);

            string actual;

            actual = await _requestSender.SendWebRequestAsync<string>("http://www.google.com", "POST", parameters);
        }
    }
}
