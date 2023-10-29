﻿using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;

namespace TesteWebApi.Service.Interfaces
{
    public interface IParkingService
    {
        public Task<Parking> AddParking(ParkingDto parkingDto);
        public Task<List<Parking>> GetAllParkings();
        public Task<Parking?> UpdateSpacesParking(VehicleDto vehicleDto, int id);
        public Task<Parking?> RoleVehicleCar(VehicleDto vehicleDto, Parking parking, int id);
        public Task<Parking?> RoleVehicleVan(VehicleDto vehicleDto, Parking parking, int id);
        public Task<Parking?> RoleVehicleMotorcycle(VehicleDto vehicleDto, Parking parking, int id);
    }
}