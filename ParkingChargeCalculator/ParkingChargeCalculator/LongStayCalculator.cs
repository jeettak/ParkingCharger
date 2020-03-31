using System;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculator
{
    public class LongStayCalculator : IChargeCalculator
    {
        private const double ChargePerDay = 7.50;

        public double CalculateCharge(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue) throw new ArgumentNullException(nameof(startDate));

            if (!endDate.HasValue) throw new ArgumentNullException(nameof(endDate));

            return Math.Round(NumberOfDays(startDate.Value, endDate.Value) * ChargePerDay, 2);
        }

        private static double NumberOfDays(DateTime startDate, DateTime endDate)
        {
            return endDate.Date.Subtract(startDate.Date).TotalDays + 1;
        }
    }
}
