using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilterSortPagingApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FilterSortPagingApp.Controllers
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
                Room room1 = new Room { Number = 1001};
                Room room2 = new Room { Number = 1002};
                Room room3 = new Room { Number = 1003};
                Room room4 = new Room { Number = 1004};
                Room room5 = new Room { Number = 1005};

                Guest guest1 = new Guest { Name = "Anna", Age = 19, Country = "Russia", Room = room1, 
                    CreationDate = DateTime.Now};
                Guest guest2 = new Guest {Name = "Maria", Age = 20, Country = "Russia", Room = room2,
                    CreationDate = DateTime.Now};
                Guest guest3 = new Guest { Name = "Ivan", Age = 22, Country = "Ukraine", Room = room2, 
                    CreationDate = DateTime.Now};
                Guest guest4 = new Guest {Name = "Daria", Age = 19, Country = "Russia", Room = room1,
                    CreationDate = DateTime.Now};
                Guest guest5 = new Guest { Name = "John", Age = 45, Country = "USA", Room = room5, 
                    CreationDate = DateTime.Now};
                Guest guest6 = new Guest { Name = "Elizabeth", Age = 42, Country = "USA", Room = room5, 
                    CreationDate = DateTime.Now};
                Guest guest7 = new Guest { Name = "Pablo", Age = 28, Country = "Spain", Room = room3, 
                    CreationDate = DateTime.Now};
                Guest guest8 = new Guest { Name = "Xavier", Age = 27, Country = "Spain", Room = room3, 
                    CreationDate = DateTime.Now};
                Guest guest9 = new Guest { Name = "Raul", Age = 29, Country = "Spain", Room = room3, 
                    CreationDate = DateTime.Now};
                Guest guest10 = new Guest { Name = "Aleksandr Alekseevich", Age = 26, Country = "Russia", 
                    Room = room4, CreationDate = DateTime.Now};
                
                db.Rooms.AddRange(room1, room2, room3, room4, room5);
                db.Users.AddRange(guest1, guest2, guest3, guest4, guest5, guest6, 
                    guest7, guest8, guest9, guest10);
                db.SaveChanges();

            }
        }
        public async Task<IActionResult> Index(int? company, string name, int page = 1, 
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 4;
 
            //фильтрация
            IQueryable<Guest> users = db.Users.Include(x=>x.Room);
 
            if (company != null && company != 1)
            {
                users = users.Where(p => p.RoomId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }
 
            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortState.RoomAsc:
                    users = users.OrderBy(s => s.Room.Number);
                    break;
                case SortState.RoomDesc:
                    users = users.OrderByDescending(s => s.Room.Number);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }
 
            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
 
            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Rooms.ToList(), company, name),
                Users = items
            };
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(string name, int age, string country, int room)
        {
            var room1 = new Room
            {
                Number = room
            };
            
            var guest = new Guest
            {
                Name = name,
                Age = age,
                Country = country,
                Room = room1,
                CreationDate = DateTime.Now
            };

            if ((guest.Name == null && guest.Country == null) || (guest.Age <= 0))
            {
                return BadRequest();
            }
            db.Users.Add(guest);
            db.Rooms.Add(room1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}