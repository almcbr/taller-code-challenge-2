using Taller.Car.Domain.Interfaces;

namespace Taller.Car.Domain.Services;

public class CarService:ICarService
{
    private readonly IBaseRepository<Entities.Car> _repository;

    public CarService(IBaseRepository<Entities.Car> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Entities.Car>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Entities.Car> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task Add(Entities.Car car)
    {
        await _repository.Add(car);
    }

    public async Task Update(Entities.Car car)
    {
        await _repository.Update(car);
    }

    public async Task Delete(Entities.Car car)
    {
        await _repository.Delete(car);
    }
    public void Dispose()
    {
         _repository.Dispose();
    }
}