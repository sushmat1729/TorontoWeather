using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TorontoWeather;

namespace TorontoWeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;

        public HomeController()
        {
            _weatherService = new WeatherService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Weather()
        {
            var weatherData = await _weatherService.GetTorontoWeatherAsync();
            ViewBag.Weather = weatherData; // Passing the weather data to the view via ViewBag

            return View();
        }

    }
}
