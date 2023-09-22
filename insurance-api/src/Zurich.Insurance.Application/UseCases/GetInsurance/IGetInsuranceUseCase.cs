namespace Zurich.Insurance.Application.UseCases.GetInsurance
{
    public interface IGetInsuranceUseCase
    {
        Task Execute(Guid insuranceId);

        void SetOutputPort(IOutputPort outputPort);
    }
}
