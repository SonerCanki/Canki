using Canki.Core.Entity;
using System.Collections.Generic;

namespace Canki.Model.Entities
{
    public class Category:CoreEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
