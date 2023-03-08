using Management.Domain.Others.Result;
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
        Task<IEnumerable<T>> GetAll();
        Task<ResultadoAccion> Add(T entity);
        ResultadoAccion Delete(T entity);
        ResultadoAccion Update(T entity);
    }
}
