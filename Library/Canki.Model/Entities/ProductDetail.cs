using Canki.Core.Entity;
using System;

namespace Canki.Model.Entities
{
    public class ProductDetail : CoreEntity
    {
        public string Detail { get; set; }
        public string ExtraDetail { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
