using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Catalogs.Queries.GetAllCatalogs
{
    public class GetAllCatalogsQuery : IRequest<Response<List<CatalogDto>>>
    {
    }
}
