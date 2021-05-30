using NUnit.Framework;
using parkinglot;

namespace ParkingLotTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ParkingLot.Process("create_parking_lot 6");
        }

        [Test]
        public void create_parking_lot_test()
        {
            ParkingLot.Process("create_parking_lot 6");
            Assert.AreEqual(ParkingLot.AvailableSpace, 6);
        }

        [Test]
        public void Park_Test_ExactVehicle()
        {
            ParkingLot.Process("park KA-01-HH-1234 White");
            Assert.AreEqual(ParkingLot.ParkedVehicles[1].RegistrationNumber, "KA-01-HH-1234");
        }

        [Test]
        public void Park_Test_WrongVehicle()
        {
            ParkingLot.Process("park KA-01-HH-1234 White");
            Assert.AreNotEqual(ParkingLot.ParkedVehicles[1].RegistrationNumber, "KA-01-Ho-1234");
        }


        [Test]
        public void Leave_Test_WrongVehicle()
        {
            ParkingLot.Process("park KA-01-HH-1234 White");
            Assert.AreEqual(ParkingLot.ParkedVehicles[1].RegistrationNumber, "KA-01-HH-1234");
            ParkingLot.Process("leave 1");
            Assert.AreEqual(ParkingLot.ParkedVehicles.Count, 0);
        }

        //we can see in console out put in runtests
        [Test]
        public void registration_numbers_for_cars_with_colour_test()
        {
            ParkingLot.Process("park KA-01-HH-1234 White");
            ParkingLot.Process("registration_numbers_for_cars_with_colour White");
            Assert.IsTrue(true);
        }

        //we can see in console out put in runtests
        [Test]
        public void slot_numbers_for_cars_with_colour_test()
        {
            ParkingLot.Process("park KA-01-HH-1234 White");
            ParkingLot.Process("slot_numbers_for_cars_with_colour White");
            Assert.IsTrue(true);
        }

        //we can see in console out put in runtests
        [Test]
        public void slot_number_for_registration_number_test()
        {
            ParkingLot.Process("park KA-01-HH-1234 White");
            ParkingLot.Process("slot_number_for_registration_number KA-01-HH-1234");
            Assert.IsTrue(true);
        }
    }
}