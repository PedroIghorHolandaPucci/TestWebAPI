using AutoMapper;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Domain.Models;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public VehicleService(IRepositoryUoW repositoryUoW, IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Vehicle> vehicles = await _repositoryUoW.VehicleRepository.GetAllVehicles();
                _repositoryUoW.Commit();
                return vehicles;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }
    }
}