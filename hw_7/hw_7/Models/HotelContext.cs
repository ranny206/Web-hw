using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_7.Models
{
    public class HotelContext: DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
