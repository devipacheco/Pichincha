using AutoMapper;
using Management.API;
using Management.API.Controllers;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Client;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mocks;

namespace UnitTest
{
    public class ClientRepositoryTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public async void WhenGettingAllClients_ThenAllClientsReturn()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var clientController = new ClientController(repositoryWrapperMock.Object);

            var result = await clientController.GetClients() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<ActionResult<List<ClientResponseDto>>>(result.Value);
        }

        [Fact]
        public async void GivenValidRequest_WhenCreatingClient_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var clientController = new ClientController(repositoryWrapperMock.Object);

            var client = new ClientDto()
            {
                Names= "Jose Lema",
                Address= "Otavalo sn y principal",
                Phone= "098254785",
                Password= "1234",
                Status= true
            };
            var result = await clientController.Create(client);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<ActionResult<ResultadoAccion>>(result);
        }

        [Fact]
        public async void GivenNonExistingClient_WhenGettingClientId_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var clientController = new ClientController(repositoryWrapperMock.Object);

            var id = 5;
            var result = await clientController.GetClientById(id) as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
