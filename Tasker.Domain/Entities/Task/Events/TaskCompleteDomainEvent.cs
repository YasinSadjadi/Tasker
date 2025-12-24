using Tasker.Domain.Abstractions.Interfaces;

namespace Tasker.Domain.Entities.Task.Events;

public record TaskCompleteDomainEvent(Guid Id) : IDomainEvent;