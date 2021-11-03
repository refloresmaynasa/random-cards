using Application.Wrappers;
using MediatR;

namespace Application.Features.Catalogs.Commands.UpdateCatalogCommand
{
    public class UpdateCatalogCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}
