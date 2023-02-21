namespace Taller.Car.Domain.Interfaces;


public interface ICarService: IDisposable
{
    Task<IEnumerable<Entities.Car>> GetAll();
    Task<Entities.Car> GetById(Guid id);
    Task Add(Entities.Car car);
    Task Update(Entities.Car car);
    Task Delete(Entities.Car car);
}