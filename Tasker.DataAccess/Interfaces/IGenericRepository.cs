using Tasker.Domain.Entities;

namespace Tasker.DataAccess.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    void Add(T entity);
    Task AddAsync(T entity, CancellationToken cancellationToken);

    IQueryable<T> GetAll();
    Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken);

    T? GetById(Guid id);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    void Update(T entity);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    void Delete(T entity);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}
