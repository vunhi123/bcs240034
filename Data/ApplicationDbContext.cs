using Microsoft.EntityFrameworkCore;
using MID_BCS240034.Models;

namespace MID_BCS240034.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event_BCS240034> Events_BCS240034 { get; set; }

        public DbSet<EventCategory_BCS240034> EventCategories_BCS240034 { get; set; }

        public DbSet<EventImage_BCS240034> EventImages_BCS240034 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event_BCS240034>()
                .HasIndex(e => new { e.Name, e.StartDate })
                .IsUnique();
        }
    }
}
