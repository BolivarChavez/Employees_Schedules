using Microsoft.Extensions.DependencyInjection;
using OfficeTime.Repositories;
using OfficeTime.Services;

namespace OfficeTime.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddOfficeTimeDependencies(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddUseCasesServices();

            return services;
        }
    }
}
