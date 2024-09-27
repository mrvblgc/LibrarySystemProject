using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WEBUI.Areas.Admin.Controllers
{
    public class UserRoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
