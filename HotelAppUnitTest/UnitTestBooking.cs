using System;
using System.Text;
using System.Collections.Generic;
using HotelFlatFilesApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelAppBooking
{
    /// <summary>
    /// Summary description for UnitTestBooking
    /// </summary>
    [TestClass]
    public class UnitTestBooking
    {
       
        [TestMethod]
        public void TestBookingOk()
        {
            //001 006 234 100 101115 121115
            string bookingText = "001006234100101115121115";
            var booking = new  Booking();
            bool ok = booking.TryParse(bookingText);

            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestBookingNotOk()
        {
            //001 006 234 100 101115 121115
            string bookingText = "00100a234100101115121115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void TestBookingOkBookingid()
        {
            //001 006 234 100 101115 121115
            string bookingText = "001006234100101115121115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);
            Assert.AreEqual(1,booking.BookingId);
            Assert.IsTrue(ok);
        }


        [TestMethod]
        public void TestBookingOkHotelNo()
        {
            //001 006 234 100 101115 121115
            string bookingText = "001006234100101115121115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);
            Assert.AreEqual(6, booking.HotelNo);
            Assert.IsTrue(ok);
        }


        [TestMethod]
        public void TestBookingOkGuestNo()
        {
            //001 006 234 100 101115 121115
            string bookingText = "001006234100101115121115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);
            Assert.AreEqual(234, booking.GuestNo);
            Assert.IsTrue(ok);
        }


        [TestMethod]
        public void TestBookingOkRoomNo()
        {
            //001 006 234 100 101115 121115
            string bookingText = "001006234100101115121115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);
            Assert.AreEqual(100, booking.RoomNo);
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestBookingOkFromDate()
        {
            //001 006 234 100 101115 101115
            string bookingText = "001006234100101115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testdate = new DateTime(2015, 11, 10);

            Assert.AreEqual(testdate, booking.FromDate);
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestBookingOkFromDateoneday()
        {
            //001 006 234 100 101115 101115
            string bookingText = "001006234100081115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testdate = new DateTime(2015, 11, 8);

            Assert.AreEqual(testdate, booking.FromDate);
            Assert.IsTrue(ok);
        }


        [TestMethod]
        public void TestBookingOkToDateOneDay()
        {
            //001 006 234 100 101115 101115
            string bookingText = "001006234100081115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testdate = new DateTime(2015, 11, 10);

            Assert.AreEqual(testdate, booking.ToDate);
            Assert.IsTrue(ok);
        }


        [TestMethod]
        public void TestBookingOkToDate()
        {
            //001 006 234 100 101115 101115
            string bookingText = "001006234100101115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testdate = new DateTime(2015, 11, 10);

            Assert.AreEqual(testdate, booking.ToDate);
            Assert.IsTrue(ok);
        }

        //OBS we need some more datetime testing 

        [TestMethod]
        public void TestBookingNotOKGt24()
        {
            //001 006 234 100 101115 101115
            string bookingText = "0010062341001011151011151232424";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            Assert.IsFalse(ok);
        }


        [TestMethod]
        public void TestBookingNotOkBookingid()
        {
            //001 006 234 100 101115 101115
            string bookingText = "00a006234100101115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            Assert.AreEqual(0, booking.BookingId);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void TestBookingNotOkHotelNo()
        {
            //001 006 234 100 101115 101115
            string bookingText = "0010s6234100101115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testBooking = new Booking();

            Assert.AreEqual(testBooking.HotelNo, booking.HotelNo);
            Assert.IsFalse(ok);
        }

        /// <summary>
        /// test if teh guestnr is invalid ok=false
        /// </summary>
        [TestMethod]
        public void TestBookingNotOkGuestNo()
        {
            string bookingText = "001006-44100101115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testBooking = new Booking();

            Assert.AreEqual(testBooking.GuestNo, booking.GuestNo);
            Assert.IsFalse(ok);
        }


        [TestMethod]
        public void TestBookingNotOkRoomNo()
        {
            string bookingText = "0020062341a0101115101115";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);
            var testBooking = new Booking();

            Assert.AreEqual(testBooking.RoomNo, booking.RoomNo);
            Assert.IsFalse(ok);
        }


        [TestMethod]
        public void TestBookingNotOkToDate()
        {
            string bookingText = "001006234100310215310215";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testBooking = new Booking();

            Assert.AreEqual(testBooking.ToDate, booking.ToDate);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void TestBookingNotOkFromDate()
        {
            string bookingText = "001006234100310215310215";
            var booking = new Booking();
            bool ok = booking.TryParse(bookingText);

            var testBooking = new Booking();

            Assert.AreEqual(testBooking.FromDate, booking.FromDate);
            Assert.IsFalse(ok);
        }

    }
}
