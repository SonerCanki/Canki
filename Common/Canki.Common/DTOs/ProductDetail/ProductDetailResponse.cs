using Canki.Common.DTOs.Base;
using Canki.Common.DTOs.Product;
using System;

namespace Canki.Common.DTOs.ProductDetail
{
    public class ProductDetailResponse:BaseDto
    {
        public string Detail { get; set; }
        public string ExtraDetail { get; set; }
        public Guid ProducResponsetId { get; set; }
        public ProductResponse ProductResponse { get; set; }
    }
}
