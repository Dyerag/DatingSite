using DatingProgram.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingProgram.Data
{
    public class DatingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Like> Likes { get; set; }

        public DatingContext(DbContextOptions<DatingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary key of City not to be an identity column
            modelBuilder.Entity<City>()
                .Property(c => c.Zipcode)
                .ValueGeneratedNever();

            // Configure many-to-many relationship
            modelBuilder.Entity<Like>()
                .HasKey(pc => new { pc.SenderId, pc.ReceiverId });

            modelBuilder.Entity<Like>()
                .HasOne(pc => pc.Sender)
                .WithMany(p => p.SentLikes)
                .HasForeignKey(pc => pc.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
            .HasOne(pc => pc.Receiver)
            .WithMany(c => c.ReceivedLikes)
            .HasForeignKey(pc => pc.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
