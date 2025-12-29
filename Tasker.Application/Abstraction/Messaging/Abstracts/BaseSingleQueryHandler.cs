using Tasker.Application.Abstraction.Messaging.Interfaces;
using Tasker.Domain.Abstractions;
using Tasker.Domain.Entities;

namespace Tasker.Application.Abstraction.Messaging.Abstracts;

internal abstract class BaseSingleQueryHandler<TQuery, TResponse, TEntity> : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TEntity : Entity
{
    protected abstract string Sql { get; }

    public abstract Task<Result<TResponse>> Handle(TQuery request, CancellationToken cancellationToken);

    public abstract TResponse Map(TEntity entity);
}