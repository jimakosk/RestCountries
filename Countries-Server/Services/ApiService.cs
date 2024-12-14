using Countries_Server.Models;
using Countries_Server.Services.Interfaces;
using Countries_Server.ViewModels;
using Newtonsoft.Json;
using RestSharp;

namespace Countries_Server.Services
{
    public class ApiService : IApiService
    {
        private readonly ILogger<ApiService> _logger;

        public ApiService(ILogger<ApiService>logger)
        {
           _logger = logger;
        }

        public async Task<IEnumerable<Country>> FetcheCountriesFromAsync()
        {
            var client = new RestClient("https://restcountries.com/v3.1/all");
            var request = new RestRequest();
            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                var countriesData = JsonConvert.DeserializeObject<List<CountryResponse>>(response.Content);
                var result = countriesData.Select(country => new Country
                {
                    CommonName = country.Name.Common,
                    Capital = country.Capital?.FirstOrDefault() ?? "No Capital",
                    Borders = string.Join(", ", country.Borders ?? new List<string>())
                }).ToList();

                return result;
            }
            return Enumerable.Empty<Country>();
        }
    }
}
