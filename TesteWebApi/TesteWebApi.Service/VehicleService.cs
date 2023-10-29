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
    }
}