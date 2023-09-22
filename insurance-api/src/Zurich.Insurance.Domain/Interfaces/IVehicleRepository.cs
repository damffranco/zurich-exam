using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zurich.Insurance.Domain.Entities;

namespace Zurich.Insurance.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> Find(string brend, string model);
        Task Add(Vehicle vehicle);
       
    }
}
