using Microsoft.AspNetCore.Mvc;
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
                    mensagem = "Houve um erro ao cadastrar o estacionamento! "+ ex + ""
                });
            }
        }

        /// <summary>
        /// Endpoint responsible for listing parkings
        /// </summary>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ParkingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllParkings()
        {
            try
            {
                var parkings = await _serviceUoW.ParkingService.GetAllParkings();
                return Ok(parkings);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao carregar os estacionamentos "+ ex + ""
                });
            }
        }
    }
}