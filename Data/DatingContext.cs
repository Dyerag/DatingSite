using DatingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Data
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

            modelBuilder.Entity<Account>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");

            //add somne data to the database
            modelBuilder.Entity<City>().HasData(
                new City { Zipcode = 2000, CityName = "Frederiksberg" },
                new City { Zipcode = 2625, CityName = "Vallensbæk" },
                new City { Zipcode = 2650, CityName = "Hvidovre" },
                new City { Zipcode = 2700, CityName = "Brønshøj" },
                new City { Zipcode = 2730, CityName = "Herlev" },
                new City { Zipcode = 2740, CityName = "Skovlunde" },
                new City { Zipcode = 2791, CityName = "Dragør" },
                new City { Zipcode = 2860, CityName = "Søborg" },
                new City { Zipcode = 2980, CityName = "Kokkedal" },
                new City { Zipcode = 4293, CityName = "Dianalund" }
                );

            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 1, Zipcode = 2700, Firstname = "Palle", Lastname = "Westermann", Email = "pwe@tec.dk", Username = "a1", Password = "a2", Birthdate = new DateOnly(1967, 07, 26) },
                new Account { AccountId = 2, Zipcode = 4293, Firstname = "Nie", Lastname = "Finkam", Email = "Nikam@Outlook.com", Username = "panini", Password = "ni", Birthdate = new DateOnly(2004, 07, 30) },
                new Account { AccountId = 3, Zipcode = 2791, Firstname = "Albus", Lastname = "Dumbledore", Email = "Wizmaster@gmail.com", Username = "Al", Password = "Wizard", Birthdate = new DateOnly(2000, 01, 01), IsDeleted = true },
                new Account { AccountId = 4, Zipcode = 2000, Firstname = "Victor", Lastname = "Stone", Email = "VicTec@hotmail.dk", Username = "Cyborg", Password = "Titan", Birthdate = new DateOnly(1932, 10, 18), IsDeleted = true }
                );

            modelBuilder.Entity<Profile>().HasData(
                new Profile { ProfileId = 1, Height = 162, Weight = 0, Birthdate = new DateOnly(1967, 07, 26), Nickname = "Android 13", Gender = Gender.Male },
                new Profile { ProfileId = 2, Height = 80, Weight = 20, Birthdate = new DateOnly(2004, 07, 30), Nickname = "Nicki", Gender = Gender.Female },
                new Profile { ProfileId = 3, Birthdate = new DateOnly(2000, 01, 01), Nickname = "GrandMaster", Gender = Gender.Male, IsDeleted = true },
                new Profile { ProfileId = 4, Height = 212, Weight = 194, Birthdate = new DateOnly(1932, 10, 18), Nickname = "Booyah", Gender = Gender.Male, IsDeleted = true }
                );
        }
    }
}
