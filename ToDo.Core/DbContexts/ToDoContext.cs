using Microsoft.EntityFrameworkCore;
using System;
using ToDoCore.Entities;

namespace ToDoCore.DbContexts
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: fluent API model creation

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    UserName = "tesztelek",
                    FirstName = "Elek",
                    LastName = "Teszt",
                    Email = "teszt@elek.io",
                    Password = "titok"
                },
                new User
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    UserName = "johndoe",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@doe.io",
                    Password = "secret"
                });

            modelBuilder.Entity<ToDo>()
                .HasData(
                new ToDo
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "Első todo",
                    Note = "Ez az első todo! Ez itt a todo leírása, ide jöhet minden magyarázat és jegyzet",
                    Priority = Enums.Priority.Normal,
                    Status = Enums.Status.New,
                    CreatedAt = DateTime.Now,
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                },
                new ToDo
                {
                    Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    Name = "Második todo",
                    Note = "Ez már a második todo! Itt már más a leírás!",
                    Priority = Enums.Priority.Important,
                    Status = Enums.Status.Planned,
                    CreatedAt = DateTime.Now,
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                },
                new ToDo
                {
                    Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                    Name = "Harmadik todo",
                    Note = "Ez itt a hramadik todo. Ide már nem tudok kitalálni más szöveget",
                    Priority = Enums.Priority.Normal,
                    Status = Enums.Status.New,
                    CreatedAt = DateTime.Now,
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                },
                new ToDo
                {
                    Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    Name = "John's todo",
                    Note = "Ez itt már John todo-ja!",
                    Priority = Enums.Priority.Important,
                    Status = Enums.Status.Planned,
                    CreatedAt = DateTime.Now,
                    UserId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                });
        }
    }
}
