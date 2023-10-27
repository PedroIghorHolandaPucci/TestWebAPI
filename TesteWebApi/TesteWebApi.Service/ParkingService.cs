using AutoMapper;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private IRepositoryUoW @object;

        public ParkingService(IRepositoryUoW repositoryUoW, IMapper mapper, IConfiguration config)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _config = config;
        }

        public async Task<Parking> AddParking(ParkingDto parkingDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                //Deposit deposit = _mapper.Map<DepositDto, Deposit>(depositDTO);
                //deposit.CreatedAt = DateTime.UtcNow;
                //var result = await _repositoryUoW.DepositRepository.AddDeposit(deposit);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                //return result;
                return null;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}