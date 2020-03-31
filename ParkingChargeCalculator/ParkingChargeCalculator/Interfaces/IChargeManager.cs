using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculator.Interfaces
{
    public interface IChargeManager
    {
        double CalculateCharge(Visitor visitor, ParkingType parkingType);
    }
}
