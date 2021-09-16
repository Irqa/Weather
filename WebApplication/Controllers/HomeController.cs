using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly WeatherSettings weatherSettings;
        private readonly ApiService apiHandler;
        private ClaimService claimService;
        private readonly UserService userService;
        private readonly WeatherService weatherService;

        public HomeController(WeatherSettings singleton, ApiService apiHandler, IHttpContextAccessor httpContextAccessor, UserService userService, WeatherService weatherService)
        {
            weatherSettings = singleton;
            this.apiHandler = apiHandler;
            claimService = new ClaimService(httpContextAccessor);
            this.userService = userService;
            this.weatherService = weatherService;

        }

        public async Task<IActionResult> Index()
        {
            if(User.IsInRole(Constants.Admin))
            {
                var users = await userService.GetAdminUsersList(claimService.UserId);
                return View(users);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Weather(string city)
        {
            var result = await apiHandler.GetApiResult(city, weatherSettings.key, weatherSettings.baseUrl);
            var user = await userService.GetUser( claimService.UserId);
            await weatherService.SaveWeather(city, result, user);
            return Json(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
