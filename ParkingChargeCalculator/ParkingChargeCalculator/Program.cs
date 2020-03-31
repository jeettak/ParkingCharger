using System;
using Microsoft.Extensions.DependencyInjection;
using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IChargeCalculatorFactory, ChargeCalculatorFactory>()
                .BuildServiceProvider();

            var visitor = new Visitor
            {
                StartParking = DateTime.Parse("07/09/2017 16:50:00"),
                LeaveParking = DateTime.Parse("09/09/2017 19:15:00")
            };

            var chargeManager = new ChargeManager(serviceProvider.GetService<IChargeCalculatorFactory>());

            var parkingType = ParkingType.ShortStay;
            var parkingCharge = chargeManager.CalculateCharge(visitor, parkingType);
            Console.WriteLine($"{parkingType.ToString()}: {parkingCharge}");

            parkingType = ParkingType.LongStay;
            parkingCharge = chargeManager.CalculateCharge(visitor, parkingType);
            Console.WriteLine($"{parkingType.ToString()}: {parkingCharge}");

            visitor.StartParking = DateTime.Parse("05/09/2017 13:50:00");
            parkingCharge = chargeManager.CalculateCharge(visitor, parkingType);
            Console.WriteLine($"{parkingType.ToString()}: {parkingCharge}");
        }
    }
}
