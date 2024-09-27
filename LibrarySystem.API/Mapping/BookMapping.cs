using AutoMapper;
using LibrarySystem.DTO.DTOS.BookDTOS;
using LibrarySystem.Entity.Model;

namespace LibrarySystem.API.Mapping
{
    public class BookMapping:Profile
    {
        public BookMapping()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
            CreateMap<BookAuthorExcelDto, Book>().ReverseMap();
            CreateMap<V_GetBookInfoDto, V_GetBookInfoDto>().ReverseMap();
            
        }
    }
}
