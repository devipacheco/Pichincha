using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Infraestructure;
using Management.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Services
{
    public class ClientService : IClientService
    {
        public IUnitOfWork _unitOfWork;
        private readonly DbContextClass _dbContextClass;

        public ClientService(DbContextClass dbContext, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbContextClass = dbContext;
        }

        public Task<List<Client>> GetClients()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll(List<string> includes)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetById(int Id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> Create(Client entity)
        //{
        //    if (entity != null)
        //    {
        //        await _dbContextClass.Clients.AddAsync(entity);

        //        var result = _unitOfWork.Save();

        //        if (result > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    return false;
        //}

        //public async Task<bool> Delete(int Id)
        //{
        //    if (Id > 0)
        //    {
        //        var client = await _unitOfWork.Clients.GetById(Id);
        //        if (client != null)
        //        {
        //            _unitOfWork.Clients.Delete(client);
        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}

        //public async Task<IEnumerable<Client>> GetAll()
        //{
        //    return await _unitOfWork.Clients.GetAll();
        //}

        //public async Task<IEnumerable<Client>> GetAll(List<string> includes)
        //{
        //    return await _unitOfWork.Clients.GetAll(includes);
        //}

        //public async Task<Client> GetById(int Id)
        //{
        //    if (Id > 0)
        //    {
        //        var client = await _unitOfWork.Clients.GetById(Id);
        //        if (client != null)
        //        {
        //            return client;
        //        }
        //    }
        //    return new Client();
        //}

        //public async Task<Client> GetById(int Id, List<string> includes)
        //{
        //    if (Id > 0)
        //    {
        //        var client = await _unitOfWork.Clients.GetById(Id, includes);
        //        if (client != null)
        //        {
        //            return client;
        //        }
        //    }
        //    return new Client();
        //}

        //public async Task<List<Client>> GetClients()
        //{
        //    return await _dbContextClass.Clients.Include(x => x.Person).ToListAsync();
        //}

        //public async Task<bool> Update(Client entity)
        //{
        //    if (entity != null)
        //    {
        //        var _client = await _unitOfWork.Clients.GetById(entity.Id);
        //        if (_client != null)
        //        {
        //            //_client.Balance = entity.Balance;
        //            //_client.Type = entity.Type;
        //            //_client.Number = entity.Number;

        //            _unitOfWork.Clients.Update(_client);

        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}
    }
}
