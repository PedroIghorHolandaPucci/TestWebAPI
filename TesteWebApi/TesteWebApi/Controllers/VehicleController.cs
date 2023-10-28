﻿using Microsoft.AspNetCore.Mvc;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Controllers
{
    ///<Summary>
    /// VehicleController
    ///</Summary>
    [Route("api/v1/vehicle")]
    public class VehicleController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        ///<Summary>
        /// VehicleController constructor
        ///</Summary>
        public VehicleController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        /// <summary>
        /// Endpoint responsible for creating a space for car
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateSpaceCar([FromBody] VehicleDto vehicleDto)
        {
            try
            {
                Vehicle vehicle = await _serviceUoW.VehicleService.AddCar(vehicleDto);
                return Ok(new
                {
                    mensagem = $"Cadastro de estacionamento realizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao cadastrar o estacionamento! " + ex + ""
                });
            }
        }
    }
}