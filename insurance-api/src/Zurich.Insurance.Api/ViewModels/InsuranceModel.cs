namespace Zurich.Insurance.Api.ViewModels
{
    public class InsuranceModel
    {
        public InsuranceModel(Domain.Entities.Insurance insurance)
        {
            this.InsuranceId = insurance.InsuranceId;
            this.InsurancePrize = insurance.CommercialPrize;
    }

        public Guid InsuranceId { get; }
        public double InsurancePrize { get; }
    }
}
