using System.ComponentModel.DataAnnotations;

namespace TesteWebApi.Domain.Models
{
    public class Parking
    {
        public string? Name { get; set; }
        public int QtdSpacesCar { get; set; }
        public int QtdSpacesMotorcycle { get; set; }
        public int QtdSpacesBig{ get; set; }
    }
}