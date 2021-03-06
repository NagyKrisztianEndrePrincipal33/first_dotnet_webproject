// <copyright file="WeatherForecastController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

/// <summary>
/// Controller that allows us to get weather forecast.
/// </summary>
namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVINKONST = 273.15f;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.652010&lon=24.484990&exclude=hourly,minutely&appid=5c308e24cae79e04481631a88fa4acc5");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content, 5);
        }

        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {
            var json = JObject.Parse(content);

            var rng = new Random();
            return Enumerable.Range(1, days).Select(index =>
            {
                var firstDayFromJson = json["daily"][index];
                var unixDateTime = firstDayFromJson.Value<long>("dt");

                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(firstDayFromJson),
                    Summary = firstDayFromJson["weather"][0].Value<string>("main"),
                };
            }).ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyWeather)
        {
            return (int)Math.Round(jsonDailyWeather["temp"].Value<float>("day") - KELVINKONST);
        }
    }
}
