using System;

namespace ParkingChargeCalculator.Interfaces
{
    public interface IChargeCalculator
    {
        double CalculateCharge(DateTime? startDate, DateTime? endDate);
    }
}
