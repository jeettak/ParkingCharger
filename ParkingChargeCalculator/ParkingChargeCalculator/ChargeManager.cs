using System;
using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculator
{
    public class ChargeManager : IChargeManager
    {
        private readonly IChargeCalculatorFactory _chargeCalculatorFactory;

        public ChargeManager(IChargeCalculatorFactory chargeCalculatorFactory)
        {
            _chargeCalculatorFactory = chargeCalculatorFactory ?? throw new ArgumentNullException(nameof(chargeCalculatorFactory));
        }

        public double CalculateCharge(Visitor visitor, ParkingType parkingType)
        {
            _ = visitor ?? throw new ArgumentNullException(nameof(visitor));

            IChargeCalculator chargeCalculator = _chargeCalculatorFactory.GetParkingCalculator(parkingType);
            return chargeCalculator.CalculateCharge(visitor.StartParking, visitor.LeaveParking);
        }
    }
}
