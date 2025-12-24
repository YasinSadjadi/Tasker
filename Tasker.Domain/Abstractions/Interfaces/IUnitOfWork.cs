namespace Tasker.Domain.Abstractions.Interfaces;

public interface IUnitOfWork
{
    void SaveChangesAsync(CancellationToken cancellationToken = default);
}