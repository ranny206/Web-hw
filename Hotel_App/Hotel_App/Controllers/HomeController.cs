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
        public IActionResult Index()
        {
            return View(_database.Rooms.ToList());
        }
    }
}
