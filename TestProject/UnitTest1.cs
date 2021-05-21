using cabinvoiceGenerator;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            // Act
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            // Arrange
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            // Assert
            Assert.AreEqual(expected, fare);
        }

    }


}