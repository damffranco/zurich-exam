namespace Zurich.Insurance.Application.UseCases.GetInsurances
{
    public interface IOutputPort
    {
        void Ok(IList<Domain.Entities.Insurance> insurances);
    }
}