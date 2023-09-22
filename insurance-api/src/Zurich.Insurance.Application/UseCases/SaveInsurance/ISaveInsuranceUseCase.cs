namespace Zurich.Insurance.Application.UseCases.SaveInsurance
{
    public interface ISaveInsuranceUseCase
    {
        Task Execute(string customerExternalId,
                double vehiclePrize,
                string vehicleBrend,
                string vehicleModel);

        void SetOutputPort(IOutputPort outputPort);
    }
}