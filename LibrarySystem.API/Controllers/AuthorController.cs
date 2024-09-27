using AutoMapper;
using LibrarySystem.Business.IService;
using LibrarySystem.DTO.DTOS.AuthorDTOS;
using LibrarySystem.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorService _authorService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var authorList = _authorService.TGetList();
            var model = _mapper.Map<List<AuthorDto>>(authorList);
            return Ok(model);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var authorInfo = _authorService.TGetById(id);
            return Ok(authorInfo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _authorService.TDelete(id);
            if (result)
            {
                return Ok("Yazar Silindi.");
            }
            return Ok("Yazar silinemedi!");
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorDto authordto)
        {
            var model = _mapper.Map<Author>(authordto);
            var result = _authorService.TCreate(model);
            if (result)
            {
                return Ok("Yeni Yazar Eklendi.");
            }
            return Ok("Yeni yazar eklenemedi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateAuthorDto authordto)
        {
            var model = _mapper.Map<Author>(authordto);
            var result = _authorService.TUpdate(model);
            if (result)
            {
                return Ok("Yazar Güncellendi.");
            }
            return Ok("Yazar güncellenemedi!");
        }

        [HttpGet("FindAuthorFullName")]
        public IActionResult GetByAuthorFullName(string authorName, string autherSurname)
        {
            var authorInfo = _authorService.TGetByAuthorFullName(authorName, autherSurname);
            var model = _mapper.Map<AuthorDto>(authorInfo);
            return Ok(model);
        }
    }
}
