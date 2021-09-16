using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class WeatherController : Controller
    {
        private UserService userService;
        private WeatherService weatherService;
        private ClaimService claimService;

        public WeatherController( UserService userService, WeatherService weatherService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.weatherService = weatherService;
            this.claimService = new ClaimService(httpContextAccessor);
        }

        // GET: Weather
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Constants.Admin))
            {
                return View(await weatherService.GetWeathersWithUsers());
            }
            else
            {
                var userId = claimService.UserId;
                var weathers = await weatherService.GetWeathersOfUser(userId);
                return View(weathers);
            }
        }

        // GET: Weather/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var weatherModel = await weatherService.GetWeathersOfUser(id.Value);
            if (weatherModel == null)
            {
                return NotFound();
            }

            return View(weatherModel);
        }


    }
}
