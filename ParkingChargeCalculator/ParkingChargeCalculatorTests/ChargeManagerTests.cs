using System;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ParkingChargeCalculator;
using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculator.Models;

namespace ParkingChargeCalculatorTests
{
    [TestFixture]
    public class ChargeManagerTests
    {
        private IChargeManager _sut;

        private Fixture _fixture;
        private Mock<IChargeCalculatorFactory> _mockChargeCalculatorFactory;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();

            _mockChargeCalculatorFactory = new Mock<IChargeCalculatorFactory>();

            _sut = new ChargeManager(_mockChargeCalculatorFactory.Object);
        }

        [Test]
        public void AnInvalid_ChargeCalculatorFactory_Throws_ArgumentNullException()
        {
            // Arrange and Act
            var exception = Assert.Throws<ArgumentNullException>(() => new ChargeManager(null));

            // Assert
            exception.ParamName.Should().Be("chargeCalculatorFactory");
        }

        [Test]
        public void Invalid_Visitor_Throws_ArgumentNullException()
        {
            // Arrange and Act
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.CalculateCharge(null, ParkingType.ShortStay));

            // Assert
            exception.ParamName.Should().Be("visitor");
        }

        [Test]
        public void ShortStay_Charge_Is_Returned_Successfully()
        {
            // Arrange
            var visitor = _fixture.Create<Visitor>();
            visitor.StartParking = DateTime.Parse("07/09/2017 16:50:00");
            visitor.LeaveParking = DateTime.Parse("09/09/2017 19:15:00");

            _mockChargeCalculatorFactory
                .Setup(ccf => ccf.GetParkingCalculator(It.IsAny<ParkingType>()))
                .Returns(new ShortStayCalculator());

            // Act
            var result = _sut.CalculateCharge(visitor, ParkingType.ShortStay);

            // Assert
            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void LongStay_Charge_Is_Returned_Successfully()
        {
            // Arrange
            var visitor = _fixture.Create<Visitor>();
            visitor.StartParking = DateTime.Parse("07/09/2017 16:50:00");
            visitor.LeaveParking = DateTime.Parse("09/09/2017 19:15:00");

            _mockChargeCalculatorFactory
                .Setup(ccf => ccf.GetParkingCalculator(It.IsAny<ParkingType>()))
                .Returns(new LongStayCalculator());

            // Act
            var result = _sut.CalculateCharge(visitor, ParkingType.LongStay);

            // Assert
            result.Should().BeGreaterThan(0);
        }
    }
}
