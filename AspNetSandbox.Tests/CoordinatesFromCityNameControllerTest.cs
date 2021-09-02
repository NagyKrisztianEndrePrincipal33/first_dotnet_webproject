using AspNetSandbox.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class CoordinatesFromCityNameControllerTest
    {
        [Fact]
        public void ConvertResponseToCoordinatesTestRome()
        {
            //Assume
            string content= "{\"coord\":{\"lon\":-85.1647,\"lat\":34.257},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":300.9,\"feels_like\":302.44,\"temp_min\":297.82,\"temp_max\":303.92,\"pressure\":1014,\"humidity\":62},\"visibility\":10000,\"wind\":{\"speed\":3.09,\"deg\":360},\"clouds\":{\"all\":75},\"dt\":1630604140,\"sys\":{\"type\":2,\"id\":2009645,\"country\":\"US\",\"sunrise\":1630581306,\"sunset\":1630627550},\"timezone\":-14400,\"id\":4219762,\"name\":\"Rome\",\"cod\":200}";
            var controller = new CoordinatesFromCityNameController();
            //Act
            var output = controller.ConvertResponseToCoordinates(content);

            //Assert
            Assert.Equal(-85.1647, output.longitude);
            Assert.Equal(34.257, output.latitude);
        }

        [Fact]
        public void ConvertResponseToCoordinatesTestBerlin()
        {
            //Assume
            string content = "{\"coord\":{\"lon\":13.4105,\"lat\":52.5244},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"base\":\"stations\",\"main\":{\"temp\":291,\"feels_like\":290.83,\"temp_min\":289.31,\"temp_max\":292.46,\"pressure\":1017,\"humidity\":76},\"visibility\":10000,\"wind\":{\"speed\":3.58,\"deg\":298,\"gust\":6.71},\"clouds\":{\"all\":20},\"dt\":1630604890,\"sys\":{\"type\":2,\"id\":2011538,\"country\":\"DE\",\"sunrise\":1630556350,\"sunset\":1630605201},\"timezone\":7200,\"id\":2950159,\"name\":\"Berlin\",\"cod\":200}";

            var controller = new CoordinatesFromCityNameController();
            //Act
            var output = controller.ConvertResponseToCoordinates(content);

            //Assert
            Assert.Equal(13.4105, output.longitude);
            Assert.Equal(52.5244, output.latitude);
        }
        [Fact]
        public void ConvertResponseToCoordinatesTestLondon()
        {
            //Assume
            string content = "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":291.65,\"feels_like\":291.25,\"temp_min\":289.75,\"temp_max\":292.89,\"pressure\":1025,\"humidity\":65},\"visibility\":10000,\"wind\":{\"speed\":5.14,\"deg\":60},\"clouds\":{\"all\":75},\"dt\":1630604687,\"sys\":{\"type\":2,\"id\":2006068,\"country\":\"GB\",\"sunrise\":1630559700,\"sunset\":1630608346},\"timezone\":3600,\"id\":2643743,\"name\":\"London\",\"cod\":200}";

            var controller = new CoordinatesFromCityNameController();
            //Act
            var output = controller.ConvertResponseToCoordinates(content);

            //Assert
            Assert.Equal(-0.1257, output.longitude);
            Assert.Equal(51.5085, output.latitude);
        }


    }
}
