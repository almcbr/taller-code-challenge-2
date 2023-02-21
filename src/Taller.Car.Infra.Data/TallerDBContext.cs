using Microsoft.EntityFrameworkCore;

namespace Taller.Car.Infra.Data
{
    public class TallerDBContext:DbContext
    {
        public DbSet<Domain.Entities.Car> Cars { get; set; }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TallerDB");
        }

    }
}
