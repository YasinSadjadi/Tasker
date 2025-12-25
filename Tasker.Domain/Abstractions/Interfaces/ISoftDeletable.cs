using Tasker.Domain.Shared;

namespace Tasker.Domain.Abstractions.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; }
    public StateChangeLog DeletedDate { get; }

}
