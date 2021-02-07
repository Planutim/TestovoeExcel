using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class ApplicationContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=mydb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.ID);
            modelBuilder.Entity<Client>().Property(c => c.Name).HasMaxLength(100);
            //modelBuilder.Entity<Client>().Property(p => p.Address).HasColumnType("varchar");
            //modelBuilder.Entity<Client>().Property(p => p.BirthDate).HasColumnType("date");
            //modelBuilder.Entity<Client>().Property(p => p.SocialNumber).HasColumnType("varchar");
            //modelBuilder.Entity<Client>().Property(p => p.PhoneNumber).HasColumnType("varchar");
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ID = 1,
                    Name = "Тестовый клиент1",
                    BirthDate = DateTime.Parse("1991-03-08"),
                    PhoneNumber = "123",
                    Address = "г.Баткен",
                    SocialNumber = "12345678901234"
                },
                new Client
                {
                    ID = 2,
                    Name = "Тестовый клиент2",
                    BirthDate = DateTime.Parse("1996-04-20"),
                    PhoneNumber = "456",
                    Address = "г.Бишкек",
                    SocialNumber = "98765432101234",
                },
                new Client
                {
                    ID = 3,
                    Name = "Тестовый клиент3",
                    BirthDate = DateTime.Parse("1995-08-04"),
                    PhoneNumber = "789",
                    Address = "г. Нарын",
                    SocialNumber = "12345543211234"
                },
                new Client
                {
                    ID = 4,
                    Name = "Тестовый клиент4",
                    BirthDate = DateTime.Parse("1989-02-25"),
                    PhoneNumber = "012",
                    Address = "с. Комсомольское",
                    SocialNumber = "12345671234567"
                }
                );
        }
    }
}
