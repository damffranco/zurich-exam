using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zurich.Insurance.Application.UseCases.GetInsurancePrize
{
    public sealed class GetInsurancePrizePresenter : IOutputPort
    {
        public Domain.Entities.Insurance? Insurance { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Domain.Entities.Insurance insurance) => this.Insurance = insurance;
    }
}
