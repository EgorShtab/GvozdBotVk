using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace Domain.Services.MessageFactory
{
    public class BaseMessage : IMessageModel
    {
        public Message Message { get; set; }
        public MessagesSendParams SendParams { get; set; }
    }
}
