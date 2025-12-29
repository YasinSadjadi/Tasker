using Tasker.Domain.Abstractions.Interfaces;
using Tasker.Domain.Entities.Task.Events;
using Tasker.Domain.Shared;

namespace Tasker.Domain.Entities.Task;

public class TaskerTask : Entity, ISoftDeletable
{
    private TaskerTask(Title title, DueDate dueDate, Description description, Guid id, StateChangeLog cancelledDate,
        StateChangeLog completedDate, StateChangeLog deletedDate) : base(id)
    {
        Title = title;
        DueDate = dueDate;
        Description = description;
        CancelledDate = cancelledDate;
        CompletedDate = completedDate;
        DeletedDate = deletedDate;
    }

    public virtual Title Title { get; private set; }
    public virtual Description Description { get; private set; }

    public virtual DueDate DueDate { get; private set; }
    public TaskerTaskStatus Status { get; private set; } = TaskerTaskStatus.Pending;
    public TaskPriority Priority { get; private set; } = TaskPriority.Low;

    public StateChangeLog CancelledDate { get; private set; }
    public StateChangeLog CompletedDate { get; private set; }
    public StateChangeLog DeletedDate { get; private set; }

    public bool IsDeleted { get; private set; }

    public virtual TaskerTask Create(Title title, DueDate dueDate, Description description)
    {
        var task = new TaskerTask(title, dueDate, description, Guid.NewGuid(),
            StateChangeLog.Empty(), StateChangeLog.Empty(),
            StateChangeLog.Empty());

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
        CancelledDate = StateChangeLog.Create();
        Status = TaskerTaskStatus.Cancelled;

        RaiseDomainEvent(new TaskCancelledDomainEvent(Id));
    }

    public void Complete()
    {
        CompletedDate = StateChangeLog.Create();
        Status = TaskerTaskStatus.Completed;

        RaiseDomainEvent(new TaskCompleteDomainEvent(Id));
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedDate = StateChangeLog.Create();

        RaiseDomainEvent(new TaskDeletedDomainEvent(Id));
    }
}