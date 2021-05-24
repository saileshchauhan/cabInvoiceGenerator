using cabinvoiceGenerator;
using NUnit.Framework;

namespace TestProject
{
    class Tests
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
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenMutipleEnhancedInvoice_ShouldReturn_TotalRides_TotalFare_AverageFarePerRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 3) };
            //Arrange
            InvoiceSummary enhancedSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedEnhancedSummary = new InvoiceSummary(2, 30);
            //Assert
            Assert.AreEqual(expectedEnhancedSummary, enhancedSummary);
        }
        [Test]
        public void GivenUserId_ShouldReturn_RideListAndInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] ridesPerson1 = { new Ride(2.0, 5), new Ride(0.1, 3), new Ride(3.0, 5) };
            Ride[] ridesPerson2 = { new Ride(4.0, 20), new Ride(5.0, 25), new Ride(4.0, 30) };
            string keyPerson1 = "Sam";
            string keyPerson2 = "Mark";
            RideRepository rideRepository = invoiceGenerator.ToAccess_rideRepository();
            rideRepository.AddRide(keyPerson1, ridesPerson1);
            rideRepository.AddRide(keyPerson2, ridesPerson2);
            // Arrange
            InvoiceSummary invoiceReturn_For_Person1 = invoiceGenerator.GetInvoiceSummary(keyPerson1);
            InvoiceSummary expectedInvoice_For_Person1 = new InvoiceSummary(3, 65);
            // Assert
            Assert.AreEqual(expectedInvoice_For_Person1, invoiceReturn_For_Person1);
        }
        [Test]
        public void GivenWrongInput_wronguserkey_WhenRead_ShouldReturn_Exception_INVALID_ID()
        {
            //Act
            string userID = "noPerson";
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            //Arrange
            var execption = Assert.Throws<CabInvoiceException>(() => invoiceGenerator.GetInvoiceSummary(userID));
            //Assert
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_USER_ID, execption.etype);
        }
    }
}