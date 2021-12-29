using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Card
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Catalog { get; set; }
        public string Title { get; set; }
        public Attribute Info { get; set; }
        public string UrlImage { get; set; }
        public ICollection<Attribute> Back { get; set; }
        public string UserName { get; set; }

        // Audit fields
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
