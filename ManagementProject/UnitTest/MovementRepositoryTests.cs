using AutoMapper;
using Management.API;
using Management.API.Controllers;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Movement;
using Management.Domain.Dtos.Response;
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
    public class MovementRepositoryTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public async void WhenGettingAllMovements_ThenAllMovementsReturn()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var movementController = new MovementController(repositoryWrapperMock.Object);

            var result = await movementController.GetMovements() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<List<MovementResponseDto>>(result.Value);
        }

        [Fact]
        public async void GivenValidRequest_WhenCreatingClient_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var movementController = new MovementController(repositoryWrapperMock.Object);

            var client = new MovementDto()
            {
                AccountId = 4,
                MovementType = 2,
                Import = 540,
                Status = true
            };
            var result = await movementController.Create(client);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<ActionResult<ResultadoAccion>>(result);
        }

        [Fact]
        public async void GivenNonExistingMovement_WhenGettingClientId_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var movementController = new MovementController(repositoryWrapperMock.Object);

            var id = 5;
            var result = await movementController.GetMovementById(id) as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
