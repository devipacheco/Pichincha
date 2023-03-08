using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        //Task<T> GetById(int id, List<string> includes);
        //Task<List<T>> GetAll(List<string> includes);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
