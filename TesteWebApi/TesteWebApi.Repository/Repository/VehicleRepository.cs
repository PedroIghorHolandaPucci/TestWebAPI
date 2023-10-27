using TesteWebApi.Repository.Repository.Interfaces;

namespace TesteWebApi.Repository.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataBaseContext _context;

        public VehicleRepository(DataBaseContext context)
        {
            _context = context;
        }
    }
}