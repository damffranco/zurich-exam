using Zurich.Insurance.Domain.Model;

namespace Zurich.Insurance.Application.Interfaces
{
    public interface ICustomerData
    {
        Task<CustomerData> GetCustomerData(string externalId);
    }
}
