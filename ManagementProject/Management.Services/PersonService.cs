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
    public class PersonService : IPersonService
    {
        public IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Person person)
        {
            //if (person != null)
            //{
            //    await _unitOfWork.Persons.Add(person);

            //    var result = _unitOfWork.Save();

            //    if (result > 0)
            //        return true;
            //    else
            //        return false;
            //}
            return false;
        }

        public async Task<bool> Delete(int personId)
        {
            //if (personId > 0)
            //{
            //    var productDetails = await _unitOfWork.Persons.GetById(personId);
            //    if (productDetails != null)
            //    {
            //        _unitOfWork.Persons.Delete(productDetails);
            //        var result = _unitOfWork.Save();

            //        if (result > 0)
            //            return true;
            //        else
            //            return false;
            //    }
            //}
            return false;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _unitOfWork.Persons.GetAll();
        }

        public Task<IEnumerable<Person>> GetAll(List<string> includes)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetById(int personId)
        {
            if (personId > 0)
            {
                var person = await _unitOfWork.Persons.GetById(personId);
                if (person != null)
                {
                    return person;
                }
            }
            return new Person();
        }

        public Task<Person> GetById(int Id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Person person)
        {
            //if (person != null)
            //{
            //    var _person = await _unitOfWork.Persons.GetById(person.Id);
            //    if (_person != null)
            //    {
            //        _person.Name = person.Name;
            //        _person.Address = person.Address;
            //        _person.Genre = person.Genre;

            //        _unitOfWork.Persons.Update(_person);

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
