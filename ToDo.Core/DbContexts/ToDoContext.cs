using Microsoft.EntityFrameworkCore;
using ToDoCore.Entities;

namespace ToDoCore.DbContexts
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: fluent API model creation
        }
    }
}
