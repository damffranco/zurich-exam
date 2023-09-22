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
    public sealed class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public VehicleRepository(ApplicationContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

        public async Task Add(Vehicle vehicle) => await this._context
                .Vehicles
                .AddAsync(vehicle)
                .ConfigureAwait(false);
      
        public async Task<Vehicle> Find(string brend, string model)
        {
            Vehicle vehicle = await this._context
                .Vehicles
                .Where(q => q.Brend == brend && q.Model == model)
                .Select(s => s)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return vehicle;
        }
    }
}
