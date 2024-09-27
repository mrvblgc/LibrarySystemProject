using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WEBUI.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
