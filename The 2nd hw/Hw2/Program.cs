using System;
using System.Collections.Generic;
using System.Reflection;

namespace Hw2
{
    class Program
    {
        static void HotelFunc()
        {
            ReseptionAdministrator reseptionAdministrator = new ReseptionAdministrator();
            Flag1:
                Console.WriteLine("If you want to check in press 1");
                Console.WriteLine("If you want to moved out press 2");
                var answer = Console.ReadLine();
            if (answer != "1" && answer != "2")
            {
                Console.WriteLine("No offer with this code");
                goto Flag1;
            }
            switch (answer)
            {
                case "1":
                    Console.WriteLine("Write your name, please");
                    var name = Console.ReadLine();
                    Console.WriteLine("Write wanted room type, please");
                    var roomType = Console.ReadLine();
                    if (roomType != "Single" && roomType != "Double" && roomType != "Lux" && 
                        roomType != "single" && roomType != "double" && roomType != "lux")
                    {
                        Console.WriteLine("No rooms with this room type");
                        goto case "1";
                    }
                    reseptionAdministrator.CheckIn(name, roomType);
                    break;
                case "2":
                    Console.WriteLine("Write your room, please");
                    int room = Convert.ToInt16(Console.ReadLine());
                    reseptionAdministrator.CheckOut(room);
                    break;
            }
        }

        static void SeniorAdminFunc()
        {
            SeniorAdministrator seniorAdministrator = new SeniorAdministrator();
            Flag2:
                Console.WriteLine("If you want to get information about all guests press 1");
                Console.WriteLine("If you want to get information about guests on the floor press 2");
                Console.WriteLine("If you want to get information about guests in the room press 3");
                var answer = Console.ReadLine();
            if (answer != "1" && answer != "2" && answer != "3")
            {
                Console.WriteLine("No offer with this code");
                goto Flag2;
            }

            var list = new List<string>();
            switch (answer)
            {
                case "1":
                    list = seniorAdministrator.ChooseAllGuests();
                    foreach (var t in list)
                    {
                        Console.WriteLine(t);
                    }
                    break;
                case "2":
                    Console.WriteLine("Write the floor, please");
                    list = seniorAdministrator.ChooseFloorGuests(Convert.ToInt16(Console.ReadLine()));
                    foreach (var t in list)
                    {
                        Console.WriteLine(t);
                    }
                    break;
                case "3":
                    Console.WriteLine("Write the room, please");
                    var room = Convert.ToInt16(Console.ReadLine());
                    if (room < 1001 || room > 3003)
                    {
                        Console.WriteLine("There is no room with this number");
                        goto case "3";
                    }
                    var s = seniorAdministrator.ChooseRoomGuest(room);
                    Console.WriteLine(s);
                    break;
            }
        }

        static void Main(string[] args)
        {
            ask:
                Console.WriteLine("If you are hotel guest press H, if you are restaurant guest press R");
                Console.WriteLine("If you are a senior administrator press F");
                string ans = Console.ReadLine();
            if (ans != "f" && ans != "F" &&
                ans != "r" && ans != "R" &&
                ans != "h" && ans != "H")
            {
                Console.WriteLine("No offer with this code");
                goto ask;
            }
            else if (ans == "H" || ans == "h")
            {
                HotelFunc();
                goto ask;
            }
            else if(ans == "F" || ans == "f")
            {
                SeniorAdminFunc();
                goto ask;
            }
        }
    }
}