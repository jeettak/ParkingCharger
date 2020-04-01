using FluentAssertions;
using NUnit.Framework;
using ParkingChargeCalculator;
using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculatorTests
{
    [TestFixture]
    public class ChargeCalculatorFactoryTests
    {
        private IChargeCalculatorFactory _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ChargeCalculatorFactory();
        }

        [Test]
        public void ShortStay_ParkingType_Returns_ShortStayCalculator()
        {
            // Arrange
            var parkingType = ParkingType.ShortStay;

            // Act
            var chargeCalculator = _sut.GetParkingCalculator(parkingType);

            // Assert
            chargeCalculator.Should().BeOfType<ShortStayCalculator>();
        }

        [Test]
        public void LongStay_ParkingType_Returns_LongStayCalculator()
        {
            // Arrange
            var parkingType = ParkingType.LongStay;

            // Act
            var chargeCalculator = _sut.GetParkingCalculator(parkingType);

            // Assert
            chargeCalculator.Should().BeOfType<LongStayCalculator>();
        }
    }
}