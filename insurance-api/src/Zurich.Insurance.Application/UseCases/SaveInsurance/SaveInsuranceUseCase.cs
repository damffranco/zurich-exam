using Zurich.Insurance.Application.Interfaces;
using Zurich.Insurance.Domain.Entities;
using Zurich.Insurance.Domain.Interfaces;

namespace Zurich.Insurance.Application.UseCases.SaveInsurance
{
    public sealed class SaveInsuranceUseCase : ISaveInsuranceUseCase
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public SaveInsuranceUseCase(
            IInsuranceRepository insuranceRepository,
            IVehicleRepository vehicleRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            this._insuranceRepository = insuranceRepository;
            this._vehicleRepository = vehicleRepository;
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new SaveInsurancePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(string customerExternalId,
                double vehiclePrize,
                string vehicleBrend,
                string vehicleModel) =>
            this.SaveInsurance(customerExternalId, vehiclePrize, vehicleBrend, vehicleModel);

        private async Task SaveInsurance(string customerExternalId,
                double vehiclePrize,
                string vehicleBrend,
                string vehicleModel)
        {
            /*
            string externalUserId = this._userService
                .GetCurrentUserId();
            */
            Domain.Entities.Insurance insurance = new Domain.Entities.Insurance
            {
                VehiclePrize = vehiclePrize,
                Vehicle = new Vehicle
                {
                    Brend = vehicleBrend,
                    Model = vehicleModel,
                }
            };

            Customer customer = await this._customerRepository.GetCustomer(customerExternalId);

            if (customer != null)
                insurance.Customer = customer;
            else
                insurance.Customer = new Customer { ExternalId = customerExternalId, Nome = "Diego", BirthDate = DateTime.Now, DocId = "39740223842" };

            Vehicle vehicle = await this._vehicleRepository.Find(vehicleBrend, vehicleModel);

            if (vehicle != null)
                insurance.Vehicle = vehicle;

            await this._insuranceRepository
                .Add(insurance)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(insurance);
        }
    }
}
