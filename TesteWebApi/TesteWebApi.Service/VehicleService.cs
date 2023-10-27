using AutoMapper;
using Microsoft.Extensions.Configuration;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private IRepositoryUoW @object;

        public VehicleService(IRepositoryUoW repositoryUoW, IMapper mapper, IConfiguration config)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _config = config;
        }
    }
}