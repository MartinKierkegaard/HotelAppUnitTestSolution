using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFlatFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region init hotels
            var hotels = new List<Hotel>()//new Hotel[]
            {
                new Hotel() {HotelNo = 1, Name = "The Pope", Address = "Vaticanstreet 1  1111 Bishopcity"},
                new Hotel() {HotelNo = 2, Name = "Lucky Star", Address = "Lucky Road 12  2222 Hometown"},
                new Hotel() {HotelNo = 3, Name = "Discount", Address = "Inexpensive Road 7 3333 Cheaptown"},
                new Hotel() {HotelNo = 4, Name = "deLuxeCapital", Address = "Luxury Road 99  4444 Luxus"},
                new Hotel() {HotelNo = 5, Name = "Discount", Address = "Inexpensive Road 7 3333 Cheaptown"},
                new Hotel() {HotelNo = 6, Name = "Prindsen", Address = "Algade 5, 4000 Roskilde"},
                new Hotel() {HotelNo = 7, Name = "Scandic", Address = "Algade 5, 4000 Roskilde"},
            };
            #endregion

            //Record layout
            //1-3 RoomNo
            //4-6 Hotelno
            //7-7 RoomType
            //8-12 Price
        //public static string roomdata1 = "100001200340";
        var flatRoomData = new List<string>();
            flatRoomData.Add("100001200340");
            flatRoomData.Add("200001100240");
            flatRoomData.Add("300001200390");
            flatRoomData.Add("400001300340");
            flatRoomData.Add("110002101000");
            flatRoomData.Add("110002300340");
            flatRoomData.Add("210002202500");
            flatRoomData.Add("310002200340");
            //flatRoomData.Add("310z02200340");//with error            
            //flatRoomData.Add("310002900340");//with error            

            //Record layout Booking
            //1-3 BookingId
            //4-6 HotelNo
            //7-9 GuestNo
            //10-12 RoomNo
            //13-18 FromDate
            //19-24 ToDate

            //public static string BookingData1 = "001001234100101115121115";
            var flatBookingData = new List<string>();
            flatBookingData.Add("001001234100101115121115");
            flatBookingData.Add("002001235200101115121115");
            flatBookingData.Add("003001237300101115121115");
            flatBookingData.Add("004001299400101115121115");
            flatBookingData.Add("005002456210121115121115");
            flatBookingData.Add("006002646310101115121115");
            //flatBookingData.Add("007002534210121016310216");//with error 
            //flatBookingData.Add("00700l534210121115171115");//with error 

            var errorRoomData = new List<string>();
            var errorBookingData = new List<string>();

            var roomList = new List<Room>();
            var bookingList = new List<Booking>();

            //Start to code here

            //exercise 1
            //Parse to int 
            string int1 = "200";
            string int2 = "003";
            string int3 = "10.1";

            //exercise 2
            //Parse to decimal
            string decimal1 = "200";
            string decimal2 = "1.365,23";
            string decimal3 = "23,453.12"; //remember cultureinfo en-Gb and style
            string decimal4 = "£23,453.12"; //remember cultureinfo en-Gb and style

            //exercise 3
            //Parse to enum RoomType
            string enum1 = "2";
            string enum2 = "4";

            //exercise 4
            //test if enum2 is defined in the RoomType enum

            //exercise 5
            //parse to DateTime
            //10 .november 2015
            string date1 = "10-11-2015"; //remember cultureinfo da-dk 
            string date2 = "101115";  //use TryParseExact 

            //exercise 6
            //create a method that takes a textstring and parse the data to a Room Object
            //Remember to look at the recordlayout , use the method Substring to cut the textsstring in pieces
            //put the result in a List<Room>

            foreach (var textline in flatRoomData)
            {
                var Room = new Room();
                bool OK =  Room.TryParse(textline);

                if (OK)
                {
                    roomList.Add(Room);
                }
                else
                {
                    errorRoomData.Add(textline);
                }
            }

            //exercise 7
            //create a method that takes a textstring and parse the data to a Booking Object
            //remember to look at the recordlayout
            //Put the result in a List<Booking> 

            foreach (var line in flatBookingData)
            {
                var booking = new Booking();
                bool OK = booking.TryParse(line);

                if (OK)
                {
                    bookingList.Add(booking);
                }
                else
                {
                    errorBookingData.Add(line);
                }


            }

            //exercise 8
            //add data with error to the flatBookingdata and the flatRoomData
            //If a line has an error put the data in the error list 
            //errorRoomData or errorBookingData


            //exercise 9
            //create a method for the booking  so that you can generate a line of flatdata that 
            //matches the recordlayout 

            Console.ReadLine();
        }
    }
}
