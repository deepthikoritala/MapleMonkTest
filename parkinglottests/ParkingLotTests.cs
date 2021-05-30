using NUnit.Framework;
using parkinglot;

namespace ParkingLotTests
{
    public class ParkingLotTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void create_parking_lot_test()
        {
            ParkingLot.Process("create_parking_lot 6");
            Assert.AreEqual(ParkingLot.AvailableSpace,6);
        }

    }
}