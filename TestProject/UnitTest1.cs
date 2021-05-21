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
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 3) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
    }


}