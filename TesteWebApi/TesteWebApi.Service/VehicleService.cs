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

        public async Task<Vehicle> AddCar(VehicleDto vehicleDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                Vehicle vehicle = _mapper.Map<VehicleDto, Vehicle>(vehicleDto);
                vehicle.DateEntry = DateTime.Now;
                var result = await _repositoryUoW.VehicleRepository.AddVechile(vehicle);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }
    }
}