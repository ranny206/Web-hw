using System;
using System.Globalization;

namespace Hotel
{
    public class Room
    {
        public readonly int Number;
        public bool IsClean;
        public bool IsOccupied;
        public readonly string RoomType;

        public Room(int number, bool isClean, bool isOccupied, string roomType)
        {
            Number = number;
            IsClean = isClean;
            IsOccupied = isOccupied;
            RoomType = roomType;
        }
    }
}