using Application.Wrappers;
using MediatR;

namespace Application.Features.Catalogs.Commands.DeleteCatalogCommand
{
    public class DeleteCatalogCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
