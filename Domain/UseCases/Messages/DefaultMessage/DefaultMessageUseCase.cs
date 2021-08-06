using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Output;
using MediatR;
using VkNet;

namespace Domain.UseCases.Messages.DefaultMessage
{
    public class DefaultMessageUseCase : IRequestHandler<DefaultMessageModel, ActionOutput>
    {
        private readonly VkApi _vkApi;

        public DefaultMessageUseCase(VkApi vkApi)
        {
            _vkApi = vkApi;
        }
        public async Task<ActionOutput> Handle(DefaultMessageModel request, CancellationToken cancellationToken)
        {
            request.SendParams.Message = "Привет, напиши свой сайт для SEO аудита.";
            await _vkApi.Messages.SendAsync(request.SendParams);
            return ActionOutput.Success;
        }
    }
}
