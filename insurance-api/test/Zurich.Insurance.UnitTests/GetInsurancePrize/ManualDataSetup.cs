namespace Zurich.Insurance.UnitTests.GetInsurancePrize
{
    internal sealed class ManualDataSetup : TheoryData<double, double>
    {
        public ManualDataSetup()
        {
            this.Add(10000, 270.375);
            this.Add(20000, 540.750);
        }
    }
}
