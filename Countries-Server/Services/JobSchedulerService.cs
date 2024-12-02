using Countries_Server.Jobs;
using Countries_Server.Services.Interfaces;
using Hangfire;

namespace Countries_Server.Services
{
    public class JobSchedulerService : IJobSchedulerService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IConfiguration _configuration;

        public JobSchedulerService(IRecurringJobManager recurringJobManager, IConfiguration configuration)
        {
            _recurringJobManager = recurringJobManager;
            _configuration = configuration;
        }

        public void ScheduleJobs()
        {
            if (_configuration.GetValue<bool>("Hangfire:IsEnabled"))
            {

                _recurringJobManager.AddOrUpdate<CountryJob>(
                "FetchAndSaveCountries",
                job => job.FetchAndSaveCountriesAsync(),
               _configuration.GetValue<string>("Hangfire:Minutes"));
                // BackgroundJob.Enqueue<CountryJob>(job => job.FetchAndSaveCountriesAsync());
            
            }
            else
                _recurringJobManager.RemoveIfExists("FetchAndSaveCountries");
        }

     
    }

}
