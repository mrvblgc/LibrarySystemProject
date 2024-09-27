using AutoMapper;
using LibrarySystem.DTO.DTOS.UserRoleDTOS;
using LibrarySystem.Entity.Model;

namespace LibrarySystem.API.Mapping
{
    public class UserRoleMapping :Profile
    {
        public UserRoleMapping()
        {
            CreateMap<CreateUserRoleDto, UserRole>().ReverseMap();
            CreateMap<UpdateUserRoleDto, UserRole>().ReverseMap();
            
        }
    }
}
