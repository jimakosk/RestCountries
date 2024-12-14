using Countries_Server.Models;

namespace Countries_Server.Services.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<Country>> FetcheCountriesFromAsync();

    }
}
