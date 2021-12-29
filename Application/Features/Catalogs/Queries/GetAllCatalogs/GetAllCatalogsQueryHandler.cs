using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalogs.Queries.GetAllCatalogs
{
    public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, Response<List<CatalogDto>>>
    {
        private readonly ISqlRepositoryAsync<Catalog> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCatalogsQueryHandler(ISqlRepositoryAsync<Catalog> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<CatalogDto>>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            var catalogs = await _repositoryAsync.ListAsync(cancellationToken);
            var catalogsDto = _mapper.Map<List<CatalogDto>>(catalogs);

            return new Response<List<CatalogDto>>(catalogsDto);
        }
    }
}
