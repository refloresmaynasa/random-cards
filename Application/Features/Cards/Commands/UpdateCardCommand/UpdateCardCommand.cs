using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Cards.Commands.UpdateCardCommand
{
    public class UpdateCardCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public int CatalogId { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public Attribute Info { get; set; }
        public List<Attribute> Back { get; set; }
    }
}
