using AutoMapper;
using LibrarySystem.DTO.DTOS.UserInfoDTOS;
using LibrarySystem.Entity.Model;

namespace LibrarySystem.API.Mapping
{
    public class UserInfoMapping : Profile
    {
        public UserInfoMapping()
        {
            CreateMap<UserInfoDto, UserInfo>().ReverseMap();
            CreateMap<CreateUserInfoDto, UserInfo>().ReverseMap();
            CreateMap<UpdateUserInfoDto, UserInfo>().ReverseMap();
            CreateMap<UserLoginDto, UserInfo>().ReverseMap();
            
        }
    }
}
