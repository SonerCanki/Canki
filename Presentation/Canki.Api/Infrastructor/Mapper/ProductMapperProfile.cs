using AutoMapper;
using Canki.Common.DTOs.Product;
using Canki.Common.Extensions;
using Canki.Model.Entities;

namespace Canki.Api.Infrastructor.Mapper
{
    public class ProductMapperProfile:Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductRequest>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, ProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
