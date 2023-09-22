using Zurich.Insurance.Api.ViewModels;

namespace Zurich.Insurance.Api.UseCases.Insurances.GetInsurancePrize
{
    public class GetInsurancePrizeResponse
    {
        public GetInsurancePrizeResponse(Domain.Entities.Insurance insurance) => this.InsurancePrize = new InsurancePrizeModel(insurance);

        public InsurancePrizeModel InsurancePrize { get; }
    }
}
