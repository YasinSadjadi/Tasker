using Microsoft.EntityFrameworkCore;
using Tasker.Domain.Abstractions.Interfaces;
using Tasker.Domain.Entities.Task.Events;

namespace Tasker.Domain.Entities.Task;

[Index(nameof(Title))]
public class TaskerTask : Entity, ISoftDeletable
{
    private TaskerTask(Title title, DueDate dueDate, Description description, Guid id) : base(id)
    {
        Title = title;
        DueDate = dueDate;
        Description = description;
    }

    public virtual Title Title { get; private set; }
    public virtual Description Description { get; private set; }

    public virtual DueDate DueDate { get; private set; }
    public TaskerTaskStatus Status { get; private set; } = TaskerTaskStatus.Pending;
    public TaskPriority Priority { get; private set; } = TaskPriority.Low;

    public DateTime CancelledDate { get => field.ToLocalTime(); private set; }
    public DateTime CompletedDate { get => field.ToLocalTime(); private set; }

    public bool IsDeleted { get; set; } = false;

    public virtual TaskerTask Create(Title title, DueDate dueDate, Description description)
    {
        var task = new TaskerTask(title, dueDate, description, Guid.NewGuid());

        RaiseDomainEvent(new CreatedTaskDomainEvent(task.Id));

        return task;
    }

    public void ChangePriority(TaskPriority priority)
    {
        Priority = priority;

        RaiseDomainEvent(new PriorityChangedDomainEvent(Id));
    }

    public void MarkAsInProgress()
    {
        Status = TaskerTaskStatus.InProgress;
    }

    public void Cancel()
    {
        CancelledDate = DateTime.UtcNow;
        Status = TaskerTaskStatus.Cancelled;

        RaiseDomainEvent(new TaskCancelledDomainEvent(Id));
    }

    public void Complete()
    {
        CompletedDate = DateTime.UtcNow;
        Status = TaskerTaskStatus.Completed;

        RaiseDomainEvent(new TaskCompleteDomainEvent(Id));
    }
}