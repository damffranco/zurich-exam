using Zurich.Insurance.Domain.Entities;

namespace Zurich.Insurance.Api.ViewModels
{
    public sealed class VehicleModel
    {
        public VehicleModel(Vehicle vehicle)
        {
            this.VehicleId = vehicle.VehicleId;
            this.Brend = vehicle.Brend;
            this.Model = vehicle.Model;
        }

        public Guid VehicleId { get; }
        public string Brend { get; }
        public string Model { get;  }

    }
}
