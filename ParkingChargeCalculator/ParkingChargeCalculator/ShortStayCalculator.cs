using System;
using System.Collections.Generic;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculator
{
    public class ShortStayCalculator : IChargeCalculator
    {
        private const double ChargePerHour = 1.10;

        public double CalculateCharge(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue) throw new ArgumentNullException(nameof(startDate));

            if (!endDate.HasValue) throw new ArgumentNullException(nameof(endDate));

            return CalculateParkingCharge(startDate.Value, endDate.Value);
        }

        private static double CalculateParkingCharge(DateTime startDate, DateTime endDate)
        {
            var numberOfDays = endDate.Date.Subtract(startDate.Date).TotalDays;
            var shortStayHours = new List<double>();

            for (int i = 0; i <= numberOfDays; i++)
            {
                DateTime checkDate;
                if (i == 0)
                {
                    checkDate = startDate.AddDays(i);
                    shortStayHours.Add(NumberOfHours(checkDate));
                }
                else if (i == numberOfDays)
                {
                    shortStayHours.Add(NumberOfHours(endDate));
                }
                else if (i > 0)
                {
                    checkDate = startDate.Date.AddDays(i);
                    shortStayHours.Add(NumberOfHours(checkDate));
                }
            }

            var numberOfShortStayHours = 0d;
            shortStayHours.ForEach(hours => numberOfShortStayHours += hours);

            return Math.Round(numberOfShortStayHours * ChargePerHour, 2);
        }

        private static double NumberOfHours(DateTime current)
        {
            var weekdayHours = 0d;

            if (current.Date.DayOfWeek != DayOfWeek.Saturday &&
                current.Date.DayOfWeek != DayOfWeek.Sunday)
            {
                if (current.Hour >= 8 && current.Hour <= 18)
                {
                    weekdayHours = 18 - (current.Hour + ((double)current.Minute / (double)60));
                }

                if (current.Hour < 8 && current.Hour <= 18)
                {
                    weekdayHours = 10;
                }
            }

            return weekdayHours;
        }
    }
}
