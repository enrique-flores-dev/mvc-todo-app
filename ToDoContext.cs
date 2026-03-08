using Microsoft.EntityFrameworkCore;
using mvctodolist.Models;

namespace mvctodolist.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}