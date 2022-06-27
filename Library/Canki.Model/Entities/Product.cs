using Canki.Core.Entity;
using System;
using System.Collections.Generic;

namespace Canki.Model.Entities
{
    public class Product:CoreEntity
    {

        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public string Name { get; set; }
        public string Barcode { get; set; }
        public double ProductPrice { get; set; }
        public double? Tax { get; set; }
        public double? StockAmount { get; set; }
        public double? Discount { get; set; }
        public bool? DiscountType { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
