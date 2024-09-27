using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WEBUI.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
