namespace Tasker.Application.Interfaces.Queries;

public interface IQuery<TResult, TContract>
    where TResult : IQueryResult
    where TContract : IQueryContract
{
    TResult Handle(TContract contract);
}
