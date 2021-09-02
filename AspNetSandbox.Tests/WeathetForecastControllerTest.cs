using AspNetSandbox.Controllers;
using System;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class WeathetForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecast()
        {
            // Assume
            string content = "";
            var controller = new WeatherForecastController();


            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);


            // Assert
            Assert.Equal("rainy",((WeatherForecast[]) output)[0].Summary);
        }
    }
}
