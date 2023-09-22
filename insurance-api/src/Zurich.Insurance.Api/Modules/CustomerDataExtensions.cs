using Zurich.Insurance.Application.Interfaces;
using Zurich.Insurance.Infrastructure.CustomerData;

namespace Zurich.Insurance.Api.Modules
{
    public static class CustomerDataExtensions
    {

        public static IServiceCollection AddCustomerData(this IServiceCollection services)
        {

            services.AddHttpClient(CustomerDataService.HttpClientName);
            services.AddScoped<ICustomerData, CustomerDataService>();

            return services;
        }
    }
}