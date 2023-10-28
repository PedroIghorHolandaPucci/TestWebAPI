using System.ComponentModel.DataAnnotations;

namespace TesteWebApi.Domain.Models
{
    public class Parking
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int QtdSpacesCar { get; set; }
        public int QtdSpacesMotorcycle { get; set; }
        public int QtdSpacesBig{ get; set; }
    }
}