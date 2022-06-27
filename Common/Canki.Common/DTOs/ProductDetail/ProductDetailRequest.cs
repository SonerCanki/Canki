using Canki.Common.DTOs.Base;
using Canki.Common.DTOs.Product;
using System;

namespace Canki.Common.DTOs.ProductDetail
{
    public class ProductDetailRequest:BaseDto
    {
        public string Detail { get; set; }
        public string ExtraDetail { get; set; }
        public Guid ProductRequestId { get; set; }
        public ProductRequest ProductRequest { get; set; }
    }
}
