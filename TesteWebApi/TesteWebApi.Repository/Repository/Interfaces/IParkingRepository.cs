using TesteWebApi.Domain.Models;

namespace TesteWebApi.Repository.Repository.Interfaces
{
    public interface IParkingRepository
    {
        public Task<Parking> AddParking(Parking parking);
        public Task<List<Parking>> GetAllParkings();
        public Parking UpdateParking(Parking parking);
        public Task<Parking?> GetParkingById(int id);
    }
}