using Management.API.Dtos.Response;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Response;
using Management.Domain.Dtos.Account;

namespace Management.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<List<AccountResponseDto>> GetAccounts();
        Task<AccountResponseDto> GetAccountById(int Id);
        Task<ActionResult<ResultadoAccion>> CreateAccount(AccountDto account);
        Task<ActionResult<ResultadoAccion>> UpdateAccount(int Id, AccountUpdatedDto acoount);
        Task<ActionResult<ResultadoAccion>> DeleteAccount(int Id);
    }
}
