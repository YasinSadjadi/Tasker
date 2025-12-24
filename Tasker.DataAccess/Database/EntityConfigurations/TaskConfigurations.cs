using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.Entities.Task;

namespace Tasker.DataAccess.Database.EntityConfigurations;

public class TaskConfigurations : IEntityTypeConfiguration<TaskerTask>
{
    public void Configure(EntityTypeBuilder<TaskerTask> builder)
    {
        builder.HasOne(x => x.CreatedBy)
            .WithMany(x => x.CreatedTasks)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.AssignedUser)
            .WithMany(x => x.AssignedTasks)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
