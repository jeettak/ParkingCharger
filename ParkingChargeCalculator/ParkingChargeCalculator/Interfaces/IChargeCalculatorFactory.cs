using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculator.Interfaces
{
    public interface IChargeCalculatorFactory
    {
        IChargeCalculator GetParkingCalculator(ParkingType parkingType);
    }
}
