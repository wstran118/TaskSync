using Microsoft.EntityFrameworkCore;

namespace TaskSync.Data
{
    public class TaskSyncContext : DbContext
    {
        public TaskSyncContext(DbContextOptions<TaskSyncContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}