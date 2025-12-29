using Dapper;
using Tasker.Application.Abstraction.Data;
using Tasker.Application.Abstraction.Messaging.Abstracts;
using Tasker.Application.Abstraction.Messaging.Interfaces;
using Tasker.Domain.Abstractions;
using Tasker.Domain.Entities.Task;

namespace Tasker.Application.Task.Queries.TaskByPerson;

internal sealed class GetTasksByUserIdSingleQueryHandler(ISqlConnectionFactory sqlConnectionFactory) 
    : BaseListQueryHandler<GetTasksByUserIdQuery, GetTasksByUserIdQueryResult, TaskerTask>(sqlConnectionFactory)
{
    protected override string Sql { get; } = """
                                             SELECT *
                                                
                                             FROM tasker_task as t
                                             """;

    public override Task<Result<GetTasksByUserIdQueryResult>> Handle(GetTasksByUserIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected override GetTasksByUserIdQueryResult Map(ICollection<TaskerTask> entity)
    {
        throw new NotImplementedException();
    }
}