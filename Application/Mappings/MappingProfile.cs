using Application.DTOs;
using Application.Features.Catalogs.Commands.CreateCatalogCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Commands
            CreateMap<CreateCatalogCommand, Catalog>();
            #endregion

            #region DTOs
            CreateMap<Catalog, CatalogDto>();
            #endregion
        }
    }
}
