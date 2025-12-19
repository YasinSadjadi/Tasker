namespace Tasker.Application.Interfaces.Commands;

public interface ICommand<TResult, TContract>
    where TContract : ICommandContract
    where TResult : ICommandResult
{
    TResult Handle(TContract contract);
}
