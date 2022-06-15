using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace TestBackgroundApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            for (int i = 1; i <= 1000; i++)
            {
                BackgroundJob.Enqueue<ContractUpdateWorker>(x => x.UpdateRecords(i));
            }
            return Ok();
        }



    }
}