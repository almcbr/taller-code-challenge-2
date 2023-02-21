using System.Linq.Expressions;

namespace Taller.Car.Domain.Interfaces;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task Add(TEntity obj);
    Task<TEntity> GetById(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, int numberOfRecords);
    Task Update(TEntity obj);
    Task Delete(TEntity obj);
    Task SaveChanges();
}