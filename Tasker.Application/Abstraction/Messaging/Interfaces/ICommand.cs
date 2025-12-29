using MediatR;
using Tasker.Domain.Abstractions;

namespace Tasker.Application.Abstraction.Messaging.Interfaces;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}