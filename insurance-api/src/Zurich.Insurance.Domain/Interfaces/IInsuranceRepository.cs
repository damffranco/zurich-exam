namespace Zurich.Insurance.Domain.Interfaces
{
    public interface IInsuranceRepository
    {
        Task<IList<Entities.Insurance>> GetInsurances();
        Task<Entities.Insurance> GetInsurance(Guid insuranceId);
        Task Add(Entities.Insurance insurance);
    }
}
