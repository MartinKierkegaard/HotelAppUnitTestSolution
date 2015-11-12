using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelFlatFilesApp;

namespace HotelAppUnitTest
{
    [TestClass]
    public class UnitTestRoom
    {
        /// <summary>
        /// Give a valid string and test if the return value is true
        /// </summary>
        [TestMethod]
        public void RoomTextParseOkTest()
        {
            string roomText = "10001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);

            Assert.IsTrue(ok);
        }

        /// <summary>
        /// Give a invalid string and test that the return value is false
        /// </summary>
        [TestMethod]
        public void TestRoomNo()
        {
            string roomText = "10001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.IsTrue(ok);
            Assert.AreEqual(100,room.RoomNo);

        }

        /// <summary>
        /// Test that roomNo is paresed correct
        /// Hotelno = 001
        /// </summary>
        [TestMethod]
        public void RoomParseOkTestHotelNo()
        {
            string roomText = "100001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);
            Assert.AreEqual(room.HotelNo, 1);
        }

        /// <summary>
        /// Test that roomNo is paresed correct
        /// RoomNo = 100
        /// </summary>
        [TestMethod]
        public void RoomParseOkTestRoomNo()
        {
            //100 001 2 00340
            string roomText = "100001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);
            Assert.AreEqual(100,room.RoomNo);
        }

        /// <summary>
        /// Test that roomNo is paresed correct
        /// RoomType = 2 (Double room)
        /// </summary>
        [TestMethod]
        public void RoomParseOkTestRoomType_DoubelRoom()
        {
            //100 001 2 00340
            string roomText = "100001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);
            Assert.AreEqual(RoomType.Double,room.Types);
        }

        /// <summary>
        /// Test that price is parsed correct
        /// Price = 340
        /// </summary>
        [TestMethod]
        public void RoomParseOkTestPrice()
        {
            //100 001 2 00340
            string roomText = "100001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);
            Assert.AreEqual(340, room.Price);
        }

        [TestMethod]
        public void RoomTestIfLengthGt12()
        {
            string roomText = "1100001200340678";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void RoomParseNotOkTest()
        {
            string roomText = "a00001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void RoomParseNotOkTestHotelNoInvalid()
        {
            string roomText = "000Z01200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.IsFalse(ok);
            Assert.AreEqual(0, room.HotelNo);
        }

        [TestMethod]
        public void RoomParseNotOkTestRoomNoInvalid()
        {
            string roomText = "Z00001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.IsFalse(ok);
            Assert.AreEqual(0, room.HotelNo);
        }

        /// <summary>
        ///set the roomtype to 8 (not defined value in enum) 
        /// </summary>
        [TestMethod]
        public void RoomParseNotOkTestRoomTypeInvalid()
        {
            string roomText = "333001800340";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.IsFalse(ok);
            Assert.AreEqual(0,room.Types);
        }

        /// <summary>
        ///set the price to -5600
        /// </summary>
        [TestMethod]
        public void RoomParseNotOkTestPriceInvalid()
        {
            string roomText = "3330012-5600";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.AreEqual(0, room.Price);
            Assert.IsFalse(ok);

        }

        /// <summary>
        ///test if false if the roomprice if 0
        /// </summary>
        [TestMethod]
        public void RoomParseNotOkTestPriceIs0Invalid()
        {
            string roomText = "333001800000";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            Assert.IsFalse(ok);
            Assert.AreEqual(0, room.Price);
        }

        /// <summary>
        ///test if all properties on the object is not set if ok is false
        /// </summary>
        [TestMethod]
        public void RoomParseNotOkTestallDataIsNotSet()
        {
            string roomText = "333a01206500";
            var room = new Room();

            RoomType rt = (RoomType) 0;
            bool ok = room.TryParse(roomText);
            Assert.IsFalse(ok);
            Assert.AreEqual(0, room.HotelNo);
            Assert.AreEqual(0, room.RoomNo);
            Assert.AreEqual(rt, room.Types);
            Assert.AreEqual(0, room.Price);

        }




    }
}
