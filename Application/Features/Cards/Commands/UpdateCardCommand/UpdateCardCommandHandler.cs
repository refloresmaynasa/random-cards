using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cards.Commands.UpdateCardCommand
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, Response<string>>
    {
        private readonly INoSqlRepositoryAsync<Card> _repositoryAsync;
        private readonly ISqlRepositoryAsync<Catalog> _catalogRepositoryAsync;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public UpdateCardCommandHandler(INoSqlRepositoryAsync<Card> repositoryAsync, ISessionService sessionService,
            ISqlRepositoryAsync<Catalog> catalogRepositoryAsync, IMapper mapper)
        {
            _sessionService = sessionService;
            _repositoryAsync = repositoryAsync;
            _catalogRepositoryAsync = catalogRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);

            if (card == null)
            {
                throw new KeyNotFoundException($"Card not found with Id {request.Id}");
            }
            else
            {
                var catalog = await _catalogRepositoryAsync.GetByIdAsync(request.CatalogId, cancellationToken);
                if (catalog == null)
                {
                    throw new KeyNotFoundException($"Catalog not found with Id {request.CatalogId}");
                }
                card.Catalog = catalog.ToString();
                card.Info = _mapper.Map<Attribute>(request.Info);
                card.Back = _mapper.Map<List<Attribute>>(request.Back);
                card.Title = request.Title;
                card.UrlImage = request.UrlImage;
                card.UserName = _sessionService.CurrentUserName;

                await _repositoryAsync.UpdateAsync(card, cancellationToken);
                return new Response<string>(card.Id.ToString());
            }
        }
    }
}
