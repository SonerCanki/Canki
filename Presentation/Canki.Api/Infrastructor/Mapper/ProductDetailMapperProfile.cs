using AutoMapper;
using Canki.Common.DTOs.ProductDetail;
using Canki.Common.Extensions;
using Canki.Model.Entities;

namespace Canki.Api.Infrastructor.Mapper
{
    public class ProductDetailMapperProfile:Profile
    {
        public ProductDetailMapperProfile()
        {
            CreateMap<ProductDetail, ProductDetailRequest>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, ProductDetailResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
