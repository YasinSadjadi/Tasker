using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasker.Domain.Interfaces;

namespace Tasker.Domain.Entities;

[Index(nameof(Title))]
public class TaskerTask : BaseEntity, ISoftDeletable
{
    public string Title { get; set => value.Trim(); } = default!;
    public string? Description { get; set => value?.Trim(); } = default!;
    public DateTime? DueDate { get; private set; }
    public TaskState State { get; set; }
    public TaskPriority Priority { get; set; }

    public bool IsCompleted { get; set; }
    public bool IsDeleted { get; set; }

    public User AssignedUser { get; set; } = default!;

    [ForeignKey(nameof(User))]
    public Guid AssignedUserId { get; set; } = default!;

    [Required]
    public User CreatedBy { get; set; } = default!;

    [ForeignKey("CreatedBy")]
    public Guid CreatedById { get; set; } = default!;

    public void SetDueDate(DateTime dueDate)
    {
        if (dueDate < DateTime.Now)
        {
            throw new ArgumentException("Due date cannot be in the past.");
        }

        DueDate = dueDate;
    }
}

public enum TaskState
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}

public enum TaskPriority
{
    Low,
    Medium,
    High,
    Urgent
}
