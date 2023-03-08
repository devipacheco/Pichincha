using Management.Domain.Models;
using Management.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {

            var persons = await _accountService.GetAll();

            return persons == null ? NotFound() : Ok(persons);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAccountById(int Id)
        {
            var account = await _accountService.GetById(Id);

            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
            var isAccountCreated = await _accountService.Create(account);

            if (isAccountCreated)
            {
                return Ok(isAccountCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Account account)
        {
            if (account != null)
            {
                var isAccountUpdated = await _accountService.Update(account);
                if (isAccountUpdated)
                {
                    return Ok(isAccountUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete(int accountId)
        {
            var isAccountDeleted = await _accountService.Delete(accountId);

            if (isAccountDeleted)
            {
                return Ok(isAccountDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
