using System;
using System.Collections.Generic;
using Hotel;

namespace Hw2
{
    public static class Hotel
    {
        public static List<Room> Singles = new List<Room>(10);
        public static List<Double> Doubles = new List<Double>(10);
        public static List<Lux> Lux = new List<Lux>(3);
        public static List<HotelGuest> HotelGuests = new List<HotelGuest>();

        static Hotel()
        {
            var roomNumber = 1001; 
            for (var i = 0; i < 10; i++)
            {
                Singles.Add(new Room(roomNumber,true, false, "Single"));
                roomNumber++;
            }

            roomNumber = 2001;
            for (var i = 0; i < 10; i++)
            {
                Doubles.Add(new Double(roomNumber,true, false, "Double", 
                    false));
                roomNumber++;
            }

            roomNumber = 3001;
            for (var i = 0; i < 3; i++)
            {
                Lux.Add(new Lux(roomNumber, true, false, "Lux", 
                    false, false));
                roomNumber++;
            }
        }
    }
}