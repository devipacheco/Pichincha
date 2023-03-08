using Management.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infraestructure.Repositories
{
    public abstract class Repository<T>: IRepository<T> where T : class
    {
        protected readonly DbContextClass _dbContext;

        protected Repository(DbContextClass context)
        {
            _dbContext = context;

        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        //public async Task<IEnumerable<T>> GetAll(List<string> includes)
        //{
        //    var query = _dbContext.Set<T>().AsQueryable();

        //    foreach (var include in includes)
        //        query = query.Include(include);

        //    return await query.ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        //public async Task<T> GetById(int id, List<string> includes)
        //{
        //    //var query = _dbContext.Set<T>().AsQueryable();

        //    //foreach (var include in includes)
        //    //    query = query.Include(include);

        //    //return await _dbContext.Set<T>().FindAsync(id);

        //    var model = await _dbContext.Set<T>().FindAsync(id);
        //    foreach (var path in includes)
        //    {
        //        _dbContext.Entry(model).Reference(path).Load();
        //    }
        //    return model;
        //}

        public async void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
