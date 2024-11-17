using Microsoft.AspNetCore.Mvc;
using TorontoWeather;

namespace TorontoWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        public async Task<IActionResult> Weather()
        {
            var weatherData = await _weatherService.GetWeatherAsync();
            var maxTemp = weatherData["daily"]["temperature_2m_max"][0];
            var date = weatherData["daily"]["time"][0];

            ViewData["Date"] = date;
            ViewData["MaxTemp"] = maxTemp;

            return View();
        }
    }
}
