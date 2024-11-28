namespace Countries_Server.Services
{
    public class JobInitializationMiddleware
    {
        private readonly RequestDelegate _next;

        public JobInitializationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, JobSchedulerService jobSchedulerService)
        {
            jobSchedulerService.ScheduleJobs();

            await _next(context);
        }
    }

}
