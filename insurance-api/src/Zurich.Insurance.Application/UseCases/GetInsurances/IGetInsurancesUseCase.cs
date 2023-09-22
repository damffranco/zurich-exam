namespace Zurich.Insurance.Application.UseCases.GetInsurances
{
    public interface IGetInsurancesUseCase
    {
        Task Execute();

        void SetOutputPort(IOutputPort outputPort);
    }
}
