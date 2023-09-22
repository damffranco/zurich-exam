using Zurich.Insurance.Domain.Interfaces;

namespace Zurich.Insurance.Application.UseCases.GetInsurances
{
    public sealed class GetInsurancesUseCase : IGetInsurancesUseCase
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private IOutputPort _outputPort;

        public GetInsurancesUseCase(IInsuranceRepository insuranceRepository)
        {
            this._insuranceRepository = insuranceRepository;
            this._outputPort = new GetInsurancesPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            return this.GetInsurances();
        }

        private async Task GetInsurances()
        {
            IList<Domain.Entities.Insurance>? insurances = await this._insuranceRepository
                .GetInsurances()
                .ConfigureAwait(false);

            this._outputPort.Ok(insurances);
        }
    }
}
