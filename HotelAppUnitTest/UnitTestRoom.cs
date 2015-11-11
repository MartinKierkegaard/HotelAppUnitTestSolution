using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelFlatFilesApp;

namespace HotelAppUnitTest
{
    [TestClass]
    public class UnitTestRoom
    {
        [TestMethod]
        public void ParseOkTest()
        {
            string roomText = "10001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.IsTrue(ok);

        }

        [TestMethod]
        public void TestRoomNo()
        {
            string roomText = "10001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.IsTrue(ok);
            Assert.AreEqual(100,room.RoomNo);

        }

        [TestMethod]
        public void RoomParseOkTestHotelNo()
        {
            string roomText = "100001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);
            Assert.AreEqual(room.HotelNo, 1);
        }


        [TestMethod]
        [Ignore]
        public void RoomTestIfLengthGt12()
        {
            string roomText = "1100001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            //Assert.AreEqual(false, ok);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void RoomParseNotOkTest()
        {
            string roomText = "a00001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.AreEqual(false, ok);
        }

        [TestMethod]
        public void RoomParseNotOkTestHotelNoInvalid()
        {
            string roomText = "a00001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.AreEqual(0, room.HotelNo);
        }


    }
}
