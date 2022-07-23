using Microsoft.Extensions.DependencyInjection;
using OfficeTime.Services.Interfaces;
using OfficeTime.Services.Services;

namespace OfficeTime.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeePair, EmployeePairInteractor>();

            return services;
        }
    }
}
