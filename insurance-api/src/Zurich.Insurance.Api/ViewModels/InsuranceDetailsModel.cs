namespace Zurich.Insurance.Api.ViewModels
{
    public class InsuranceDetailsModel
    {
        public InsuranceDetailsModel(Domain.Entities.Insurance insurance)
        {
            this.InsuranceId = insurance.InsuranceId;
            this.VehiclePrize = insurance.VehiclePrize;
            this.InsurancePrize = insurance.CommercialPrize;
            this.Vehicle = new VehicleModel(insurance.Vehicle);
            this.Customer = new CustomerModel(insurance.Customer);
        }

        public Guid InsuranceId { get; }

        public double VehiclePrize { get; }
        public double InsurancePrize { get; }
        public VehicleModel Vehicle { get; }
        public CustomerModel Customer { get; }
    }

}
