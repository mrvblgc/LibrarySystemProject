using Azure;
using Humanizer.Localisation;
using LibrarySystem.DTO.DTOS;
using LibrarySystem.DTO.DTOS.AuthorDTOS;
using LibrarySystem.DTO.DTOS.BookDTOS;
using LibrarySystem.DTO.DTOS.PublishingHouseDTOS;
using LibrarySystem.Entity.Model;
using LibrarySystem.WEBUI.CustomModel;
using LibrarySystem.WEBUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using static OfficeOpenXml.ExcelErrorValue;

namespace LibrarySystem.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Microsoft.AspNetCore.Mvc.Route("[area]/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        private readonly HttpClient _client = HttpClientIntance.CreateClient();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<V_GetBookInfoDto>>("Book/GetBookFullInfoList");

            var authorList = await _client.GetFromJsonAsync<List<AuthorDto>>("Author");

            var publishHouseList = await _client.GetFromJsonAsync<List<PublishingHouseDto>>("PublishingHouse");

            var tuple = new Tuple<List<V_GetBookInfoDto>, List<AuthorDto>, List<PublishingHouseDto>>(values, authorList, publishHouseList);
            return View(tuple);
        }

        [HttpPost]
        public async Task<List<BookAuthorExcelCustomModel>> LibrarySystemExcelToDB(IFormFile file)
        {
            List<BookAuthorExcelCustomModel> readApiResponse = new List<BookAuthorExcelCustomModel>();
           

            var readFileData = System.IO.File.ReadAllBytes(@"D:\Md Farid Uddin Resume.pdf");
            //Create Multipart Request
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StreamContent(new MemoryStream(readFileData)), "fileUpload", "fileUpload");
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);


            var response = await _client.PostAsJsonAsync("Book/ReadExcelFrom_FormData" ,file);
            if (response.IsSuccessStatusCode)
            {
                var readResponse = await response.Content.ReadAsStringAsync();
                readApiResponse = JsonConvert.DeserializeObject<List<BookAuthorExcelCustomModel>>(readResponse);
            }

            return readApiResponse;
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel([FromForm] IFormFile fileUpload)
        {
            List<string> sheetNames = new List<string>();

            List<CreateBookExcelDto> readApiResponse = new List<CreateBookExcelDto>();
            if (fileUpload == null)
            {
                ViewBag.Message = "File is empty!";
                return View();
            }

            var fileName = ContentDispositionHeaderValue.Parse(fileUpload.ContentDisposition).FileName.Trim('"');

            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(fileUpload.OpenReadStream())
                {
                    Headers =
                    {
                        ContentLength = fileUpload.Length,
                        ContentType = new MediaTypeHeaderValue(fileUpload.ContentType)
                    }
                }, "File", fileName);

                var response = await _client.PostAsync("Book/ReadExcelFrom_FormData", content);
                if (response.IsSuccessStatusCode)
                {
                    var readResponse = await response.Content.ReadAsStringAsync();
                    readApiResponse = JsonConvert.DeserializeObject<List<CreateBookExcelDto>>(readResponse);
                }
            }

            foreach (var item in readApiResponse)
            {
                var deneme = await _client.PostAsJsonAsync<CreateBookExcelDto>("Book/CreateExcelBook", item);
            }

            var test = CreateLibraryInfo(readApiResponse); 

            return View(test);
        }

        public async Task<List<CreateBookExcelDto>> CreateLibraryInfo(List<CreateBookExcelDto> customLibrary)
        {
            List<CreateBookExcelDto> readApiResponse = new List<CreateBookExcelDto>();
            foreach (var item in customLibrary)
            {
                try
                {
                    var test = await _client.PostAsJsonAsync<CreateBookExcelDto>("Book/CreateExcelBook", item);


                    }
                    catch (Exception ex)
                    {
                        var innerExMessage = ex.InnerException == null ? "" : ex.InnerException.Message;
                        throw ex;
                    }
            }

            return customLibrary;

        }

        public async Task<bool> DeleteBook(int id)
        {
            var result = await _client.DeleteAsync("Book/" + id);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public async Task<UpdateBookDto> UpdateBookInfo(int id)
        {
            ViewBag.BookId = id;
            var value = await _client.GetFromJsonAsync<UpdateBookDto>("Book/" + id);
            return value;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookFullInfo(UpdateBookDto updateBookDto)
        {
            await _client.PutAsJsonAsync("Book", updateBookDto);
            return RedirectToAction("Index");
        }

        public FileResult DownloadBooklListFile()
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "downloadFiles", "LibrarySystemList.xlsx");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            const string fileName = "LibrarySystemList.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
