using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Services
{
    public class MovementService : IMovementService
    {
        public IUnitOfWork _unitOfWork;

        public MovementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Movement entity)
        {
            //if (entity != null)
            //{
            //    await _unitOfWork.Movements.Add(entity);

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
            //    var movement = await _unitOfWork.Movements.GetById(Id);
            //    if (movement != null)
            //    {
            //        _unitOfWork.Movements.Delete(movement);
            //        var result = _unitOfWork.Save();

            //        if (result > 0)
            //            return true;
            //        else
            //            return false;
            //    }
            //}
            return false;
        }

        public async Task<IEnumerable<Movement>> GetAll()
        {
            return await _unitOfWork.Movements.GetAll();
        }

        public Task<IEnumerable<Movement>> GetAll(List<string> includes)
        {
            throw new NotImplementedException();
        }

        public Task<Movement> GetByClientAndDates(int Id, DateTime startDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public Task<Movement> GetByDates(DateTime startDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Movement> GetById(int Id)
        {
            if (Id > 0)
            {
                var movement = await _unitOfWork.Movements.GetById(Id);
                if (movement != null)
                {
                    return movement;
                }
            }
            return new Movement();
        }

        public Task<Movement> GetById(int Id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public Task<Movement> GetByIdClient(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Movement entity)
        {
            //if (entity != null)
            //{
            //    var _movement = await _unitOfWork.Movements.GetById(entity.Id);
            //    if (_movement != null)
            //    {
            //        //_client.Balance = entity.Balance;
            //        //_client.Type = entity.Type;
            //        //_client.Number = entity.Number;

            //        _unitOfWork.Movements.Update(_movement);

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
