using LibrarySystem.Entity.Model;
using LibrarySystem.WEBUI.CustomModel;
using LibrarySystem.WEBUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Microsoft.AspNetCore.Mvc.Route("[area]/[controller]/[action]/{id?}")]
    public class PublishingHouseController : Controller
    {

        private readonly HttpClient _client = HttpClientIntance.CreateClient();
        public async Task<IActionResult> PublishHouseInformation()
        {
            PublishingHouseCustomModel model = new PublishingHouseCustomModel();
            return View(model);
            //var values = await _client.GetFromJsonAsync<Book>("Book");
            //return View(values);
        }
    }
}
