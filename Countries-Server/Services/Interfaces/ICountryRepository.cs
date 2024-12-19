using Countries_Server.Models;
using System.Collections.Generic;

namespace Countries_Server.Services.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(int id);
        Task AddAsync(Country country);
        Task AddManyAsync(IEnumerable<Country> countries);
        Task UpdateAsync(Country country);
        Task DeleteAsync(int id);
    }
}
