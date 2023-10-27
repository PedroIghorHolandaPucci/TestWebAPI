using TesteWebApi.Domain.Models.Dto;

namespace TesteWebApi.Teste
{
    public class ParkingDtoTest
    {
        [Fact(DisplayName = "Created the Parking object with success")]
        public void CreateParkingDto_WithValidValues()
        {
            // Arrange
            var name = "Teste 1";
            var qtdSpacesCar = 20;
            var qtdSpacesMotorcycle = 40;
            var qtdSpacesBig = 20;

            // Act
            var parkingDto = new ParkingDto(name, qtdSpacesCar, qtdSpacesMotorcycle, qtdSpacesBig);

            // Assert
            Assert.NotNull(parkingDto);
            Assert.Equal(name, parkingDto.Name);
            Assert.Equal(qtdSpacesCar, parkingDto.QtdSpacesCar);
            Assert.Equal(qtdSpacesMotorcycle, parkingDto.QtdSpacesMotorcycle);
            Assert.Equal(qtdSpacesBig, parkingDto.QtdSpacesBig);
        }
    }
}