using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;

namespace TesteWebApi.Service.Interfaces
{
    public interface IParkingService
    {
        public Task<Parking> AddParking(ParkingDto parkingDto);
    }
}