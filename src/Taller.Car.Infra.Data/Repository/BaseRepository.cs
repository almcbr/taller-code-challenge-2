using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Taller.Car.Domain.Interfaces;

namespace Taller.Car.Infra.Data.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly TallerDBContext _tallerDbContext;
    protected readonly DbSet<TEntity> dbSet;

    public BaseRepository(TallerDBContext tallerDbContext)
    {
        _tallerDbContext = tallerDbContext;
        dbSet = _tallerDbContext.Set<TEntity>();
    }
    public virtual async Task Add(TEntity obj)
    {
        await dbSet.AddAsync(obj);
        await SaveChanges();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, int numberOfRecords)
    {
        return await dbSet.AsNoTracking().Where(predicate).Take(numberOfRecords).ToListAsync();
    }

    public virtual async Task Update(TEntity obj)
    {
        dbSet.Update(obj);
        await SaveChanges();
    }

    public virtual async Task Delete(TEntity obj)
    {
        dbSet.Remove(obj);
        await SaveChanges();
    }

    public virtual async Task SaveChanges()
    {
        await _tallerDbContext.SaveChangesAsync();
    }
    public virtual async void Dispose()
    {
        await _tallerDbContext.DisposeAsync();
    }
}