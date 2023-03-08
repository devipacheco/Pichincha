using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<bool> Create(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(List<string> includes);

        Task<T> GetById(int Id);

        Task<T> GetById(int Id, List<string> includes);

        Task<bool> Update(T entity);

        Task<bool> Delete(int Id);
    }
}
