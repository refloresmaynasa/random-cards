using Application.DTOs;
using Application.DTOs.Cards;
using Application.Features.Cards.Commands.CreateCardCommand;
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
            CreateMap<CreateCardCommand, Card>();
            #endregion

            #region DTOs
            CreateMap<Catalog, CatalogDto>();
            CreateMap<Card, CardDto>();
            CreateMap<AttributeDto, Attribute>();
            #endregion
        }
    }
}
