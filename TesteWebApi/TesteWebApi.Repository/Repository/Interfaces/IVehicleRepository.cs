using TesteWebApi.Domain.Models;

namespace TesteWebApi.Repository.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> AddVechile(Vehicle vehicle);
    }
}