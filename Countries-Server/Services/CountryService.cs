﻿using Countries_Server.Data;
using Countries_Server.Models;
using Countries_Server.Services.Interfaces;
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
        private readonly IApiService _apiService;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ILogger<CountryService> logger, IConfiguration configuration, IMemoryCache memoryCache, IApiService apiService)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
            _memoryCache = memoryCache;
            _apiService = apiService;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out List<Country>? value))
                {
                    return value ?? Enumerable.Empty<Country>();
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
            var result = await _apiService.FetcheCountriesFromAsync();
            if (result.Any())
            {
                await SaveCountriesToDatabaseAsync(result);
                _memoryCache.Set(CacheKey, result, TimeSpan.FromMinutes(30));
            }
            return result;

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




