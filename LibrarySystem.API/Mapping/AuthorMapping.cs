using AutoMapper;
using LibrarySystem.DTO.DTOS.AuthorDTOS;
using LibrarySystem.Entity.Model;

namespace LibrarySystem.API.Mapping
{
    public class AuthorMapping :Profile
    {
        public AuthorMapping()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
        }
    }
}
