namespace Zurich.Insurance.Api.ViewModels
{
    public class InsurancePrizeModel
    {
        public InsurancePrizeModel(Domain.Entities.Insurance insurance)
        {
            this.VehiclePrize = insurance.VehiclePrize;
            this.InsurancePrize = insurance.CommercialPrize;
        }

        public double VehiclePrize { get; }
        public double InsurancePrize { get; }
    }
}

