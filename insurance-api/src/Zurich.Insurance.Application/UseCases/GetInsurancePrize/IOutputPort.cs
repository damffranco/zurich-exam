﻿namespace Zurich.Insurance.Application.UseCases.GetInsurancePrize
{
    public interface IOutputPort
    {
        void Ok(Domain.Entities.Insurance insurance);
        void NotFound();
        void Invalid();
    }
}
