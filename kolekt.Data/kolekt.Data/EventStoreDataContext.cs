using kolekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace kolekt.Data
{
    public class EventStoreDataContext : DbContext
    {
        public EventStoreDataContext(DbContextOptions<EventStoreDataContext> options) : base(options)
        {
        }

        public virtual DbSet<EventEntity> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>()
                .HasIndex(p => new { p.Version, p.AggregateId })
                .IsUnique();
        }
    }
}
