using Tasker.Application.Interfaces.Queries;
using Tasker.Application.Queries.User.Contracts;
using Tasker.Application.Queries.User.Results;

namespace Tasker.Application.Queries.User;

public class GetAllUsersQuery : IQuery<GetAllUsersResult, GetAllUsersContract>
{
    public GetAllUsersResult Handle(GetAllUsersContract contract)
    {
        return new GetAllUsersResult();
    }
}
