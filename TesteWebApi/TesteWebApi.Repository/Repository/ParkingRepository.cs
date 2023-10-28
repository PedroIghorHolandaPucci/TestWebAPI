using Microsoft.EntityFrameworkCore;
using TesteWebApi.Domain.Models;
using TesteWebApi.Repository.Repository.Interfaces;

namespace TesteWebApi.Repository.Repository
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly DataBaseContext _context;

        public ParkingRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Parking> AddParking(Parking parking)
        {
            var result = await _context.Parking.AddAsync(parking);
            return result.Entity;
        }

        public async Task<List<Parking>> GetAllParkings()
        {
            return await _context.Parking.ToListAsync();
        }

        public Parking UpdateParking(Parking parking)
        {
            var response = _context.Parking.Update(parking);
            return response.Entity;
        }

        public async Task<Parking?> GetParkingById(int id)
        {
            return await _context.Parking.Where(e => e.Id == id)
                .FirstOrDefaultAsync() ?? throw new Exception("Estacionamento não encontrado!");
        }
    }
}