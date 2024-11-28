using Countries_Server.Models;

namespace Countries_Server.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task SaveCountriesToDatabaseAsync(IEnumerable<Country> countries);
        Task<IEnumerable<Country>> FetchAndSaveCountriesAsync();
    }
}
