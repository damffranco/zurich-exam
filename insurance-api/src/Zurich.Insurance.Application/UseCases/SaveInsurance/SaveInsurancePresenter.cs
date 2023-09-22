namespace Zurich.Insurance.Application.UseCases.SaveInsurance
{
    public sealed class SaveInsurancePresenter : IOutputPort
    {
        public Domain.Entities.Insurance? Insurance { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Domain.Entities.Insurance insurance) => this.Insurance = insurance;
    }
}
