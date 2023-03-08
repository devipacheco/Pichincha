using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;

        public UnitOfWork(DbContextClass dbContext, IPersonRepository personRepository, IClientRepository clientRepository, IMovementRepository movementRepository, IAccountRepository accountRepository)
        {
            _dbContext = dbContext;
            Persons = personRepository;
            Clients = clientRepository;
            Movements = movementRepository;
            Accounts = accountRepository;
        }

        public IPersonRepository Persons { get; }
        public IClientRepository Clients { get; }
        public IMovementRepository Movements { get; }
        public IAccountRepository Accounts { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
