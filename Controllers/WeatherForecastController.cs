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
        private static int total = 100000;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var batchSize = 100;
            int numberOfBatches = (int)Math.Ceiling((double)total / batchSize);
            for (int i = 1; i <= numberOfBatches; i++)
            {
                BackgroundJob.Enqueue<ContractUpdateWorker>(x => x.UpdateRecords(i * batchSize));
            }
            return Ok();
        }



    }
}