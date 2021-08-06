using Domain.Helpers.MessageType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UseCases.Messages.DefaultMessage;

namespace Domain.Services.MessageFactory
{
    public class MessageFactory
    {
        public static IMessageModel GetMessageModel(BaseMessage request)
        {
            if (IsURL(request.Message.Body))
                return new DefaultMessageModel 
                {
                    Message = request.Message,
                    SendParams = request.SendParams
                };
            return new DefaultMessageModel 
            {
                Message = request.Message,
                SendParams = request.SendParams
            };
        }

        static bool IsURL(string urlName)
        {
            Uri uriResult;
            return Uri.TryCreate(urlName, UriKind.Absolute, out uriResult) 
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
