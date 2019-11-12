using System;
using System.Linq;
using Hotel;

namespace Hw2
{
    public class ReseptionAdministrator: Administrator
    {
        public override int CheckTypeWithType(string type)
        {
            base.CheckTypeWithType(type);
            if (type == "Lux" || type == "lux")
            {
                return 3;
            }
            if (type == "Single" || type == "single")
            {
                return 1;
            }
            if (type == "Double" || type == "double")
            {
                return 2;
            }

            return 4;
        }

        public override int CheckTypeWithNumber(int number)
        {
            base.CheckTypeWithNumber(number);
            switch (number / 1000)
            {
                case 3:
                    return 3;
                case 2:
                    return 2;
                case 1:
                    return 1;
                default:
                    return 4;
            }
        }

        public override void CheckIn(string name, string roomType)
        {
            base.CheckIn(name, roomType);
            var guest = new HotelGuest(name);
            var isFound = false;
            if (CheckTypeWithType(roomType) == 3)
            {
                for (var i = 0; i < Hotel.Lux.Capacity; i++)
                {
                    if (Hotel.Lux[i].IsOccupied) continue;
                    isFound = true;
                    guest.Room = Hotel.Lux[i].Number;
                    Hotel.HotelGuests.Add(guest);
                    Hotel.Lux[i].IsOccupied = true;
                    var cleaning = new Cleaning();
                    if (!Hotel.Lux[i].IsClean)
                    {
                        cleaning.Clean(Hotel.Lux[i].Number);
                    }
                    cleaning.BringBaggage(Hotel.Lux[i].Number);
                    break;
                }
            }
            else if(CheckTypeWithType(roomType) == 1)
            {
                for (var i = 0; i < Hotel.Doubles.Capacity; i++)
                {
                    if (Hotel.Singles[i].IsOccupied) continue;
                    isFound = true;
                    guest.Room = Hotel.Singles[i].Number;
                    Hotel.HotelGuests.Add(guest);
                    Hotel.Singles[i].IsOccupied = true;
                    if (!Hotel.Singles[i].IsClean)
                    {
                        var cleaning = new Cleaning();
                        cleaning.Clean(Hotel.Singles[i].Number);
                    }
                    break;
                }
            }
            else if(CheckTypeWithType(roomType) == 2)
            {
                foreach (var t in Hotel.Doubles.Where(t => !t.IsOccupied))
                {
                    isFound = true;
                    guest.Room = t.Number;
                    Hotel.HotelGuests.Add(guest);
                    Console.WriteLine("Write the name of the second person");
                    var secondName = Console.ReadLine();
                    var secondGuest = new HotelGuest(secondName);
                    secondGuest.Room = t.Number;
                    Hotel.HotelGuests.Add(secondGuest);
                    t.IsOccupied = true;
                    if (!t.IsClean)
                    {
                        var cleaning = new Cleaning();
                        cleaning.Clean(t.Number);
                    }

                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine("Your room is {0}", guest.Room);
            }
            else
            {
                Console.WriteLine("No rooms is found for this dates, we can search for another room type. " +
                                  "Write new room type or no, please");
                var answer = Console.ReadLine();
                if (answer != "no")
                {
                    CheckIn(name, answer);
                }
                else
                {
                    Console.WriteLine("Thank you for visiting");
                }
            }
        }

        public override void CheckOut(int room)
        {
            base.CheckOut(room);
            if (Hotel.HotelGuests.Count == 0)
            {
                Console.WriteLine("No guests, please, check in");
            }
            else if (room > 3003 || room < 1001)
            {
                Console.WriteLine("Room doesn`t exists");
            }
            else
            {
                bool isMovedOut = false;
                for (var i = 0; i < Hotel.HotelGuests.Count; i++)
                {
                    if (Hotel.HotelGuests[i].Room == room)
                    {
                        Hotel.HotelGuests.Remove(Hotel.HotelGuests[i]);
                        isMovedOut = true;
                    }
                }

                if (isMovedOut)
                {
                    if (CheckTypeWithNumber(room) == 1)
                    {
                        for (var i = 0; i < Hotel.Singles.Capacity; i++)
                        {
                            if (Hotel.Singles[i].Number != room) continue;
                            Hotel.Singles[i].IsClean = false;
                            Hotel.Singles[i].IsOccupied = false;
                        }
                    }
                    else if(CheckTypeWithNumber(room) == 3)
                    {
                        for (var i = 0; i < Hotel.Lux.Capacity; i++)
                        {
                            if (Hotel.Lux[i].Number != room) continue;
                            Hotel.Lux[i].IsClean = false;
                            Hotel.Lux[i].IsOccupied = false;  
                            var cleaning = new Cleaning();
                            cleaning.CarryBaggage(Hotel.Lux[i].Number);
                        }
                    }
                    else if (CheckTypeWithNumber(room) == 2)
                    {
                        for (var i = 0; i < Hotel.Doubles.Capacity; i++)
                        {
                            if (Hotel.Doubles[i].Number != room) continue;
                            Hotel.Doubles[i].IsClean = false;
                            Hotel.Doubles[i].IsOccupied = false;
                        }
                    }
                    Console.WriteLine("You moved out successfully");
                }
                else
                {
                    Console.WriteLine("No guests in this room");
                }
            }
        }
    }
}