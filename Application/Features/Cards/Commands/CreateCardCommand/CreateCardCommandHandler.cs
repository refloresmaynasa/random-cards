using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cards.Commands.CreateCardCommand
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Response<Guid>>
    {
        private readonly INoSqlRepositoryAsync<Card> _repositoryAsync;
        private readonly ISqlRepositoryAsync<Catalog> _catalogRepositoryAsync;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;

        public CreateCardCommandHandler(INoSqlRepositoryAsync<Card> repositoryAsync, IMapper mapper, 
            ISessionService sessionService, ISqlRepositoryAsync<Catalog> catalogRepositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _sessionService = sessionService;
            _catalogRepositoryAsync = catalogRepositoryAsync;
        }

        public async Task<Response<Guid>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepositoryAsync.GetByIdAsync(request.CatalogId, cancellationToken);
            if (catalog == null)
            {
                throw new KeyNotFoundException($"Catalog not found with Id {request.CatalogId}");
            }
            var newCard = _mapper.Map<Card>(request);
            newCard.Catalog = catalog.ToString();
            newCard.UserName = _sessionService.CurrentUserName;

            var data = await _repositoryAsync.AddAsync(newCard, cancellationToken);
            return new Response<Guid>(data.Id);
        }
    }
}
