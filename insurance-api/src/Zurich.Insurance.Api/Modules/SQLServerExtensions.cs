using Microsoft.EntityFrameworkCore;
using Zurich.Insurance.Application.Interfaces;
using Zurich.Insurance.Domain.Interfaces;
using Zurich.Insurance.Infrastructure;
using Zurich.Insurance.Infrastructure.Repositories;

namespace Zurich.Insurance.Api.Modules
{
    public static class SQLServerExtensions
#pragma warning restore S101 // Types should be named in PascalCase
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddSQLServer(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();

            return services;
        }
    }
}