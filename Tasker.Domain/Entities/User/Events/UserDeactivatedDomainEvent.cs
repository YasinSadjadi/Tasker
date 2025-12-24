using Tasker.Domain.Abstractions.Interfaces;

namespace Tasker.Domain.Entities.User.Events;

public record UserDeactivatedDomainEvent(Guid Id) : IDomainEvent;