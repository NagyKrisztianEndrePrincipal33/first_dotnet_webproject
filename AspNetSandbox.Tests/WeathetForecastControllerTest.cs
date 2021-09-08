using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// Test Suite for WeatherForecastController.
    /// </summary>
    public class WeathetForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecast()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(19, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForTomorrow.Date);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForDayAfterTomorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastForDayAfterTomorrow.Summary);
            Assert.Equal(22, weatherForecastForDayAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastForDayAfterTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
