using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotel_App.Models;

namespace Hotel_App.Controllers
{
    public class HomeController : Controller
    {
        Database _database;
        public HomeController(Database context)
        {
            _database = context;
        }

        public IActionResult Main()
        {
            return View();
        }
        
        public IActionResult Index(string searchString)
        {
            if (searchString == null)
            {
                return View(_database.Rooms.ToList());
            }
            List<Room> rooms = _database.Rooms.Where(item =>
                item.Number.ToString().Contains(searchString) ||
                item.Price.Contains(searchString) ||
                item.RoomType.Contains(searchString) ||
                item.Floor.ToString().Contains(searchString)).ToList();
            return View(rooms);
        }
        
        public IActionResult Index1(string searchString)
        {
            if (searchString == null)
            {
                return View(_database.Guests.ToList());
            }
            List<Guest> guests = _database.Guests.Where(item =>
                item.Name.Contains(searchString)||
                item.Age.ToString().Contains(searchString) ||
                item.Country.Contains(searchString) ||
                item.Room.ToString().Contains(searchString)).ToList();
            return View(guests);
        }

        [HttpGet]
        public IActionResult AddNewRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewRoom(int number, string roomType, string price, int floor)
        {
            var room = new Room
            {
                Number = number,
                Floor = floor,
                RoomType = roomType,
                Price = price
            };

            if ((room.RoomType == null && room.Price == null) || (room.Number == 0))
            {
                return BadRequest();
            }
            _database.Rooms.Add(room);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RoomInfo(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var room = _database.Rooms.FirstOrDefault(item => item.Id == id);
            if (room == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Room = room;
            return View();
        }
        
        [HttpGet]  
        public IActionResult DeleteRoom(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            } 
            var room = _database.Rooms.FirstOrDefault(item => item.Id == id);
            ViewBag.Room = room;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteRoom(Room room)
        {
            _database.Rooms.Remove(room);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRoom(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            } 
            var room = _database.Rooms.FirstOrDefault(item => item.Id == id);
            ViewBag.Room = room;
            return View();
        }
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            _database.Rooms.Update(room);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult AddNewGuest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewGuest(string name, int age, string country, int room)
        {
            var guest = new Guest
            {
                Name = name,
                Age = age,
                Country = country,
                Room = room
            };

            if ((guest.Name == null && guest.Country == null) || (guest.Room == 0 && guest.Age == 0))
            {
                return BadRequest();
            }
            _database.Guests.Add(guest);
            _database.SaveChanges();
            return RedirectToAction("Index1");
        }
        
        public IActionResult GuestInfo(int? id)
        {
            if (id == null) return RedirectToAction("Index1");
            var guest = _database.Guests.FirstOrDefault(item => item.Id == id);
            if (guest == null)
            {
                return RedirectToAction("Index1");
            }
            ViewBag.Guest = guest;
            return View();
        }
        
        [HttpGet]  
        public IActionResult DeleteGuest(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index1");
            } 
            var guest = _database.Guests.FirstOrDefault(item => item.Id == id);
            ViewBag.Guest = guest;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteGuest(Guest guest)
        {
            _database.Guests.Remove(guest);
            _database.SaveChanges();
            return RedirectToAction("Index1");
        }
        
        [HttpGet]
        public IActionResult EditGuest(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index1");
            } 
            var guest = _database.Guests.FirstOrDefault(item => item.Id == id);
            ViewBag.Guest = guest;
            return View();
        }
        [HttpPost]
        public IActionResult EditGuest(Guest guest)
        {
            _database.Guests.Update(guest);
            _database.SaveChanges();
            return RedirectToAction("Index1");
        }
    }
}
