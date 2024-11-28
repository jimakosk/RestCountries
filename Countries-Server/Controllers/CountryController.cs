using Countries_Server.Data;
using Countries_Server.Models;
using Countries_Server.Services;
using Countries_Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Countries_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService countryService;

        public CountryController(ILogger<CountryController> logger,ICountryService countryService)
        {
            _logger = logger;
            this.countryService = countryService;
        }

        [HttpGet]
        [Route("get-countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var result = await countryService.GetCountriesAsync();
                if (result.IsNullOrEmpty())
                {
                    return StatusCode(500, "No countries were found in the database or API.");

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving countries.{ex}");
                return StatusCode(500, "An error occurred while retrieving countries.");

            }
        }
    }
}
