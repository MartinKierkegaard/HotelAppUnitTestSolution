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
            string roomText = "100001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void ParseOkTestHotelNo()
        {
            string roomText = "100001200340";
            var room = new Room();
            bool ok = room.TryParse(roomText);
            Assert.AreEqual(room.HotelNo, 1);
        }


        [TestMethod]
        public void TestIfLengthGt12()
        {
            string roomText = "1100001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);
            //Assert.AreEqual(false, ok);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void ParseNotOkTest()
        {
            string roomText = "a00001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.AreEqual(false, ok);
        }

        [TestMethod]
        public void ParseNotOkTestHotelNoInvalid()
        {
            string roomText = "a00001200340";
            var room = new Room();

            bool ok = room.TryParse(roomText);

            Assert.AreEqual(0,room.HotelNo);
        }


    }
}
