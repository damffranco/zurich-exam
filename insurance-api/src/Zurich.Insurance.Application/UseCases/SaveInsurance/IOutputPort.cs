namespace Zurich.Insurance.Application.UseCases.SaveInsurance
{
    public interface IOutputPort
    {
        void Ok(Domain.Entities.Insurance insurance);
        void NotFound();
        void Invalid();
    }
}