using Countries_Server.Data;
using Countries_Server.Models;
using Countries_Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace Countries_Server.Services
{
    public class CountryService : ICountryService
    {
        private const string CacheKey = "CountriesCache";
        private readonly string _connectionString;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ILogger<CountryService> logger,IConfiguration configuration,IMemoryCache memoryCache)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {

            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out List<Country> value))
                {
                    return value;
                }

                using (var context = new AppDbContextFactory().CreateDbContext(_connectionString))
                {
                    var countries = await context.Countries.ToListAsync();
                    if (!countries.IsNullOrEmpty())
                    {
                        _memoryCache.Set(CacheKey, countries, TimeSpan.FromMinutes(30));
                        return countries;
                    }
                }
                return await FetchAndSaveCountriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve countries from the service. An exception occurred: {ex.Message}");
                return Enumerable.Empty<Country>();
            }
        }

        public async Task<IEnumerable<Country>> FetchAndSaveCountriesAsync()
        {
             var client = new RestClient("https://restcountries.com/v3.1/all");
            var request = new RestRequest();
            RestResponse response = client.Execute(request);
            if (response.IsSuccessStatusCode)
            {
                var countriesData = JsonConvert.DeserializeObject <List<CountryResponse>>( response.Content);
                var result = countriesData.Select(country => new Country
                {
                    CommonName = country.Name.Common,
                    Capital = country.Capital?.FirstOrDefault()?? "No Capital",
                    Borders = string.Join(", ", country.Borders ?? new List<string>())
                }).ToList();
                await  SaveCountriesToDatabaseAsync(result);
                _memoryCache.Set(CacheKey, result, TimeSpan.FromMinutes(30));
                return result;
            }
            return Enumerable.Empty<Country>();
        }

        public async Task SaveCountriesToDatabaseAsync(IEnumerable<Country> countries)
        {
            using (var context = new AppDbContextFactory().CreateDbContext(_connectionString))
            {
                await context.Countries.AddRangeAsync(countries);
                await context.SaveChangesAsync();
            }
        }
    }
}




