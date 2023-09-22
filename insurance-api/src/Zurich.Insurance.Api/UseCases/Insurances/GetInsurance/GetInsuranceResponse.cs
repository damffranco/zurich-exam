using Zurich.Insurance.Api.ViewModels;

namespace Zurich.Insurance.Api.UseCases.Insurances.GetInsurance
{
    public sealed class GetInsuranceResponse
    {
        public GetInsuranceResponse(Domain.Entities.Insurance insurance) => this.Insurance = new InsuranceDetailsModel(insurance);

        public InsuranceDetailsModel Insurance { get; }
    }
}
