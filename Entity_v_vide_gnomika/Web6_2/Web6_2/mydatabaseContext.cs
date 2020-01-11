using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web6_2
{
    public partial class mydatabaseContext : DbContext
    {
        public mydatabaseContext()
        {
        }

        public mydatabaseContext(DbContextOptions<mydatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mydatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guests>(entity =>
            {
                entity.HasIndex(e => e.RoomId);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.RoomId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
