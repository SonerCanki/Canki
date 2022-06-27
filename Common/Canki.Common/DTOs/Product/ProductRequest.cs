using Canki.Common.DTOs.Base;
using Canki.Common.DTOs.ProductDetail;
using System.Collections.Generic;

namespace Canki.Common.DTOs.Product
{
    public class ProductRequest : BaseDto
    {
        public ProductRequest()
        {
            ProductDetailRequests = new HashSet<ProductDetailRequest>();
        }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public double? Tax { get; set; }
        public double? StockAmount { get; set; }
        public double? Discount { get; set; }
        public bool? DiscountType { get; set; }

        public ICollection<ProductDetailRequest> ProductDetailRequests { get; set; }
    }
}
