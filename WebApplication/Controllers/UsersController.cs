using CryptoHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;
using WebApplication.Services;

namespace WebApplication.Controllers
{   
    [Authorize]
    public class UsersController : Controller
    {
        private WeatherContext _context;
        private ClaimService claimService;
        private readonly UserService userService;
        private readonly WeatherService weatherService;

        public UsersController(WeatherContext context, IHttpContextAccessor httpContextAccessor, UserService userService, WeatherService weatherService)
        {
            _context = context;
            claimService = new ClaimService(httpContextAccessor);
            this.userService = userService;
            this.weatherService = weatherService;
        }

        public async Task<IActionResult> Page()
        {
            var userId = claimService.UserId;
            ViewBag.User = await userService.GetUser(userId);
            var weather = await weatherService.GetWeathersOfUser(userId);
            return View(await weatherService.GetWeathersOfUser(userId));
        }

        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> History(Guid userId)
        {
            var user = await userService.GetFullUser(userId);
            if (user != null)
            {
                return View(user);
            }
            ViewBag.Message = "Невірне посилання";
            return RedirectToAction("Index", "Home");

        }

        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await userService.GetRoles();
            return View();
        }

        [HttpPost, Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.GetUserByEmail(model.Email); 
                if (user == null)
                {
                    user = new UserModel { Email = model.Email, Password = Crypto.HashPassword(model.Password), RoleId = model.RoleId };
                    userService.SaveUser(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Такий користувач уже існує або дані невірні");
                }

            }
            return View(model);
        }

        private async Task<PartialViewResult> GetPartial(Guid userId, string partial)
        {
            var userD = await userService.GetUser(userId);
            return PartialView(partial, userD);
        }

        [HttpGet, Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> ChangeRole(Guid userId)
        {
            ViewBag.Roles = await userService.GetRoles();
            return await GetPartial(userId, "~/Views/Partials/ChangeRole.cshtml");
        }

        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> ToChangeRole(Guid userId)
        {
            return await GetPartial(userId, "~/Views/Partials/ToChangeRole.cshtml");
        }


        [HttpGet]
        public async Task<IActionResult> ChangeEmail(Guid userId)
        {
            return await GetPartial(userId, "~/Views/Partials/ChangeEmail.cshtml");
        }

        public async Task<IActionResult> ToChangeEmail(Guid userId)
        {
            return await GetPartial(userId, "~/Views/Partials/ToChangeEmail.cshtml");
        }

        public async Task<IActionResult> ChangePassword(Guid userId)
        {
            return await GetPartial(userId, "~/Views/Partials/ChangePassword.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromForm] UserModel user)
        {
            if(!claimService.UserId.Equals(user.Id) && !User.IsInRole(Constants.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            var dbUser = await userService.GetUser(user.Id);
            dbUser.Password = CryptoHelper.Crypto.HashPassword(user.Password);
            await userService.UpdateUser(dbUser);
            if (User.IsInRole(Constants.User))
            {
                return RedirectToAction("Page", "Users");
            }
            return RedirectToAction("History", "Users", new { userId = dbUser.Id });
        }

        public async Task<IActionResult> ToChangePassword(Guid userId)
        {
            return await GetPartial(userId, "~/Views/Partials/ToChangePassword.cshtml");
        }

        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            await userService.DeleteUser(userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
