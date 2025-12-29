using Dapper;
using Tasker.Application.Abstraction.Data;
using Tasker.Application.Abstraction.Messaging.Interfaces;
using Tasker.Domain.Abstractions;
using Tasker.Domain.Entities;

namespace Tasker.Application.Abstraction.Messaging.Abstracts;

internal abstract class BaseListQueryHandler<TQuery, TResponse, TEntity>
    (ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TEntity : Entity
{
    protected abstract string Sql { get; }

    public virtual async Task<Result<TResponse>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        var query = await connection.QueryAsync<TEntity>(Sql, SetParameters());
        return Map(query.ToList());
    }

    protected virtual object? SetParameters()
    {
        return null;
    }

    protected abstract TResponse Map(ICollection<TEntity> entity);
}