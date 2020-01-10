using Microsoft.EntityFrameworkCore;

namespace FilterSortPagingApp.Models
{
    public class MyDatabase : DbContext
    {
        public DbSet<Guest> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public MyDatabase(DbContextOptions<MyDatabase> options)
            : base(options)
        {
           Database.EnsureCreated();
        }
    }
}