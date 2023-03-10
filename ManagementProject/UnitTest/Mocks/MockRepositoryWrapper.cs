using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Infraestructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocks
{
    public class MockRepositoryWrapper
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();
            var clientRepoMock = MockIClientRepository.GetMock();
            var accountRepoMock = MockIAccountRepository.GetMock();
            var movementRepoMock = MockIMovementRepository.GetMock();



            // Setup the mock
            mock.Setup(m => m.Clients).Returns(() => clientRepoMock.Object);
            mock.Setup(m => m.Accounts).Returns(() => accountRepoMock.Object);
            mock.Setup(m => m.Movements).Returns(() => movementRepoMock.Object);


            return mock;
        }
    }
}
