using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Domain.Models;

namespace TesteWebApi.Service.Interfaces
{
    public interface IVehicleService
    {
        public Task<Vehicle> AddCar(VehicleDto vehicleDto);
    }
}