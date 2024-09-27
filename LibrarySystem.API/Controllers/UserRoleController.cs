using AutoMapper;
using LibrarySystem.Business.IService;
using LibrarySystem.Business.Service;
using LibrarySystem.DTO.DTOS.UserRoleDTOS;
using LibrarySystem.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController(IUserRoleService _userRoleService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userInfoList = _userRoleService.TGetList();
            return Ok(userInfoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userRoleInfo = _userRoleService.TGetById(id);
            return Ok(userRoleInfo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userRoleService.TDelete(id);
            if (result)
            {
                return Ok("Kullanıcı Rolü Silindi.");
            }
            return Ok("Kullanıcı Rolü silinemedi!");
        }

        [HttpPost]
        public IActionResult Create(CreateUserRoleDto userRoleDto)
        {
            var model = _mapper.Map<UserRole>(userRoleDto);
            var result = _userRoleService.TCreate(model);
            if (result)
            {
                return Ok("Yeni kullanıcı rolü Eklendi.");
            }
            return Ok("Yeni kullanıcı rolü eklenemedi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateUserRoleDto userRoleDto)
        {
            var model = _mapper.Map<UserRole>(userRoleDto);
            var result = _userRoleService.TUpdate(model);
            if (result)
            {
                return Ok("Kullanıcı Rolü Güncellendi.");
            }
            return Ok("Kullanıcı Rolü güncellenemedi!");
        }

      
    }
}
