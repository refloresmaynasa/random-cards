using Application.Wrappers;
using MediatR;

namespace Application.Features.Catalogs.Commands.CreateCatalogCommand
{
    public class CreateCatalogCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}
