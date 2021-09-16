using CryptoHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly TokenSettings tokenSettings;
        private readonly ITokenService _tokenService;
        private UserService userService;


        public AccountController( TokenSettings settings, ITokenService tokenService, UserService userService)
        {
            this.tokenSettings = settings;
            _tokenService = tokenService;
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.GetUserWithRolebyEmail(model.Email);
                if (user == null || !Crypto.VerifyHashedPassword(user.Password, model.Password))
                {
                    ModelState.AddModelError("", "Невірний логін та/або пароль");
                    return View(model);
                }

                Authenticate(user);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var role = await userService.GetRoleUser();
            if (role == null)
            {
                return View(model);
            }

            if (!await userService.IsAnyEmail(model.Email))
            {
                var user = new UserModel { Email = model.Email, Password = Crypto.HashPassword(model.Password), RoleId = role.Id };
                userService.SaveUser(user);

                Authenticate(user);
            }
            else
            {
                ModelState.AddModelError("", "Некоректний логін та/або пароль");
            }
            return RedirectToAction("Index", "Home");
        }

        private void Authenticate(UserModel user)
        {
            var generatedToken = _tokenService.BuildToken(tokenSettings.Key, tokenSettings.Issuer, user);
            if (generatedToken != null)
            {
                HttpContext.Session.SetString("Token", generatedToken);
            };
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost, Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Save([FromForm] UserModel user)
        {
            var dbUser = await userService.GetUser(user.Id);
            if (user.RoleId != null)
            {
                dbUser.RoleId = user.RoleId;
            }
            if (!string.IsNullOrEmpty(user.Email))
            {
                dbUser.Email = user.Email;
                if (User.IsInRole(Constants.User))
                {
                    HttpContext.Session.Clear();
                    Authenticate(dbUser);
                }
            }
            
            await userService.UpdateUser(user);
            if (User.IsInRole(Constants.Admin))
            {
                return RedirectToAction("History", "Users", new { userId = dbUser.Id });
            }
            return RedirectToAction("Page", "Users");
        }


    }
}
