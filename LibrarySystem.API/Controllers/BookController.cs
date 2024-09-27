using AutoMapper;
using ClosedXML.Excel;
using LibrarySystem.Business.IService;
using LibrarySystem.Business.Service;
using LibrarySystem.DTO.DTOS.AuthorDTOS;
using LibrarySystem.DTO.DTOS.BookDTOS;
using LibrarySystem.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService _bookService, IPublishingHouseService _publishinHouseService, IAuthorService _authorService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var bookList = _bookService.TGetList();
            return Ok(bookList);
        }

        [HttpGet("GetBookInfoList")]
        public IActionResult GetBookInfoList()
        {
            var bookList = _bookService.TGetBookInfoList();
            return Ok(bookList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bookInfo = _bookService.TGetById(id);
            return Ok(bookInfo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookService.TDelete(id);
            if (result)
            {
                return Ok("Kitap Silindi.");
            }
            return Ok("Kitap silinemedi!");
        }

        [HttpPost]
        public IActionResult Create(CreateBookDto bookdto)
        {
            var model = _mapper.Map<Book>(bookdto);
            var result = _bookService.TCreate(model);
            if (result)
            {
                return Ok("Yeni kitap Eklendi.");
            }
            return Ok("Yeni kitap eklenemedi!");
        }

        [HttpPost("CreateExcelBook")]
        public IActionResult CreateExcelBook(CreateBookExcelDto bookdto) 
        {
            int publishHouseId = -1;
            var publishingInfo= _publishinHouseService.TGetByPublishingHouseName(bookdto.PublishingHouseName);
            if (publishingInfo == null)
            {
                publishHouseId =_publishinHouseService.TCreateByPublishingHouseName(bookdto.PublishingHouseName);
            }
            else
            {
                publishHouseId = publishingInfo.PublishingHouseId;
            }

            if (publishHouseId == -1)
            {
                return BadRequest("PublishingBook tablosuna kayıt atılamadı!");
            }

            int authorId = -1;
            var authorInfo = _authorService.TGetByAuthorFullName(bookdto.AuthorName, bookdto.AuthorSurname);
            if (authorInfo == null)
            {
                authorId = _authorService.TCreateByAuthorFullName(bookdto.AuthorName, bookdto.AuthorSurname); ;
            }
            else
            {
                authorId = authorInfo.AuthorId;
            }

            if (authorId == -1)
            {
                return BadRequest("Author tablosuna kayıt atılamadı!");
            }

            CreateBookDto bookModel = new CreateBookDto()
            {
                BookName = bookdto.BookName,
                BookPrice = bookdto.BookPrice,
                AuthorId = authorId,
                PublishingHouseId = publishHouseId
            };

            bool result = false;
            var model = _mapper.Map<Book>(bookModel);
            var bookInfo = _bookService.TGetByBookName(bookModel.BookName);
            if (bookInfo == null)
            {
                result = _bookService.TCreate(model);
            }

            if (result)
            {
                return Ok("Yeni kitap Eklendi.");
            }
            return Ok("Yeni kitap eklenemedi!");
        }

        [HttpPut]
        public IActionResult Update(UpdateBookDto bookdto)
        {
            var model = _mapper.Map<Book>(bookdto);
            var result = _bookService.TUpdate(model);
            if (result)
            {
                return Ok("Kitap Güncellendi.");
            }
            return Ok("Kitap güncellenemedi!");
        }

        [HttpGet("FindBookName")]
        public IActionResult GetByBookName(string bookName)
        {
            var bookInfo = _bookService.TGetByBookName(bookName);
            if (bookInfo != null)
            {
                return Ok(bookInfo);
            }
            return Ok("Girilen kitap adı Bulunamadı!");
        }

        [HttpPost("ReadExcelFrom_FormData")]
        public async Task<IActionResult> ReadExcelFrom_FormData(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Dosya Boş!");
            }

            List<CreateBookExcelDto> bookAuthorExcelList = new List<CreateBookExcelDto>();

            var data = new List<Dictionary<string, string>>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0; 

                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheets.First();
                    var rows = worksheet.RangeUsed().RowsUsed();

                    var headerRow = rows.First(); 
                    var headers = headerRow.Cells().Select(c => c.Value.ToString()).ToList();

                    foreach (var row in rows.Skip(1))
                    {
                        var rowData = new Dictionary<string, string>();
                        foreach (var cell in row.Cells())
                        {
                            BookAuthorExcelDto bookAuthorExcelDto = new BookAuthorExcelDto();
                            var header = headers[cell.Address.ColumnNumber - 1];
                            if (header == "Yazar Adı")
                            {
                                header = "AuthorName";
                            }
                            else if (header == "Yazar Soyadı")
                            {
                                header = "AuthorSurname";
                            }
                            else if (header == "Kitap Adı")
                            {
                                header = "BookName";
                            }
                            else if (header == "Basım Evi")
                            {
                                header = "PublishingHouseName";
                            }
                            else if (header == "Fiyat")
                            {
                                header = "BookPrice";
                            }

                            rowData[header] = cell.Value.ToString();
                        }

                        data.Add(rowData);
                    }
                }
            }

            return Ok(data);  
        }

        [HttpGet("GetBookFullInfoList")]
        public IActionResult GetBookFullInfoList()
        {
            var bookList = _bookService.TGetList();

            List<V_GetBookInfoDto> bookDtoList = new List<V_GetBookInfoDto>();

            foreach (var item in bookList)
            {
                V_GetBookInfoDto model = new V_GetBookInfoDto();
                var authorInfo = _authorService.TGetById(item.AuthorId);
                var fullAuthorName = authorInfo.AuthorName + authorInfo.AuthorSurname;

                var publishInfo = _publishinHouseService.TGetById(item.PublishingHouseId);
                var publishingHouse = publishInfo.PublishingHouseName;

                model.AuthorName = authorInfo.AuthorName + " "+ authorInfo.AuthorSurname;
                model.PublishingHouseName = publishingHouse;
                model.BookId = item.BookId;
                model.BookPrice = item.BookPrice;
                model.BookName = item.BookName;
                bookDtoList.Add(model);

            }
            return Ok(_mapper.Map<List<V_GetBookInfoDto>>(bookDtoList));
        }


    }
}
