using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class WeatherService
    {
        WeatherContext _context;
        public WeatherService(WeatherContext context)
        {
            _context = context;
        }

        public async Task SaveWeather(string city, WeatherReport result, UserModel user)
        {
            try
            {
                var row = new WeatherModel();
                row.City = city;
                row.Date = DateTime.Now;
                row.Temperature = double.Parse(result.Temp);
                row.MaxTemperature = double.Parse(result.TempMax);
                row.MinTemperature = double.Parse(result.TempMin);
                row.User = user;

                _context.Add(row);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            { }
            return;
        }

        public async Task<List<WeatherModel>> GetWeathersOfUser(Guid userId)
        {
            return await _context.Weathers.Include(u => u.User).Where(u => u.User.Id.Equals(userId)).ToListAsync();
        }

        public async Task<List<WeatherModel>> GetWeathersWithUsers()
        {
            return await _context.Weathers.Include(w => w.User).ToListAsync();
        }
    }
}
