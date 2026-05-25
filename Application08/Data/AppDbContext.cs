using Microsoft.EntityFrameworkCore;

namespace VpLabAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Exposes your table rows as queryable collections
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}