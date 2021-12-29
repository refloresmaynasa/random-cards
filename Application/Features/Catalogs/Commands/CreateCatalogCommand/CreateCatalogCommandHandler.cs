using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalogs.Commands.CreateCatalogCommand
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, Response<int>>
    {
        private readonly ISqlRepositoryAsync<Catalog> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;
        public CreateCatalogCommandHandler(ISqlRepositoryAsync<Catalog> repositoryAsync, IMapper mapper, ISessionService sessionService)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _sessionService = sessionService;
        }

        public async Task<Response<int>> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            var newCatalog = _mapper.Map<Catalog>(request);
            newCatalog.UserName = _sessionService.CurrentUserName;
            newCatalog.UserId = _sessionService.CurrentUserId;
            newCatalog.UserEmail = _sessionService.CurrentUserEmail;

            var data = await _repositoryAsync.AddAsync(newCatalog, cancellationToken);

            return new Response<int>(data.Id);
        }
    }
}
