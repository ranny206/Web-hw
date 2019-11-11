using System;
using System.Linq;
using Hotel;

namespace Hw2
{
    public class ReseptionAdministrator: Administrator
    {
        public override bool CheckTypeWithType(string type)
        {
            base.CheckTypeWithType(type);
            return (type == "Lux" || type == "lux");
        }

        public override bool CheckTypeWithNumber(int number)
        {
            base.CheckTypeWithNumber(number);
            return number / 1000 == 3;
        }

        public override void CheckIn(string name, string roomType)
        {
            base.CheckIn(name, roomType);
            var guest = new HotelGuest(name);
            var isFound = false;
            if (CheckTypeWithType(roomType))
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
            else
            {
                for (var i = 0; i < Hotel.Rooms.Capacity; i++)
                {
                    if (Hotel.Rooms[i].IsOccupied) continue;
                    isFound = true;
                    guest.Room = Hotel.Rooms[i].Number;
                    Hotel.HotelGuests.Add(guest);
                    Hotel.Rooms[i].IsOccupied = true;
                    if (!Hotel.Rooms[i].IsClean)
                    {
                        var cleaning = new Cleaning();
                        cleaning.Clean(Hotel.Rooms[i].Number);
                    }
                    break;
                }

                if (isFound)
                {
                    Console.WriteLine("Your room is {0}", guest.Room);
                }
                else{
                    Console.WriteLine("No rooms is found for today, we can search for another room type. " +
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
                for (var i = 0; i < Hotel.HotelGuests.Count; i++)
                {
                    if (Hotel.HotelGuests[i].Room == room)
                    {
                        Hotel.HotelGuests.Remove(Hotel.HotelGuests[i]);
                    }
                }
                if (!CheckTypeWithNumber(room))
                {
                    for (var i = 0; i < Hotel.Rooms.Capacity; i++)
                    {
                        if (Hotel.Rooms[i].Number != room) continue;
                        Hotel.Rooms[i].IsClean = false;
                        Hotel.Rooms[i].IsOccupied = false;
                    }
                }
                else
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
                Console.WriteLine("You moved out successfully");
            }
        }
    }
}