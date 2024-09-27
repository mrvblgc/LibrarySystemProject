using AutoMapper;
using LibrarySystem.DTO.DTOS.PublishingHouseDTOS;
using LibrarySystem.Entity.Model;

namespace LibrarySystem.API.Mapping
{
    public class PublishingHouseMapping :Profile
    {
        public PublishingHouseMapping()
        {
            CreateMap<PublishingHouseDto, PublishingHouse>().ReverseMap();
            CreateMap<CreatePublishingHouseDto, PublishingHouse>().ReverseMap();
            CreateMap<UpdatePublishingHouseDto, PublishingHouse>().ReverseMap();
            
        }
    }
}
