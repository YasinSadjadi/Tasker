using Tasker.Domain.Abstractions.Interfaces;

namespace Tasker.Domain.Entities.User.Events;

public record UserActivatedDomainEvent(Guid Id) : IDomainEvent;