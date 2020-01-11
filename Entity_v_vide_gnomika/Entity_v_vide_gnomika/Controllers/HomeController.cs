using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entity_v_vide_gnomika.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_v_vide_gnomika.Controllers
{
    public class HomeController : Controller
    {
        MyDatabase db;
        public HomeController(MyDatabase context)
        {
            this.db = context;
            //context.Database.EnsureDeleted();
            if (!db.Rooms.Any())
            {
                Room room1 = new Room { Number = "1001" };
                Room room2 = new Room { Number = "1002" };
                Room room3 = new Room { Number = "1003" };
                Room room4 = new Room { Number = "1004" };
                Room room5 = new Room { Number = "1005" };

                Guest guest1 = new Guest
                {
                    Name = "Anna",
                    Age = 19,
                    Room = room1
                };
                Guest guest2 = new Guest
                {
                    Name = "Maria",
                    Age = 20,
                    Room = room2
                };
                Guest guest3 = new Guest
                {
                    Name = "Ivan",
                    Age = 22,
                    Room = room2
                };
                Guest guest4 = new Guest
                {
                    Name = "Daria",
                    Age = 19,
                    Room = room1
                };
                Guest guest5 = new Guest
                {
                    Name = "John",
                    Age = 45,
                    Room = room5
                };
                Guest guest6 = new Guest
                {
                    Name = "Elizabeth",
                    Age = 42,
                    Room = room5
                };
                Guest guest7 = new Guest
                {
                    Name = "Pablo",
                    Age = 28,
                    Room = room3
                };
                Guest guest8 = new Guest
                {
                    Name = "Xavier",
                    Age = 27,
                    Room = room3
                };
                Guest guest9 = new Guest
                {
                    Name = "Raul",
                    Age = 29,
                    Room = room3
                };
                Guest guest10 = new Guest
                {
                    Name = "Aleksandr Alekseevich",
                    Age = 26,
                    Room = room4
                };

                db.Rooms.AddRange(room1, room2, room3, room4, room5);
                db.Guests.AddRange(guest1, guest2, guest3, guest4, guest5, guest6,
                    guest7, guest8, guest9, guest10);
                db.SaveChanges();

            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Eager()
        {
            var guests = db.Guests.Include(u => u.Room).ToList();
            return View(guests);
        }

        public IActionResult Explicit()
        {
            Room room = db.Rooms.FirstOrDefault();
            db.Guests.Where(p => p.RoomId == room.Id).Load();
            return View(db.Guests.ToList());
        }

        public IActionResult Lazy()
        {
            var guests = db.Guests.ToList();
            return View(guests);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}