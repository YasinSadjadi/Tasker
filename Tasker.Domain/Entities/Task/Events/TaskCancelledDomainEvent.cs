using Tasker.Domain.Abstractions.Interfaces;

namespace Tasker.Domain.Entities.Task.Events;

public record TaskCancelledDomainEvent(Guid Id) : IDomainEvent;