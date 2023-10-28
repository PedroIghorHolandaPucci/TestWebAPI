using AutoMapper;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Service
{
    public class ParkingService : IParkingService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;
        public Parking? result { get; private set; }

        public ParkingService(IRepositoryUoW repositoryUoW, IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
        }        

        public async Task<Parking> AddParking(ParkingDto parkingDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                Parking parking = _mapper.Map<ParkingDto, Parking>(parkingDto);
                parking.CreatedAt = DateTime.Now;
                var result = await _repositoryUoW.ParkingRepository.AddParking(parking);

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

        public async Task<List<Parking>> GetAllParkings()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Parking> parkings = await _repositoryUoW.ParkingRepository.GetAllParkings();
                _repositoryUoW.Commit();
                return parkings;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public async Task<Parking?> UpdateSpacesCarParking(int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                Parking? parking = await _repositoryUoW.ParkingRepository.GetParkingById(id);

                if (parking?.TotalSpaceCar != parking?.QtdSpacesCar)
                {
                    parking.QtdSpacesCar++;
                    result = _repositoryUoW.ParkingRepository.UpdateParking(parking);
                    
                    //Vehicle vehicle = _mapper.Map<VehicleDto, Vehicle>(vehicleDto);
                    //vehicle.Parking.Id = id;
                    //await _repositoryUoW.VehicleRepository.AddVechile(vehicle);

                    await _repositoryUoW.SaveAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    if (parking?.TotalSpaceVan != parking?.QtdSpacesBig)
                    {
                        parking.QtdSpacesBig++;
                        result = _repositoryUoW.ParkingRepository.UpdateParking(parking);

                        await _repositoryUoW.SaveAsync();
                        await transaction.CommitAsync();
                    }
                    else
                    {
                        throw new InvalidOperationException("Não existem vagas suficientes para carro nas vagas de carro e nas vagas de van!");
                    }
                }
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