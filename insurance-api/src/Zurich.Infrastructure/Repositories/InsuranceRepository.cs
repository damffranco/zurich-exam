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
    public sealed class InsuranceRepository : IInsuranceRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public InsuranceRepository(ApplicationContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

        public async Task Add(Domain.Entities.Insurance insurance) => await this._context
                .Insurances
                .AddAsync(insurance)
                .ConfigureAwait(false);

        public async Task<Domain.Entities.Insurance> GetInsurance(Guid insuranceId)
        {
            Domain.Entities.Insurance insurance = await this._context
             .Insurances
             .Where(e => e.InsuranceId == insuranceId)
             .Select(e => new Domain.Entities.Insurance
             {
                 InsuranceId = e.InsuranceId,
                 CustomerExternalId = e.CustomerExternalId,
                 VehicleId = e.VehicleId,
                 VehiclePrize = e.VehiclePrize,
                 Customer = e.Customer,
                 Vehicle = e.Vehicle
             }).FirstOrDefaultAsync()
             .ConfigureAwait(false);

            return insurance;
        }

        public async Task<IList<Domain.Entities.Insurance>> GetInsurances()
        {
            List<Domain.Entities.Insurance> insurances = await this._context
             .Insurances
             .Select(e => new Domain.Entities.Insurance
             {
                 InsuranceId = e.InsuranceId,
                 CustomerExternalId = e.CustomerExternalId,
                 VehicleId = e.VehicleId,
                 VehiclePrize = e.VehiclePrize,
                 Customer = e.Customer,
                 Vehicle = e.Vehicle
             }).ToListAsync()
             .ConfigureAwait(false);

            return insurances;
        }
    }
}
