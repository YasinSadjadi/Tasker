using Tasker.Domain.Abstractions.Interfaces;

namespace Tasker.Domain.Entities.Task.Events;

public record CreatedTaskDomainEvent(Guid Id) : IDomainEvent;