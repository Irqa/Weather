using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class ApiService
    {
        
        public async Task<WeatherReport> GetApiResult(string city, string key, string baseUrl)
        {
            string url = string.Format("{2}q={0}&appid={1}", city, key, baseUrl);

            using (HttpClient client = new HttpClient())
            {
                WeatherReport result = new WeatherReport();
                try
                {

                    var responseMessage = await client.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<RootObject>();

                        result.Humidity = response.main.humidity.ToString();
                        result.Pressure = response.main.pressure.ToString();
                        result.Temp = response.main.temp.ToString();
                        result.TempMax = response.main.temp_max.ToString();
                        result.TempMin = response.main.temp_min.ToString();
                        result.WindSpeed = response.wind.speed.ToString();

                    }

                }
                catch (Exception e)
                { }

                return result;
            }
        }
    }
}
