namespace Zurich.Insurance.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
