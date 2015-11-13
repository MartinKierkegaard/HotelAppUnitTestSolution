using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFlatFilesApp
{
    public class Booking
    {
        
        public Booking()
        {

        }
        

        public int BookingId { get; set; }
        public int HotelNo { get; set; }
        public int GuestNo { get; set; }
        public int RoomNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Record layout
        ///  1-3 BookingId
        ///  4-6 HotelNo
        ///  7-9 GuestNo
        ///  10-12 RoomNo
        ///  13-18 FromDate
        ///  19-24 ToDate
        /// </summary>
        /// <returns></returns>
        public bool TryParse(string input)
        {
            Console.WriteLine("input: " + input);
            Console.WriteLine("Length: " + input.Length);

            if (input.Length != 24)
            {
                return false;
            }

            var myParsedRoom = new Room();

            string bookingId = input.Substring(0, 3);
            string hotelNo = input.Substring(3, 3);
            string guestNo = input.Substring(6,3);
            string roomNo = input.Substring(9, 3);
            string fromDate = input.Substring(12,6);
            string toDate = input.Substring(18,6);

            int bookingIdResult;
            bool bookingIdOk = Int32.TryParse(bookingId, out bookingIdResult);

            int hotelNoResult;
            bool hotelNoOk = Int32.TryParse(hotelNo, out hotelNoResult);

            int guestNoResult;
            bool guestNoOK = Int32.TryParse(guestNo,out guestNoResult); 

            int roomNoResult;
            bool roomOk = Int32.TryParse(roomNo, out roomNoResult);

            string dateformat = "ddMMyy";
            
            DateTime fromDateResult = new DateTime();
            bool fromDateOK = DateTime.TryParseExact(fromDate,dateformat,CultureInfo.InvariantCulture,DateTimeStyles.None,out fromDateResult);

            DateTime toDateResult = new DateTime();
            bool toDateOK = DateTime.TryParseExact(fromDate, dateformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateResult);


            bool isParsedOk = roomOk && hotelNoOk && bookingIdOk;

            if (isParsedOk)
            {
                this.BookingId = bookingIdResult;
                this.RoomNo = roomNoResult;
                this.HotelNo = hotelNoResult;
                //this.GuestNo = guestNoResult;
                this.FromDate = fromDateResult;
                this.ToDate  = toDateResult;
            }

            return isParsedOk;
        }
    }
}
