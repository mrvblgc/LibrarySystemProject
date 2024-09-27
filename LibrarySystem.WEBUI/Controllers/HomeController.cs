using Azure;
using LibrarySystem.DTO.DTOS.BookDTOS;
using LibrarySystem.DTO.DTOS.UserInfoDTOS;
using LibrarySystem.DTO.DTOS.UserRoleDTOS;
using LibrarySystem.Entity.Model;
using LibrarySystem.WEBUI.Helpers;
using LibrarySystem.WEBUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;

namespace LibrarySystem.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HttpClient _client = HttpClientIntance.CreateClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userInfo)
        {
            var values = await _client.PostAsJsonAsync("User/UserInfoByEmailPassword", userInfo);

            if (values.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var readResponse = await values.Content.ReadAsStringAsync();
                var userInfoDto = JsonConvert.DeserializeObject<UserInfoDto>(readResponse);
                if (userInfoDto == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                var getUserRole = await _client.GetFromJsonAsync<UserRoleDto>("UserRole/" + userInfoDto.UserRoleId);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, userInfo.Email),
                        new Claim(ClaimTypes.Role, getUserRole.UserRoleName),
                        new Claim(ClaimTypes.NameIdentifier, userInfoDto.UserId.ToString())
                    };
                var useridentity = new ClaimsIdentity(claims, "AuthClaimsOrnek");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                if (getUserRole.UserRoleName == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MessageError"] = "Kullanýcý adý veya þifre hatalý!! ";
                return RedirectToAction("Login", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}