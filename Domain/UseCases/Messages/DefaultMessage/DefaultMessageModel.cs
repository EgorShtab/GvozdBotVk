using Domain.Output;
using Domain.Services.MessageFactory;
using MediatR;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace Domain.UseCases.Messages.DefaultMessage
{
    public class DefaultMessageModel : BaseMessage, IRequest<ActionOutput>
    {
        public Message Message { get; set; }
        public MessagesSendParams SendParams { get; set; }
    }
}
