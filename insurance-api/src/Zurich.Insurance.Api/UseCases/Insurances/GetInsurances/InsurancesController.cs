using Microsoft.AspNetCore.Mvc;
using Zurich.Insurance.Application.UseCases.GetInsurances;

namespace Zurich.Insurance.Api.UseCases.Insurances.GetInsurances
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InsurancesController : ControllerBase, IOutputPort
    {
        private readonly ILogger<InsurancesController> _logger;
        private readonly IGetInsurancesUseCase _getInsurancesUseCase;

        private IActionResult _viewModel;

        public InsurancesController(ILogger<InsurancesController> logger,
            IGetInsurancesUseCase getInsurancesUseCase)
        {
            _logger = logger;
            _getInsurancesUseCase = getInsurancesUseCase;
        }

        void IOutputPort.Ok(IList<Domain.Entities.Insurance> insurances) => this._viewModel = this.Ok(new GetInsurancesResponse(insurances));


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInsurancesResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetInsurancesResponse))]
        public async Task<IActionResult> Get()
        {
            this._getInsurancesUseCase.SetOutputPort(this);
            await _getInsurancesUseCase.Execute().ConfigureAwait(false);

            return this._viewModel;
        }


    }
}