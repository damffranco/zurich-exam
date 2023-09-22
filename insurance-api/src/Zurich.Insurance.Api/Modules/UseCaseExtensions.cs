using Zurich.Insurance.Application.UseCases.GetInsurance;
using Zurich.Insurance.Application.UseCases.GetInsurancePrize;
using Zurich.Insurance.Application.UseCases.GetInsurances;
using Zurich.Insurance.Application.UseCases.SaveInsurance;

namespace Zurich.Insurance.Api.Modules
{
    public static class UseCasesExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ISaveInsuranceUseCase, SaveInsuranceUseCase>();
            services.AddScoped<IGetInsurancePrizeUseCase, GetInsurancePrizeUseCase>();
            services.AddScoped<IGetInsuranceUseCase, GetInsuranceUseCase>();
            services.AddScoped<IGetInsurancesUseCase, GetInsurancesUseCase>();

            return services;
        }
    }
}