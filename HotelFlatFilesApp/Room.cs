using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFlatFilesApp
{
    public class Room
    {
        //Record layout
        //1-3 RoomNo
        //4-6 Hotelno
        //7-7 RoomType
        //8-12 Price

        public Room()
        {

        }

        public int RoomNo { get; set; }
        public int HotelNo { get; set; }
        public RoomType Types { get; set; }
        public int Price { get; set; }


        //public static bool TryParse(string input, out Room room)
        //{
        //    var myParsedRoom = new Room();

        //    room = null;
        //    string roomNo = input.Substring(1, 3);
        //    string hotelNo = input.Substring(4, 3);
        //    string roomType = input.Substring(7, 1);
        //    string price = input.Substring(8, 5);

        //    int roomNoResult;
        //    bool roomOk = Int32.TryParse(roomNo, out roomNoResult);

        //    int hotelNoResult;
        //    bool hotelNoOk = Int32.TryParse(hotelNo, out hotelNoResult);

        //    RoomType roomTypeResult;
        //    bool roomTypeOk = Enum.TryParse(roomType, out roomTypeResult);

        //    int priceResult;
        //    bool priceOK = Int32.TryParse(price, out priceResult);

        //    bool isParsedOk = roomOk || hotelNoOk || roomTypeOk || priceOK;

        //    if (isParsedOk)
        //    {
        //        myParsedRoom.RoomNo = roomNoResult;
        //        myParsedRoom.HotelNo = hotelNoResult;
        //        myParsedRoom.Types = roomTypeResult;
        //        myParsedRoom.Price = priceResult;
        //    }
        //    room = myParsedRoom;

        //    return isParsedOk;
        //}

        /// <summary>
        /// a method that takes a string of length 12
        /// and parse it to a Room object
        /// Record layout for Room
        ///  1-3 RoomNo
        ///  4-6 Hotelno
        ///  7-7 RoomType
        ///  8-12 Price
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool TryParse(string input)
        {
            Console.WriteLine("input: "+ input);
            Console.WriteLine("Length: "+ input.Length);
           
            var myParsedRoom = new Room();

            string roomNo = input.Substring(0, 3);
            string hotelNo = input.Substring(2, 3);
            string roomType = input.Substring(6, 1);
            string price = input.Substring(6, 5);

            int roomNoResult;
            bool roomOk = Int32.TryParse(roomNo, out roomNoResult);

            int hotelNoResult;
            bool hotelNoOk = Int32.TryParse(hotelNo, out hotelNoResult);

            RoomType roomTypeResult;
            bool roomTypeOk = Enum.TryParse(roomType, out roomTypeResult);

            int priceResult;
            bool priceOK = Int32.TryParse(price, out priceResult);
            // bool priceOK = Int32.TryParse(price28, out priceResult28);
            priceResult += 28;//is that really necessary ??

            bool isParsedOk = roomOk && hotelNoOk && roomTypeOk && priceOK;

            if (isParsedOk)
            {
                this.RoomNo = roomNoResult;
                this.HotelNo = hotelNoResult;
                this.Types = roomTypeResult;
                this.Price = priceResult;
            }

            return isParsedOk;
        }


    }

    public enum RoomType
    {
        Single = 1,
        Double = 2,
        Family = 3
    }
}
