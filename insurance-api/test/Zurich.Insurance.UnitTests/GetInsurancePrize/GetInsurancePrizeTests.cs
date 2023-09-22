using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zurich.Insurance.Application.UseCases.GetInsurancePrize;

namespace Zurich.Insurance.UnitTests.GetInsurancePrize
{
    public sealed class GetInsurancePrizeTests
    {
        private readonly double _safetyMargin = 3.0 / 100.0;
        private readonly double _profit = 5.0 / 100.0;

        [Theory]
        [ClassData(typeof(ManualDataSetup))]
        public async Task GetInsurancePrizeUse_Valid_CommercialPrize_Manuel(double vehiclePrize, double expect)
        {
            GetInsurancePrizePresenter presenter = new GetInsurancePrizePresenter();
            GetInsurancePrizeUseCase sut = new GetInsurancePrizeUseCase();
            sut.SetOutputPort(presenter);
            await sut.Execute(vehiclePrize);
            Domain.Entities.Insurance? output = presenter.Insurance!;
            Assert.Equal(expect, output.CommercialPrize);
        }

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task GetInsurancePrizeUse_Valid_RiskRate_Value(double vehiclePrize)
        {
            GetInsurancePrizePresenter presenter = new GetInsurancePrizePresenter();
            GetInsurancePrizeUseCase sut = new GetInsurancePrizeUseCase();
            sut.SetOutputPort(presenter);
            await sut.Execute(vehiclePrize);
            Domain.Entities.Insurance? output = presenter.Insurance!;
            Assert.Equal(CalcRiskRate(vehiclePrize), output.RiskRate);
        }

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task GetInsurancePrizeUse_Valid_RiskPrize_Value(double vehiclePrize)
        {
            GetInsurancePrizePresenter presenter = new GetInsurancePrizePresenter();
            GetInsurancePrizeUseCase sut = new GetInsurancePrizeUseCase();
            sut.SetOutputPort(presenter);
            await sut.Execute(vehiclePrize);
            Domain.Entities.Insurance? output = presenter.Insurance!;
            Assert.Equal(CalcRiskPrize(vehiclePrize), output.RiskPrize);
        }

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task GetInsurancePrizeUse_Valid_CommercialPrize_Value(double vehiclePrize)
        {
            GetInsurancePrizePresenter presenter = new GetInsurancePrizePresenter();
            GetInsurancePrizeUseCase sut = new GetInsurancePrizeUseCase();
            sut.SetOutputPort(presenter);
            await sut.Execute(vehiclePrize);
            Domain.Entities.Insurance? output = presenter.Insurance!;
            Assert.Equal(CalcPurePrize(vehiclePrize), output.PurePrize);
        }

        private double CalcRiskRate(double value)
        {
            return ((value * 5.0) / (value * 2.0))/100;
        }

        private double CalcRiskPrize(double value)
        {
            return (CalcRiskRate(value) * value);
        }

        private double CalcPurePrize(double value)
        {
            return (CalcRiskPrize(value) * (1.0 + _safetyMargin));
        }

        private double CalcCommercialPrize(double value)
        {
            return (CalcRiskPrize(value) * (1.0 + _profit));
        }
    }
}
