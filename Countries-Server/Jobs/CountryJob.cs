using Countries_Server.Data;
using Countries_Server.Models;
using Countries_Server.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Countries_Server.Jobs
{
    public class CountryJob
    {
        private readonly ILogger<CountryJob> _logger;
        private readonly ICountryService _countryService;

        public CountryJob(ILogger<CountryJob> logger,ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        public async Task FetchAndSaveCountriesAsync()
        {       

           await _countryService.GetCountriesAsync();
            
            _logger.LogInformation($"Country  Job {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}");
          
        }
    }

}
