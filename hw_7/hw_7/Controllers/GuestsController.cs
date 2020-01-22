using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using hw_7.Models;
using System.Threading.Tasks;

namespace hw_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        HotelContext db;
        public GuestsController(HotelContext context)
        {
            db = context;
            if (!db.Guests.Any())
            {
                Guest guest1 = new Guest
                {
                    Name = "Anna",
                    Age = 19
                };
                Guest guest2 = new Guest
                {
                    Name = "Maria",
                    Age = 20
                };
                Guest guest3 = new Guest
                {
                    Name = "Ivan",
                    Age = 22
                };
                Guest guest4 = new Guest
                {
                    Name = "Daria",
                    Age = 19
                };
                Guest guest5 = new Guest
                {
                    Name = "John",
                    Age = 45
                };
                Guest guest6 = new Guest
                {
                    Name = "Elizabeth",
                    Age = 42
                };
                Guest guest7 = new Guest
                {
                    Name = "Pablo",
                    Age = 28
                };
                Guest guest8 = new Guest
                {
                    Name = "Xavier",
                    Age = 27
                };
                Guest guest9 = new Guest
                {
                    Name = "Raul",
                    Age = 29
                };
                Guest guest10 = new Guest
                {
                    Name = "Aleksandr Alekseevich",
                    Age = 26
                };

                db.Guests.AddRange(guest1, guest2, guest3, guest4, guest5, guest6,
                    guest7, guest8, guest9, guest10);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> Get()
        {
            return await db.Guests.ToListAsync();
        }

        // GET api/guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> Get(int id)
        {
            Guest guest = await db.Guests.FirstOrDefaultAsync(x => x.Id == id);
            if (guest == null)
                return NotFound();
            return new ObjectResult(guest);
        }

        // POST api/guests
        [HttpPost]
        public async Task<ActionResult<Guest>> Post(Guest guest)
        {
            if (guest == null)
            {
                return BadRequest();
            }

            db.Guests.Add(guest);
            await db.SaveChangesAsync();
            return Ok(guest);
        }

        // PUT api/guests/
        [HttpPut]
        public async Task<ActionResult<Guest>> Put(Guest guest)
        {
            if (guest == null)
            {
                return BadRequest();
            }
            if (!db.Guests.Any(x => x.Id == guest.Id))
            {
                return NotFound();
            }

            db.Update(guest);
            await db.SaveChangesAsync();
            return Ok(guest);
        }

        // DELETE api/guests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guest>> Delete(int id)
        {
            Guest guest = db.Guests.FirstOrDefault(x => x.Id == id);
            if (guest == null)
            {
                return NotFound();
            }
            db.Guests.Remove(guest);
            await db.SaveChangesAsync();
            return Ok(guest);
        }
    }
}