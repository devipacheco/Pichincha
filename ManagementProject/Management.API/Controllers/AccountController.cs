using Management.Domain.Dtos.Account;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var lst = await _unitOfWork.Accounts.GetAccounts();

            return lst == null ? NotFound() : Ok(lst);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAccountById(int Id)
        {

            var account = await _unitOfWork.Accounts.GetAccountById(Id);
            return account.Id == 0 ? NotFound() : Ok(account);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AccountDto account)
        {
            try
            {
                var result = await _unitOfWork.Accounts.CreateAccount(account);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, AccountUpdatedDto account)
        {

            try
            {
                var result = await _unitOfWork.Accounts.UpdateAccount(Id, account);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _unitOfWork.Accounts.DeleteAccount(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
