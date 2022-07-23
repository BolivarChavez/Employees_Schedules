using Microsoft.Extensions.DependencyInjection;
using OfficeTime.Entities.Interfaces;
using OfficeTime.Repositories.Repositories;

namespace OfficeTime.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            return services;
        }
    }
}
