using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculator
{
    public class ChargeCalculatorFactory : IChargeCalculatorFactory
    {
        public IChargeCalculator GetParkingCalculator(ParkingType parkingType)
        {
            return parkingType switch
            {
                ParkingType.ShortStay => new ShortStayCalculator(),
                ParkingType.LongStay => new LongStayCalculator(),
                _ => new ShortStayCalculator()
            };
        }
    }
}
