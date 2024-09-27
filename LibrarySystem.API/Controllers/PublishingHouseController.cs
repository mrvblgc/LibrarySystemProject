using AutoMapper;
using LibrarySystem.Business.IService;
using LibrarySystem.Business.Service;
using LibrarySystem.DTO.DTOS.PublishingHouseDTOS;
using LibrarySystem.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishingHouseController(IPublishingHouseService _publishinHouseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var publishHouseList = _publishinHouseService.TGetList();
            return Ok(publishHouseList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publishHouseInfo = _publishinHouseService.TGetById(id);
            return Ok(publishHouseInfo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _publishinHouseService.TDelete(id);
            if (result)
            {
                return Ok("YayınEvi Silindi.");
            }
            return Ok("YayınEvi silinemedi!");
        }

        [HttpPost]
        public IActionResult Create(CreatePublishingHouseDto publishHouseDto)
        {
            var model = _mapper.Map<PublishingHouse>(publishHouseDto);
            var result = _publishinHouseService.TCreate(model);
            if (result)
            {
                return Ok("Yeni YayınEvi Eklendi.");
            }
            return Ok("Yeni YayınEvi eklenemedi!");
        }

        [HttpPut]
        public IActionResult Update(UpdatePublishingHouseDto publishHouseDto)
        {
            var model = _mapper.Map<PublishingHouse>(publishHouseDto);
            var result = _publishinHouseService.TUpdate(model);
            if (result)
            {
                return Ok("YayınEvi Güncellendi.");
            }
            return Ok("YayınEvi güncellenemedi!");
        }

        [HttpGet("GetPublishingHouseName")]
        public IActionResult GetPublishingHouseName(string publishHouseName)
        {
            var publishHouseInfo = _publishinHouseService.TGetByPublishingHouseName(publishHouseName);
            return Ok(publishHouseInfo);
        }
    }
}
