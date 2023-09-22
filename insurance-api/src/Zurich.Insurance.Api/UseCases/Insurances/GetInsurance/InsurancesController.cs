using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zurich.Insurance.Api.ViewModels;
using Zurich.Insurance.Application.UseCases.GetInsurance;

namespace Zurich.Insurance.Api.UseCases.Insurances.GetInsurance
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InsurancesController : ControllerBase, IOutputPort
    {
        private readonly ILogger<InsurancesController> _logger;
        private readonly IGetInsuranceUseCase _getInsuranceUseCase;

        private IActionResult _viewModel;

        public InsurancesController(ILogger<InsurancesController> logger,
            IGetInsuranceUseCase getInsuranceUseCase)
        {
            _logger = logger;
            _getInsuranceUseCase = getInsuranceUseCase;
        }

        void IOutputPort.Ok(Domain.Entities.Insurance insurance) => this._viewModel = this.Ok(new GetInsuranceResponse(insurance));

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Invalid()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{insuranceId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInsuranceResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetInsuranceResponse))]
        public async Task<IActionResult> Get([FromRoute][Required] Guid insuranceId)
        {
            this._getInsuranceUseCase.SetOutputPort(this);
            await _getInsuranceUseCase.Execute(insuranceId).ConfigureAwait(false);

            return this._viewModel;
        }


    }
}