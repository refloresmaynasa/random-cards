using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalogs.Commands.UpdateCatalogCommand
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, Response<int>>
    {
        private readonly ISqlRepositoryAsync<Catalog> _repositoryAsync;

        public UpdateCatalogCommandHandler(ISqlRepositoryAsync<Catalog> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);

            if (catalog == null)
            {
                throw new KeyNotFoundException($"Catalog not found with Id {request.Id}");
            }
            else
            {
                catalog.Name = request.Name;
                catalog.Description = request.Description;
                catalog.IsPublic = request.IsPublic;

                await _repositoryAsync.UpdateAsync(catalog, cancellationToken);
                return new Response<int>(catalog.Id);
            }
        }
    }
}
