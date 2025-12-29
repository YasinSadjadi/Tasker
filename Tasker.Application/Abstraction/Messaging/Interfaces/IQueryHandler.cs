using MediatR;
using Tasker.Domain.Abstractions;

namespace Tasker.Application.Abstraction.Messaging.Interfaces;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>  
    where TQuery : IQuery<TResponse>
{

}