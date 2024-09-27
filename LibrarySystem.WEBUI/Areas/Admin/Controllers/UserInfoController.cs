using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WEBUI.Areas.Admin.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
