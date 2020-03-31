using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using ParkingChargeCalculator;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculatorTests
{
    [TestFixture]
    public class LongStayCalculatorTests
    {
        private Fixture _fixture;
        private IChargeCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _sut = new LongStayCalculator();
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

        [TestCase("07/09/2017 07:50:00", "09/09/2017 05:20:00", 22.50)]
        [TestCase("04/09/2017 13:50:00", "08/09/2017 22:45:00", 37.50)]
        public void Valid_ParkingDates_Returns_Correct_ParkingCharge(string startDate, string endDate, double expectedCharge)
        {
            // Arrange and Act
            var charge = _sut.CalculateCharge(DateTime.Parse(startDate), DateTime.Parse(endDate));

            // Assert
            charge.Should().Be(expectedCharge);
        }
    }
}
