using Zurich.Insurance.Api.ViewModels;

namespace Zurich.Insurance.Api.UseCases.Insurances.GetInsurances
{
    public class GetInsurancesResponse
    {
        public GetInsurancesResponse(IEnumerable<Domain.Entities.Insurance> insurances)
        {
            foreach (Domain.Entities.Insurance insurance in insurances)
            {
                InsuranceDetailsModel insuranceDetailModel = new InsuranceDetailsModel(insurance);
                this.Insurances.Add(insuranceDetailModel);
            }

            this.AverageInsurancePrize = this.Insurances.Average(a => a.InsurancePrize);
        }

        public List<InsuranceDetailsModel> Insurances { get; } = new List<InsuranceDetailsModel>();
        public double AverageInsurancePrize { get; }
    }
}
