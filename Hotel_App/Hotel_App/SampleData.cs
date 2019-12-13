using System.Linq;
using Hotel_App.Models;

namespace Hotel_App
{
    public class SampleData
    {
        public static void Initialize(Database context)
        { 
            //context.Database.EnsureDeleted();
            if (!context.Rooms.Any())
            {
                var room = 1001;
                for (var i = 0; i < 5; i++)
                {
                    context.Rooms.Add(
                        new Room
                        {
                            Number = room,
                            Floor = 1,
                            RoomType = "Single",
                            Price = "100$"
                        }
                    );
                    room++;
                }

                room = 2001;
                for (var i = 0; i < 5; i++)
                {
                    context.Rooms.Add(
                        new Room
                        {
                            Number = room,
                            Floor = 2,
                            RoomType = "Double",
                            Price = "150$"
                        }
                    );room++;
                    
                }

                room = 3001;
                for (var i = 0; i < 3; i++)
                {
                    context.Rooms.Add(
                        new Room
                        {
                            Number = room,
                            Floor = 3,
                            RoomType = "Lux",
                            Price = "500$"
                        }
                    );
                    room++;
                }
            }

            if (!context.Guests.Any())
            {
                context.Guests.Add(
                    new Guest
                    {
                        Name = "Anna Rasputnaia",
                        Age = 19,
                        Country = "Russia",
                        Room = 1001
                    });
                context.Guests.Add(
                    new Guest
                    {
                        Name = "Daria Ribka",
                        Age = 19,
                        Country = "Russia",
                        Room = 1002
                    });
                context.Guests.Add(
                    new Guest
                    {
                        Name = "James McAvoy",
                        Age = 40,
                        Country = "scotland",
                        Room = 3002
                    });
            }
            context.SaveChanges();
        }
    }
}