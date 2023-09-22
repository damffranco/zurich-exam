namespace Zurich.Insurance.UnitTests.GetInsurancePrize
{
    internal sealed class ValidDataSetup : TheoryData<double>
    {
        public ValidDataSetup()
        {
            this.Add(10000);
            this.Add(20000);
        }
    }
}
