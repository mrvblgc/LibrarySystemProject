using AutoMapper;
using DocumentFormat.OpenXml.ExtendedProperties;
using LibrarySystem.Business.IService;
using LibrarySystem.Business.Service;
using LibrarySystem.DTO.DTOS.UserInfoDTOS;
using LibrarySystem.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userInfoList = _userService.TGetList();
            return Ok(userInfoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userInfoInfo = _userService.TGetById(id);
            return Ok(userInfoInfo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.TDelete(id);
            if (result)
            {
                return Ok("Kullanıcı Silindi.");
            }
            return Ok("Kullanıcı silinemedi!");
        }

        [HttpPost]
        public IActionResult Create(CreateUserInfoDto userInfoDto)
        {
            var model = _mapper.Map<UserInfo>(userInfoDto);
            var result = _userService.TCreate(model);
            if (result)
            {
                return Ok("Yeni kullanıcı Eklendi.");
            }
            return Ok("Yeni kullanıcı eklenemedi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateUserInfoDto userInfoDto)
        {
            var model = _mapper.Map<UserInfo>(userInfoDto);
            var result = _userService.TUpdate(model);
            if (result)
            {
                return Ok("Kullanıcı Güncellendi.");
            }
            return Ok("Kullanıcı güncellenemedi!");
        }

        [HttpPost("UserInfoByEmailPassword")]
        public IActionResult UserInfoByEmailPassword(UserLoginDto userDto)
        {
            var model = _mapper.Map<UserInfo>(userDto);
            var userInfo = _userService.TGetByEmailPassword(model.Email, model.Password);
            if (userInfo != null)
            {
                return Ok(userInfo);
            }
            return BadRequest("Kullanıcı Adı ya da şifre hatalı");
        }

    }
}
