using System.ComponentModel.DataAnnotations;

namespace TesteWebApi.Domain.Models.Dto
{
    public class ParkingDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int QtdSpacesCar { get; set; }

        [Required]
        public int QtdSpacesMotorcycle { get; set; }

        [Required]
        public int QtdSpacesBig { get; set; }

        public ParkingDto(string? name, int qtdSpacesCar, int qtdSpacesMotorcycle, int qtdSpacesBig)
        {
            Name = name;
            QtdSpacesCar = qtdSpacesCar;
            QtdSpacesMotorcycle = qtdSpacesMotorcycle;
            QtdSpacesBig = qtdSpacesBig;
        }
    }
}