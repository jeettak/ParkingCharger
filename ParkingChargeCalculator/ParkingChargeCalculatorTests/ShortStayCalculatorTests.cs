using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using ParkingChargeCalculator;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculatorTests
{
    [TestFixture]
    public class ShortStayCalculatorTests
    {
        private Fixture _fixture;
        private IChargeCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _sut = new ShortStayCalculator();
        }

        [Test]
        public void InvalidStartDate_Throws_ArgumentNullException()
        {
            // Arrange
            var endDate = _fixture.Create<DateTime>();
            DateTime? startDate = null;

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.CalculateCharge(startDate, endDate));

            exception.ParamName.Should().Be("startDate");
        }

        [Test]
        public void InvalidEndDate_Throws_ArgumentNullException()
        {
            // Arrange
            var startDate = _fixture.Create<DateTime>();
            DateTime? endDate = null;

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.CalculateCharge(startDate, endDate));

            exception.ParamName.Should().Be("endDate");
        }


        [TestCase("04/09/2017 16:50:00", "08/09/2017 19:15:00", 34.28)]
        [TestCase("07/09/2017 16:50:00", "09/09/2017 19:15:00", 12.28)]
        [TestCase("04/09/2017 13:50:00", "08/09/2017 22:45:00", 37.58)]
        [TestCase("09/09/2017 08:50:00", "10/09/2017 17:45:00", 00.00)]
        public void Valid_ParkingDates_Returns_Correct_ParkingCharge(string startDate, string endDate, double expectedCharge)
        {
            // Arrange and Act
            var charge = _sut.CalculateCharge(DateTime.Parse(startDate), DateTime.Parse(endDate));

            // Assert
            charge.Should().Be(expectedCharge);
        }
    }
}
