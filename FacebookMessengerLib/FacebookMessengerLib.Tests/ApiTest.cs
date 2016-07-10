using FacebookMessengerLib.GeneralUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.Tests
{
    [TestClass]
    public class ApiTest
    {
        private MessengerAPI _api;
        private Mock<HttpWebRequest> _httpRequestSenderMock;
        private Mock<IHttpWebRequestFactory> _httpRequestFactoryMock;

        [TestInitialize]
        public void Init()
        {
            _httpRequestSenderMock = new Mock<HttpWebRequest>();
            _httpRequestFactoryMock = new Mock<IHttpWebRequestFactory>();
            _api = new MessengerAPI("test_token", _httpRequestFactoryMock.Object);
            Mock<HttpWebResponse> responseMock = new Mock<HttpWebResponse>();
            _httpRequestSenderMock.Setup(r => r.GetResponseAsync()).ReturnsAsync(responseMock.Object);
            _httpRequestFactoryMock.Setup(f => f.Create(
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                It.IsAny<string>()))
                .Returns(_httpRequestSenderMock.Object);
        }

        [TestMethod]
        public void SendTextMessageAsync_Test()
        {
            _api.SendTextMessageAsync(123, "test");

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void SendButtonTemplateMessageAsync_Test()
        {
            _api.SendButtonTemplateMessageAsync(123, "test", new List<API.Types.Attachments.MessageButton>()
                {
                    new API.Types.Attachments.MessageButton()
                });

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void SendGenericTemplateMessageAsync_Test()
        {
            _api.SendGenericTemplateMessageAsync(123, new List<API.Types.Attachments.Parts.GenericTemplateElement>()
                {
                    new API.Types.Attachments.Parts.GenericTemplateElement(
                        "title",
                        new List<API.Types.Attachments.MessageButton>()
                        {
                            new API.Types.Attachments.MessageButton()
                        })
                });

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void SendReceiptTemplateMessageAsync_Test()
        {
            _api.SendReceiptTemplateMessageAsync(123, new API.Types.Attachments.ReceiptTemplate(
                "recipient",
                "213123", 
                "UAH",
                "Card",
                new List<API.Types.Attachments.Parts.ReceiptTemplateElement>()
                {
                    new FacebookMessengerLib.API.Types.Attachments.Parts.ReceiptTemplateElement()
                },
                new API.Types.Attachments.Parts.ReceiptTemplateSummary()));

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void SendWelcomeMessageAsync_Test()
        {
            _api.SendWelcomeMessageAsync(new API.Types.WelcomeMessage());

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void DeleteWelcomeMessageAsync_Test()
        {
            _api.SendWelcomeMessageAsync(new API.Types.WelcomeMessage());

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void GetUserProfileDataAsync_Test()
        {
            _api.GetUserProfileDataAsync(12);

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }

        [TestMethod]
        public void SubscibeAppToPageAsync_Test()
        {
            _api.SubscibeAppToPageAsync("ttttt");

            _httpRequestSenderMock.Verify(r => r.GetResponseAsync());
        }
    }
}
