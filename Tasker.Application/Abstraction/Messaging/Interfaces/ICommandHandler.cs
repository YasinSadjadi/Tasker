using MediatR;
using Tasker.Domain.Abstractions;

namespace Tasker.Application.Abstraction.Messaging.Interfaces;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}