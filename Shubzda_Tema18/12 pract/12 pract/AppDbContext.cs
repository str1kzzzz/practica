using Microsoft.EntityFrameworkCore;

namespace _12_pract
{
    public class AppDbContext : DbContext
    {
        public DbSet<EventModel> Events { get; set; }
        public DbSet<ParticipantModel> Participants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantModel>()
                .HasOne(p => p.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.EventId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
