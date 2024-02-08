using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Persistence;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext()
    {
    }

    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
        : base(options)
    {
    }

    
    public DbSet<ToDoTask> ToDoTasks { get; set; }
}