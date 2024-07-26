using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDo>().HasIndex(x=> x.Id);
        }

        public DbSet<ToDo> ToDoList { get; set; }
    }
}
