using GoSportData.Classes;
using Microsoft.EntityFrameworkCore;

namespace GoSportData
{
    public class GoDbContext : DbContext
    {
        public GoDbContext(DbContextOptions<GoDbContext> options) : base(options)
        {
         
        }
        public DbSet<Genders> Gender { get; set; }
        public DbSet<LoginTokens> LoginTokens { get; set; }
        public DbSet<Registrations> Registrations { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Sports> Sports { get; set; }
        public DbSet<Tournaments> Tournaments { get; set;}
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Key Generated On Add
            modelBuilder.Entity<Genders>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<LoginTokens>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Registrations>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Results>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sports>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tournaments>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Users>().Property(c => c.Id).ValueGeneratedOnAdd();

            // Unique Column
            modelBuilder.Entity<Users>().HasIndex(c => c.Email).IsUnique();

            // Database Seeding

            modelBuilder.Entity<Users>().HasData(new Users[]
            {
                new Users
                {
                    Id = 1,
                    FirstName = "Julien",
                    LastName = "Wimmer",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    BirthDate = DateTime.Parse("20-08-2020"),
                    Email = "julien.w68@hotmail.fr"
                },
                new Users
                {
                    Id = 2,
                    FirstName = "Bot",
                    LastName = "2",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    BirthDate = DateTime.Parse("20-08-2020"),
                    Email = "bot2@hotmail.fr"
                },
                new Users
                {
                    Id = 3,
                    FirstName = "Bot",
                    LastName = "3",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    BirthDate = DateTime.Parse("20-08-2020"),
                    Email = "bot3@hotmail.fr"
                },
                new Users
                {
                    Id = 4,
                    FirstName = "Bot",
                    LastName = "4",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    BirthDate = DateTime.Parse("20-08-2020"),
                    Email = "bot4@hotmail.fr"
                },
                new Users
                {
                    Id = 5,
                    FirstName = "Bot",
                    LastName = "5",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    BirthDate = DateTime.Parse("20-08-2020"),
                    Email = "bot5@hotmail.fr"
                },
                new Users
                {
                    Id = 6,
                    FirstName = "Bot",
                    LastName = "6",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    BirthDate = DateTime.Parse("20-08-2020"),
                    Email = "bot6@hotmail.fr"
                }
            });


            modelBuilder.Entity<Sports>().HasData(new Sports[]{ 
                new Sports
                {
                    Id = 1,
                    Name = "Boxe"
                },
                new Sports
                {
                    Id = 2,
                    Name = "Judo"
                },
                new Sports
                {
                    Id = 3,
                    Name = "Lutte"
                },
                new Sports
                {
                    Id = 4,
                    Name = "Natation"
                },
                new Sports
                {
                    Id = 5,
                    Name = "Triathlon"
                },
                new Sports
                {
                    Id = 6,
                    Name = "Badminton"
                },
                new Sports
                {
                    Id = 7,
                    Name = "Plongeon"
                },
                new Sports
                {
                    Id = 8,
                    Name = "Tennis"
                },
                new Sports
                {
                    Id = 9,
                    Name = "Tennis de Table"
                },
                new Sports
                {
                    Id = 10,
                    Name = "Cyclisme"
                }
            });
            modelBuilder.Entity<Genders>().HasData(new Genders[]
            {
                new Genders
                {
                    Id = 1,
                    Name = "Homme"
                },
                new Genders
                {
                    Id = 2,
                    Name = "Femme"
                },
                new Genders
                {
                    Id = 3,
                    Name = "Mixte"
                }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}