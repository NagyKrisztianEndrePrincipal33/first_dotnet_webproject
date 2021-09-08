// <copyright file="CoordinatesFromCityNameController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoordinatesFromCityNameController : ControllerBase
    {
        [HttpGet("{city}")]
        public CoordinatesFromCityName Get(string city)
        {
            var client = new RestClient(string.Concat("http://api.openweathermap.org/data/2.5/weather?q=", city, "&appid=5c308e24cae79e04481631a88fa4acc5"));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToCoordinates(response.Content);
        }

        [NonAction]
        public CoordinatesFromCityName ConvertResponseToCoordinates(string content)
        {
            var json = JObject.Parse(content);
            var coordinates = json["coord"];
            return new CoordinatesFromCityName
            {
                Latitude = coordinates.Value<double>("lat"),
                Longitude = coordinates.Value<double>("lon"),
            };
        }
    }
}
