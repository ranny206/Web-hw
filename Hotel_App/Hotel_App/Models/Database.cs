using Microsoft.EntityFrameworkCore;

namespace Hotel_App.Models
{
    public  class Database : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public Database(DbContextOptions<Database> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}