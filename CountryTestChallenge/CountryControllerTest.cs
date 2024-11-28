using Countries_Server.Controllers;
using Countries_Server.Models;
using Countries_Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTestChallenge
{
    public class CountryControllerTest
    {
        [Fact]
        public async Task GetCountries_ReturnsOk_WhenCountriesExist()
        {
            var mockLogger = new Mock<ILogger<CountryController>>();
            var mockCountryService = new Mock<ICountryService>();
            var expectedCountries = new List<Country>
        {
            new Country { CommonName = "USA", Capital = "Washington, D.C.", Borders = "CAN, MEX" },
            new Country { CommonName = "Canada", Capital = "Ottawa", Borders = "USA" }
        };

            mockCountryService
                .Setup(service => service.GetCountriesAsync())
                .ReturnsAsync(expectedCountries);

            var controller = new CountryController(mockLogger.Object, mockCountryService.Object);

            var result = await controller.GetCountries();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualCountries = Assert.IsType<List<Country>>(okResult.Value);
            Assert.Equal(expectedCountries.Count, actualCountries.Count);
        }

        [Fact]
        public async Task GetCountries_Returns500_WhenNoCountriesExist()
        {
            var mockLogger = new Mock<ILogger<CountryController>>();
            var mockCountryService = new Mock<ICountryService>();

            mockCountryService
                .Setup(service => service.GetCountriesAsync())
                .ReturnsAsync((List<Country>)null);

            var controller = new CountryController(mockLogger.Object, mockCountryService.Object);

            var result = await controller.GetCountries();

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("No countries were found", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task GetCountries_Returns500_WhenExceptionOccurs()
        {
            var mockLogger = new Mock<ILogger<CountryController>>();
            var mockCountryService = new Mock<ICountryService>();

            mockCountryService
                .Setup(service => service.GetCountriesAsync())
                .ThrowsAsync(new System.Exception("Something went wrong!"));

            var controller = new CountryController(mockLogger.Object, mockCountryService.Object);

            var result = await controller.GetCountries();

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("An error occurred while retrieving countries", statusCodeResult.Value.ToString());
        }
    }

}
