using Domain.Helpers.MessageType;
using Domain.Services;
using Domain.Services.MessageFactory;
using GvozdBotVk.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace GvozdBotVk.Controllers
{
    [Route("api/callback")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly IConfigureSettings _configuration;
        private readonly IVkApi _vkApi;
        private readonly IMediator _mediator;

        public CallbackController(IOptions<ConfigureSettings> configuration, VkApi vkApi, IMediator mediator)
        {
            _configuration = configuration.Value;
            _vkApi = vkApi;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CallbackModel callback)
        {
            if (callback.Type == MessageTypes.confirmation)
            {
                return Ok(_configuration.ConfirmationString);
            }
            if (callback.Type == MessageTypes.newMessage)
            {
                var message = Message.FromJson(new VkResponse(JObject.Parse(callback.Object.ToString())));
                var messageModel = MessageFactory.GetMessageModel(new BaseMessage
                {
                    Message = message,
                    SendParams = new MessagesSendParams
                    {
                        UserId = message.UserId,
                        RandomId = DateTime.Now.Millisecond,
                    }
                });
                await _mediator.Send(messageModel);
            }
            return Ok("ok");
        }
    }
}
