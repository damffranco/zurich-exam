using Zurich.Insurance.Api.ViewModels;

namespace Zurich.Insurance.Api.UseCases.Insurances.SaveInsurance
{
    public class SaveInsuranceResponse
    {
        public SaveInsuranceResponse(InsuranceModel insuranceModel) => this.Insurance = insuranceModel;

        public InsuranceModel Insurance { get; set; }
    }
}
