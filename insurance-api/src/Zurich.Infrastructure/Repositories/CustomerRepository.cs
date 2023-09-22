using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zurich.Insurance.Domain.Entities;
using Zurich.Insurance.Domain.Interfaces;

namespace Zurich.Insurance.Infrastructure.Repositories
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public CustomerRepository(ApplicationContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

        public async Task Add(Customer customer) => await this._context
                .Customers
                .AddAsync(customer)
                .ConfigureAwait(false);

        public async Task<Customer> GetCustomer(string externalId)
        {
            Customer customer = await this._context
                .Customers
                .Where(q => q.ExternalId == externalId)
                .Select(s => s)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return customer;
        }
    }
}
