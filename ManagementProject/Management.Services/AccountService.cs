using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Services.Interfaces;


namespace Management.Services
{
    public class AccountService : IAccountService
    {
        public IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Account entity)
        {
            //if (entity != null)
            //{
            //    await _unitOfWork.Accounts.Add(entity);

            //    var result = _unitOfWork.Save();

            //    if (result > 0)
            //        return true;
            //    else
            //        return false;
            //}
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            //if (Id > 0)
            //{
            //    var account = await _unitOfWork.Accounts.GetById(Id);
            //    if (account != null)
            //    {
            //        _unitOfWork.Accounts.Delete(account);
            //        var result = _unitOfWork.Save();

            //        if (result > 0)
            //            return true;
            //        else
            //            return false;
            //    }
            //}
            return false;
        }



        public Task<IEnumerable<Account>> GetAll(List<string> includes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetById(int Id)
        {
            if (Id > 0)
            {
                var account = await _unitOfWork.Accounts.GetById(Id);
                if (account != null)
                {
                    return account;
                }
            }
            return new Account();
        }

        public Task<Account> GetById(int Id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Account entity)
        {
            //if (entity != null)
            //{
            //    var _account = await _unitOfWork.Accounts.GetById(entity.Id);
            //    if (_account != null)
            //    {
            //        _account.Balance = entity.Balance;
            //        _account.Type = entity.Type;
            //        _account.Number = entity.Number;

            //        _unitOfWork.Accounts.Update(_account);

            //        var result = _unitOfWork.Save();

            //        if (result > 0)
            //            return true;
            //        else
            //            return false;
            //    }
            //}
            return false;
        }
    }
}
