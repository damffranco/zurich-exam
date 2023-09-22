using Zurich.Insurance.Domain.Entities;

namespace Zurich.Insurance.Api.ViewModels
{
    public class CustomerModel
    {
        public CustomerModel(Customer customer)
        {
            this.CustomerId = customer.ExternalId;
            this.Name = customer.Nome;
            this.DocId = customer.DocId;
            this.Idade = DateTime.Now.Year - customer.BirthDate.Year;
            if (DateTime.UtcNow.DayOfYear < customer.BirthDate.Year)
                this.Idade--;
        }

        public string CustomerId { get; }
        public string Name { get; }
        public string DocId { get; }
        public int Idade { get; }

    }
}
