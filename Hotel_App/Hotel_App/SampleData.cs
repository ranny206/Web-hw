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
                            RoomType = "Single",
                            Price = "100$",
                            IsClean = true,
                            IsOccupied = false
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
                            RoomType = "Double",
                            Price = "150$",
                            IsClean = true,
                            IsOccupied = false
                        }
                    );
                }

                room = 3001;
                for (var i = 0; i < 3; i++)
                {
                    context.Rooms.Add(
                        new Room
                        {
                            Number = room,
                            RoomType = "Lux",
                            Price = "500$",
                            IsClean = true,
                            IsOccupied = false
                        }
                    );
                }
            }
            context.SaveChanges();
        }
    }
}