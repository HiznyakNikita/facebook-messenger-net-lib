using FacebookMessengerLib.API.Exceptions;
using FacebookMessengerLib.API.Types;
using FacebookMessengerLib.API.Types.Attachments;
using FacebookMessengerLib.GeneralUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMessengerLib.Tests
{
    [TestClass]
    public class DataFormatterTest
    {
        private DataFormatter _formatter;

        [TestInitialize]
        public void Init()
        {
            _formatter = new DataFormatter();
        }

        [TestMethod]
        public void SerializeAndGetBytesOfWebRequestPostDataTest_TextMessageFormatting_IsCorrect()
        {
            Message message = new Message() { Text = "TestText" };
            byte[] data = _formatter.SerializeAndGetBytesOfWebRequestPostData(new Dictionary<string, object>() 
            {
                {"message", message}
            });
            
            string formattedData = System.Text.Encoding.Default.GetString(data);
            var dictFromFormattedData = JsonConvert.DeserializeObject<Dictionary<string,Message>>(formattedData);

            Assert.AreEqual(1, dictFromFormattedData.Count);
            Assert.AreEqual("testtext", ((Message)dictFromFormattedData["message"]).Text);
        }

        [TestMethod]
        public void SerializeAndGetBytesOfWebRequestPostDataTest_MessageWithAttachmentFormatting_IsCorrect()
        {
            Message message = new Message()
            {
                Text = "TestText",
                Attachment = new Attachment(AttachmentType.Template, new ButtonTemplate("Test", new List<MessageButton>()
                {
                    new MessageButton(MessageButtonType.Postback,"TestTitle1"),
                    new MessageButton(MessageButtonType.Postback,"TestTitle2")
                }))
            };
            byte[] data = _formatter.SerializeAndGetBytesOfWebRequestPostData(new Dictionary<string, object>() 
            {
                {"message", message}
            });
            
            Assert.AreNotEqual(0,data.Length);
        }

        [TestMethod]
        public void FormServerApiErrorCode_BadRequestResponse_IsCorrect()
        {
            int errorCode = _formatter.FormServerApiErrorCode("Bad Request 400 : Server test error");
            Assert.AreEqual(400, errorCode);
        }

        [TestMethod]
        public void FormServerApiErrorCode_AnyErrorDifferentFromBadRequestResponse_IsCorrect()
        {
            int errorCode = _formatter.FormServerApiErrorCode("Error Server 200 : Server test error");
            Assert.AreEqual(0, errorCode);
        }

        [TestMethod]
        public void ParseResponseString_StandartResponseParsing_IsCorrect()
        {
            string responseJson = "{ \"recipient_id\": \"10083\", \"message_id\": \"339\"}";
            
            ApiResponse<string> response = _formatter.ParseResponseString<string>(responseJson);

            Assert.AreEqual(response.RecipientId, 10083);
            Assert.AreEqual(response.MessageId, 339);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiRequestException))]
        public void ParseResponseString_WrongResponseJsonParsing_ThrowingApiRequestException()
        {
            string responseJson = "{\"error_data\" \"error wrong data\" } }";

            ApiResponse<string> response = _formatter.ParseResponseString<string>(responseJson);
        }

        [TestMethod]
        public void ParseResponseString_ErrorResponseParsing_IsCorrect()
        {
            string responseJson = "{ \"error\": { \"message\": \"Invalid OAuth access token.\", \"type\": \"OAuthException\", \"code\": 190, \"fbtrace_id\": \"BLBz/WZt8dN\", \"error_data\": \"test data\" } }";

            ApiResponse<string> response = _formatter.ParseResponseString<string>(responseJson);
            Assert.AreEqual(190, response.Error.ErrorCode);
        }
    }
}
