using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Movement;
using Management.Domain.Dtos.Response;
using Management.Domain.Interfaces;
using Moq;

namespace UnitTest.Mocks
{
    internal class MockIMovementRepository
    {
        public static Mock<IMovementRepository> GetMock()
        {
            var mock = new Mock<IMovementRepository>();

            var movements = new List<MovementResponseDto>()
            {
                new MovementResponseDto()
                {
                    Id= 1,
                    Date= DateTime.Now,
                    Client= "Jose Lema",
                    Number= 478758,
                    Type= "Ahorro",
                    InitialBalance= 2000,
                    State= true,
                    Movement= "Debito",
                    FinalBalance= 1425,
                    Description= "Debito de 575"
                },
                new MovementResponseDto()
                {
                    Id= 2,
                    Date= DateTime.Now,
                    Client= "Marianela Montalvo",
                    Number= 225487,
                    Type= "Corriente",
                    InitialBalance= 100,
                    State= true,
                    Movement= "Credito",
                    FinalBalance= 700,
                    Description= "Credito de 600"
                },
            };

            mock.Setup(m => m.GetMovements()).ReturnsAsync(() => movements);

            mock.Setup(m => m.GetMovementById(It.IsAny<int>()))
                           .ReturnsAsync((int id) => movements.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.CreateMovement(It.IsAny<MovementDto>()))
              .Callback(() => { return; });


            return mock;
        }
    }
}
