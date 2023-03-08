using AutoMapper;
using FluentValidation;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Response;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Management.Infraestructure.Repositories
{
    internal class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IValidator<AccountDto> _validator;
        private readonly IValidator<AccountUpdatedDto> _validatorUpdate;
        private readonly IMapper _mapper;


        public AccountRepository(DbContextClass context, IMapper mapper, IValidator<AccountDto> validator, IValidator<AccountUpdatedDto> validatorUpdated) : base(context)
        {
            _dbContext = context;
            _mapper = mapper;
            _validator = validator;
            _validatorUpdate = validatorUpdated;
        }

        public async Task<ActionResult<ResultadoAccion>> CreateAccount(AccountDto account)
        {
            try
            {
                var result = await _validator.ValidateAsync(account);

                if (!result.IsValid)
                {
                    return new ResultadoAccion(false, result.ToString());
                }

                var AccountToInsert = _mapper.Map<AccountDto, Account>(account);

                var _account = new Account()
                {
                    ClientId = account.ClientId,
                    Balance = account.Balance,
                    Number = account.Number,
                    Type = account.Type,
                    CreatedBy = "UserCurrentLoggued",
                    CreatedDate = DateTime.Now,
                    Status = true,
                };

                return await Add(_account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ActionResult<ResultadoAccion>> DeleteAccount(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountResponseDto> GetAccountById(int clientId)
        {
            var result = await _dbContext.Accounts.Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == clientId);

            return result != null ? _mapper.Map<Account, AccountResponseDto>(result) : new AccountResponseDto();
        }

        public async Task<List<AccountResponseDto>> GetAccounts()
        {
            var accounts = await _dbContext.Accounts.Include(x => x.Client).ToListAsync();
            var accountsMapper = _mapper.Map<List<Account>, List<AccountResponseDto>>(accounts);

            return accountsMapper;
        }

        public async Task<ActionResult<ResultadoAccion>> UpdateAccount(int Id, AccountUpdatedDto accountUpdated)
        {
            try
            {
                var result = await _validatorUpdate.ValidateAsync(accountUpdated);

                if (!result.IsValid)
                {
                    return new ResultadoAccion(false, result.ToString());
                }

                //var clientToUpdate = _mapper.Map<ClientUpdatedDto, Client>(clientUpdated);
                var _accountUpdated = _dbContext.Accounts.FirstOrDefault(x => x.Id == Id);

                _accountUpdated.UpdatedDate = DateTime.Now;
                _accountUpdated.Balance = accountUpdated.Balance;
                _accountUpdated.UpdatedBy = "UserLoggued";

                //var resultado = await _dbContext.Persons.Update(_person);

                //var personUpdated = _dbContext.Persons.FirstOrDefault(x => x.Id);

                return Update(_accountUpdated);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
