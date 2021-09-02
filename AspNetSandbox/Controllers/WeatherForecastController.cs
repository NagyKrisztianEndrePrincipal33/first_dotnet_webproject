using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
            //_logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.652010&lon=24.484990&exclude=hourly,minutely&appid=5c308e24cae79e04481631a88fa4acc5");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);

            //var rng = new random();
            //return enumerable.range(1, 5).select(index => new weatherforecast
            //{
            //    date = datetime.now.adddays(index),
            //    temperaturec = rng.next(-20, 55),
            //    summary = summaries[rng.next(summaries.length)]
            //})
            //.toarray();
        }

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content)
        {

            var json = JObject.Parse(content);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index =>
            {
                var firstDayFromJson = json["daily"][index];
                var unixDateTime = firstDayFromJson.Value<long>("dt");
                
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = (int)Math.Round((firstDayFromJson["temp"].Value<float>("day") - 273.15f)),
                    Summary = firstDayFromJson["weather"][0].Value<string>("main")
                };
            }).ToArray();

        }
    }
}
