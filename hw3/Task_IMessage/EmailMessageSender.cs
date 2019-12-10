using Microsoft.AspNetCore.Http;

namespace Task_IMessage
{
    public class EmailMessageSender: IMessageSender
    {
        private string _message;
        public EmailMessageSender(HttpContext context)
        {
            _message = context.Session.GetString("text");
        }
        public string Send()
        {
            return _message == null ? "Text is empty" : _message;
        }
    }
}