using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zurich.Insurance.Application.UseCases.GetInsurancePrize
{
    public interface IGetInsurancePrizeUseCase
    {
        Task Execute(double vehiclePrize);

        void SetOutputPort(IOutputPort outputPort);
    }
}
