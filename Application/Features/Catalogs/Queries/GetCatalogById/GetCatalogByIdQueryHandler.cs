using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalogs.Queries.GetCatalogById
{
    public class GetCatalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, Response<CatalogDto>>
    {
        private readonly IRepositoryAsync<Catalog> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCatalogByIdQueryHandler(IRepositoryAsync<Catalog> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<CatalogDto>> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);
            if (catalog == null)
            {
                throw new KeyNotFoundException($"Catalog not found with Id {request.Id}");
            }
            else
            {
                var catalogDto = _mapper.Map<CatalogDto>(catalog);
                return new Response<CatalogDto>(catalogDto);
            }
        }
    }
}
