using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Client;
using Management.Domain.Interfaces;
using Moq;

namespace UnitTest.Mocks
{
    internal class MockIClientRepository
    {
        public static Mock<IClientRepository> GetMock()
        {
            var mock = new Mock<IClientRepository>();

            var clients = new List<ClientResponseDto>()
            {
               new ClientResponseDto()
                {

                    Id = 1,
                    Status = true,
                    Person = new PersonDto()
                    {
                        Name = "Jose Lema",
                        Genre = "",
                        Age = 0,
                        Identification = "",
                        Address = "Otavalo sn y principal",
                        Phone = "098254785"
                    }
                },
                new ClientResponseDto()
                {

                    Id = 2,
                    Status = true,
                    Person = new PersonDto()
                    {
                        Name = "Marianela Montalvo",
                        Genre = "",
                        Age = 0,
                        Identification = "",
                        Address = "Amazonas y NNUU",
                        Phone = "097548965"
                    }
                },
                new ClientResponseDto()
                {

                    Id = 3,
                    Status = true,
                    Person = new PersonDto()
                    {
                        Name = "Juan Osorio",
                        Genre = "",
                        Age = 0,
                        Identification = "",
                        Address = "13 junio y Equinoccial",
                        Phone = "098874587"
                    }
                }
            };

            mock.Setup(m => m.GetClients()).ReturnsAsync(() => clients);

            mock.Setup(m => m.GetClientById(It.IsAny<int>()))
                           .ReturnsAsync((int id) => clients.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.CreateClient(It.IsAny<ClientDto>()))
              .Callback(() => { return; });


            return mock;
        }
    }
}
