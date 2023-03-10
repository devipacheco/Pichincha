using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Response;
using Management.Domain.Interfaces;
using Moq;

namespace UnitTest.Mocks
{
    internal class MockIAccountRepository
    {
        public static Mock<IAccountRepository> GetMock()
        {
            var mock = new Mock<IAccountRepository>();

            var accounts = new List<AccountResponseDto>()
            {
                new AccountResponseDto()
                {
                    Id= 1,
                    Number= 478758,
                    Type= "Ahorro",
                    Balance= 0,
                    Status= true,
                    CreatedDate= DateTime.Now,
                    CreatedBy= "UserCurrentLoggued",
                    Client= new ClientShortDto() {
                          Id= 1,
                          PersonId= 1,
                          Status= true
                    }
                },
                new AccountResponseDto()
                {
                    Id= 2,
                    Number= 225487,
                    Type= "Corriente",
                    Balance= 0,
                    Status= true,
                    CreatedDate= DateTime.Now,
                    CreatedBy= "UserCurrentLoggued",
                    Client= new ClientShortDto() {
                          Id= 2,
                          PersonId= 2,
                          Status= true
                    }
                },
                new AccountResponseDto()
                {
                    Id= 3,
                    Number= 495878,
                    Type= "Ahorro",
                    Balance= 0,
                    Status= true,
                    CreatedDate= DateTime.Now,
                    CreatedBy= "UserCurrentLoggued",
                    Client= new ClientShortDto() {
                          Id= 3,
                          PersonId= 3,
                          Status= true
                    }
                },
            };

            mock.Setup(m => m.GetAccounts()).ReturnsAsync(() => accounts);

            mock.Setup(m => m.GetAccountById(It.IsAny<int>()))
                           .ReturnsAsync((int id) => accounts.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.CreateAccount(It.IsAny<AccountDto>()))
              .Callback(() => { return; });


            return mock;
        }
    }
}
