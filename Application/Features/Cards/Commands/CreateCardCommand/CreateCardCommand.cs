using Application.DTOs.Cards;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Cards.Commands.CreateCardCommand
{
    public class CreateCardCommand : IRequest<Response<Guid>>
    {
        public int CatalogId { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public AttributeDto Info { get; set; }
        public List<AttributeDto> Back { get; set; }
    }
}
