namespace Zurich.Insurance.Application.UseCases.GetInsurancePrize
{
    public sealed class GetInsurancePrizeUseCase : IGetInsurancePrizeUseCase
    {
        private IOutputPort _outputPort;

        public GetInsurancePrizeUseCase()
        {
            this._outputPort = new GetInsurancePrizePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(double vehiclePrize) =>
            this.GetInsurancePrize(vehiclePrize);

        private async Task GetInsurancePrize(double vehiclePrize)
        {
            this._outputPort.Ok(new Domain.Entities.Insurance(vehiclePrize));
        }
    }
}