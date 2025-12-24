using Microsoft.EntityFrameworkCore;
using Tasker.Domain.Entities.Task;
using Tasker.Domain.Entities.User;

namespace Tasker.DataAccess.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskerTask> Tasks => Set<TaskerTask>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
