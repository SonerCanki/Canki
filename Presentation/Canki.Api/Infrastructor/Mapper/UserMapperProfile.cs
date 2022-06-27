using AutoMapper;
using Canki.Common.DTOs.User;
using Canki.Common.Extensions;
using Canki.Model.Entities;

namespace Canki.Api.Infrastructor.Mapper
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
