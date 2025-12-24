using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tasker.DataAccess.Database;
using Tasker.DataAccess.Interfaces;
using Tasker.Domain.Entities;

namespace Tasker.DataAccess.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : Entity
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }


    public IQueryable<T> GetAll() => context.Set<T>();

    public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken) =>
        await context.Set<T>().ToListAsync(cancellationToken);

    public T? GetById(Guid id) =>
        context.Set<T>().Where(x => x.Id == id).FirstOrDefault();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

    public void Update(T entity)
    {
        if (!context.Set<T>().Where(x => x.Id == entity.Id).Any())
            throw new InvalidOperationException("Entity not found in the database.");

        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        if (!await context.Set<T>().Where(x => x.Id == entity.Id).AnyAsync())
            throw new InvalidOperationException("Entity not found in the database.");

        context.Set<T>().Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public void Delete(T entity)
    {
        context.Remove(entity);
        context.SaveChanges();
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        context.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}
