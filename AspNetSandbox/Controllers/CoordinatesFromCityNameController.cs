﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoordinatesFromCityNameController : ControllerBase
    {
        [HttpGet("{city}")]
        public CoordinatesFromCityName Get(string city)
        {
            var client = new RestClient(String.Concat("http://api.openweathermap.org/data/2.5/weather?q=",city,"&appid=5c308e24cae79e04481631a88fa4acc5"));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            var json = JObject.Parse(response.Content);
            var coordinates = json["coord"];
            return new CoordinatesFromCityName
            {
                latitude = coordinates.Value<float>("lat"),
                longitude = coordinates.Value<float>("lon")
            };
        }
    }

    
}