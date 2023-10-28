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
            int totalSpaceCar = 20;
            int totalSpaceVan = 30;
            int totalSpaceMotorcycle = 40;
            var qtdSpacesCar = 20;
            var qtdSpacesMotorcycle = 40;
            var qtdSpacesBig = 20;
            var createdAt = DateTime.Now;

            // Act
            var parkingDto = new ParkingDto(name, totalSpaceCar, totalSpaceVan, totalSpaceMotorcycle, qtdSpacesCar, qtdSpacesMotorcycle, qtdSpacesBig, createdAt);

            // Assert
            Assert.NotNull(parkingDto);
            Assert.Equal(totalSpaceCar, parkingDto.TotalSpaceCar);
            Assert.Equal(totalSpaceVan, parkingDto.TotalSpaceVan);
            Assert.Equal(totalSpaceMotorcycle, parkingDto.TotalSpaceMotorcycle);
            Assert.Equal(name, parkingDto.Name);
            Assert.Equal(qtdSpacesCar, parkingDto.QtdSpacesCar);
            Assert.Equal(qtdSpacesMotorcycle, parkingDto.QtdSpacesMotorcycle);
            Assert.Equal(qtdSpacesBig, parkingDto.QtdSpacesBig);
            Assert.Equal(createdAt, parkingDto.CreatedAt);
        }
    }
}