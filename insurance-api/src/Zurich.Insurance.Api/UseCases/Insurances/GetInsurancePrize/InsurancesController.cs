using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zurich.Insurance.Api.ViewModels;
using Zurich.Insurance.Application.UseCases.GetInsurancePrize;

namespace Zurich.Insurance.Api.UseCases.Insurances.GetInsurancePrize
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InsurancesController : ControllerBase, IOutputPort
    {
        private readonly ILogger<InsurancesController> _logger;
        private readonly IGetInsurancePrizeUseCase _getInsurancePrizeCase;

        private IActionResult _viewModel;

        public InsurancesController(ILogger<InsurancesController> logger,
            IGetInsurancePrizeUseCase getInsurancePrizeCase)
        {
            _logger = logger;
            _getInsurancePrizeCase = getInsurancePrizeCase;
        }

        void IOutputPort.Ok(Domain.Entities.Insurance insurance) => this._viewModel = this.Ok(new GetInsurancePrizeResponse(insurance));

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Invalid()
        {
            throw new NotImplementedException();
        }

        [HttpGet("commercialprizes/{vehiclePrize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInsurancePrizeResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetInsurancePrizeResponse))]
        public async Task<IActionResult> Get([FromRoute][Required] double vehiclePrize)
        {
            this._getInsurancePrizeCase.SetOutputPort(this);
            await _getInsurancePrizeCase.Execute(vehiclePrize).ConfigureAwait(false);

            return this._viewModel;
        }


    }
}