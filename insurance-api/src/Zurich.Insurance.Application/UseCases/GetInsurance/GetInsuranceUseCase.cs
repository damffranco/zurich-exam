using Zurich.Insurance.Domain.Interfaces;

namespace Zurich.Insurance.Application.UseCases.GetInsurance
{
    public sealed class GetInsuranceUseCase : IGetInsuranceUseCase
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountUseCase" /> class.
        /// </summary>
        /// <param name="insuranceRepository">Account Repository.</param>
        public GetInsuranceUseCase(IInsuranceRepository insuranceRepository)
        {
            this._insuranceRepository = insuranceRepository;
            this._outputPort = new GetInsurancePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid insuranceId) =>
            this.GetInsurance(insuranceId);

        private async Task GetInsurance(Guid insuranceId)
        {
            Domain.Entities.Insurance insurance = await this._insuranceRepository
                .GetInsurance(insuranceId)
                .ConfigureAwait(false);

            if (insurance is Domain.Entities.Insurance getInsurance)
            {
                this._outputPort.Ok(getInsurance);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}
