namespace Zurich.Insurance.Application.UseCases.GetInsurances
{
    public sealed class GetInsurancesPresenter : IOutputPort
    {
        public IList<Domain.Entities.Insurance?>? Insurances { get; private set; }
        public void Ok(IList<Domain.Entities.Insurance?> insurances) => this.Insurances = insurances;
    }
}
