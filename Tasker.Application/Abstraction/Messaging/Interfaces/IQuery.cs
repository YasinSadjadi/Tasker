using MediatR;
using Tasker.Domain.Abstractions;

namespace Tasker.Application.Abstraction.Messaging.Interfaces;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}