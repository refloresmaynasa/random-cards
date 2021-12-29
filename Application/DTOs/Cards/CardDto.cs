using System;
using System.Collections.Generic;

namespace Application.DTOs.Cards
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Catalog { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public AttributeDto Info { get; set; }
        public List<AttributeDto> Back { get; set; }
    }
}
