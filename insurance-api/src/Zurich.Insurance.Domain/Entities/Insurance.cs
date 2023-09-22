namespace Zurich.Insurance.Domain.Entities
{
    public class Insurance
    {
        private readonly double _safetyMargin = 3.0 / 100.0;
        private readonly double _profit = 5.0 / 100.0;

        public Insurance()
        {

        }

        public Insurance(double vehiclePrize)
        {
            this.VehiclePrize = vehiclePrize;
        }
        public Guid InsuranceId { get; set; }
        public string CustomerExternalId { get; set; }
        public Guid VehicleId { get; set; }
        public double VehiclePrize { get; set; }

        public double RiskRate => ((VehiclePrize * 5.0) / (2.0 * VehiclePrize)) / 100.0;

        public double RiskPrize => RiskRate * VehiclePrize;

        public double PurePrize => RiskPrize * (1.0 + _safetyMargin);

        public double CommercialPrize => (1.0 + _profit) * PurePrize;
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
