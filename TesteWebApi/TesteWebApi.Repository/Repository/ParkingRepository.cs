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
    }
}