using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zurich.Insurance.Api.ViewModels;
using Zurich.Insurance.Application.UseCases.SaveInsurance;

namespace Zurich.Insurance.Api.UseCases.Insurances.SaveInsurance
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InsurancesController : ControllerBase, IOutputPort
    {
        private readonly ILogger<InsurancesController> _logger;
        private readonly ISaveInsuranceUseCase _saveInsuranceUseCase;

        private IActionResult _viewModel;
       
        public InsurancesController(ILogger<InsurancesController> logger,
            ISaveInsuranceUseCase saveInsuranceUseCase)
        {
            _logger = logger;
            _saveInsuranceUseCase = saveInsuranceUseCase;
        }

        void IOutputPort.Ok(Domain.Entities.Insurance insurance) => this._viewModel = this.Ok(new SaveInsuranceResponse(new InsuranceModel(insurance)));

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Invalid()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveInsuranceResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SaveInsuranceResponse))]
        public async Task<IActionResult> Post(
                [FromForm][Required] string customerExternalId,
                [FromForm][Required] double vehiclePrize,
                [FromForm][Required] string vehicleBrend,
                [FromForm][Required] string vehicleModel)
        {
            this._saveInsuranceUseCase.SetOutputPort(this);
            await _saveInsuranceUseCase.Execute(customerExternalId,
               vehiclePrize,
               vehicleBrend,
               vehicleModel).ConfigureAwait(false);

            return this._viewModel;
        }
       
       
    }
}