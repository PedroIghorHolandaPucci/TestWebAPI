﻿using Microsoft.AspNetCore.Mvc;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Controllers
{
    ///<Summary>
    /// ParkingController
    ///</Summary>
    [Route("api/v1/parking")]
    public class ParkingController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        ///<Summary>
        /// ParkingController constructor
        ///</Summary>
        public ParkingController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        /// <summary>
        /// Endpoint responsible for creating a parking
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateParking([FromBody] ParkingDto parkingDto)
        {
            try
            {
                Parking parking = await _serviceUoW.ParkingService.AddParking(parkingDto);
                return Ok(new
                {
                    mensagem = $"Cadastro de estacionamento realizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro ao realizar ao cadastrar um estacionamento " + ex + "!"
                });
            }
        }
    }
}