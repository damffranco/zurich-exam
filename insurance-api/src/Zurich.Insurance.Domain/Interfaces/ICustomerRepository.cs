using Zurich.Insurance.Domain.Entities;

namespace Zurich.Insurance.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(string externalId);
        Task Add(Customer customer);

    }
}
