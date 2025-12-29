using Tasker.Application.Abstraction.Messaging.Interfaces;
using Tasker.Domain.Abstractions;

namespace Tasker.Application.Task.Queries.TaskByPerson;

public sealed record GetTasksByUserIdQuery(Guid UserId) : IQuery<GetTasksByUserIdQueryResult>;

public sealed record GetTasksByUserIdQueryResult
{
}