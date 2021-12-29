using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalogs.Commands.DeleteCatalogCommand
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, Response<int>>
    {
        private readonly ISqlRepositoryAsync<Catalog> _repositoryAsync;

        public DeleteCatalogCommandHandler(ISqlRepositoryAsync<Catalog> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);
            if (catalog == null)
            {
                throw new KeyNotFoundException($"Catalog not found with Id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(catalog, cancellationToken);
                return new Response<int>(catalog.Id);
            }
        }
    }
}
