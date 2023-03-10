using AutoMapper;
using Management.API;
using Management.API.Controllers;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
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
    public class AccountRepositoryTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public async void WhenGettingAllAccounts_ThenAllAccountsReturn()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var accountController = new AccountController(repositoryWrapperMock.Object);

            var result = await accountController.GetAccounts() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<List<AccountResponseDto>>(result.Value);
        }

        [Fact]
        public async void GivenValidRequest_WhenCreatingAccount_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var accountController = new AccountController(repositoryWrapperMock.Object);

            var account = new AccountDto()
            {
                Number= 585545,
                Type= "Corriente",
                Balance= 1000,
                Status= true,
                ClientId= 1
            };
            var result = await accountController.Create(account);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<ActionResult<ResultadoAccion>>(result);
        }

        [Fact]
        public async void GivenNonExistingAccount_WhenGettingClientId_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var accountController = new AccountController(repositoryWrapperMock.Object);

            var id = 5;
            var result = await accountController.GetAccountById(id) as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
