using AutoMapper;
using Canki.Common.DTOs.Category;
using Canki.Common.Extensions;
using Canki.Model.Entities;

namespace Canki.Api.Infrastructor.Mapper
{
    public class CategoryMapperProfile:Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, CategoryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
