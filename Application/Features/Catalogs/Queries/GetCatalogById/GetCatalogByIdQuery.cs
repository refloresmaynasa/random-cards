using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Catalogs.Queries.GetCatalogById
{
    public class GetCatalogByIdQuery : IRequest<Response<CatalogDto>>
    {
        public int Id { get; set; }
    }
}
