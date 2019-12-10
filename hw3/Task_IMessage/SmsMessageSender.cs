using Microsoft.AspNetCore.Http;

namespace Task_IMessage
{
    public class SmsMessageSender : IMessageSender
    {
        private string _message;
        public SmsMessageSender(HttpContext context)
        {
            _message = context.Request.Cookies["text"];
        }

        public string Send()
        {
            return _message == null ? "Text is empty" : _message;
        }
    }
}