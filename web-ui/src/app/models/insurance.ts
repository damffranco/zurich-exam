import { Customer } from './customer';
import { Vehicle } from './vehicle';
export class Insurance {
    insuranceId: string | undefined;
    vehiclePrize: number | undefined;
    insurancePrize: number | undefined;
    vehicle: Vehicle | undefined;
    customer: Customer | undefined;
}