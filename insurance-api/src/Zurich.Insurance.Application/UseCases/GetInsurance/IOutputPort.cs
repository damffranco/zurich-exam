namespace Zurich.Insurance.Application.UseCases.GetInsurance
{
    public interface IOutputPort
    {
        void Ok(Domain.Entities.Insurance insurance);
        void NotFound();
        void Invalid();
    }
}
