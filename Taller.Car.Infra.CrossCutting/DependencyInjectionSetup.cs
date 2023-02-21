using Microsoft.Extensions.DependencyInjection;
using Taller.Car.Domain.Interfaces;
using Taller.Car.Domain.Services;
using Taller.Car.Infra.Data;
using Taller.Car.Infra.Data.Repository;

namespace Taller.Car.Infra.CrossCutting;

public static class DependencyInjectionSetup
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddDbContext<TallerDBContext>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}