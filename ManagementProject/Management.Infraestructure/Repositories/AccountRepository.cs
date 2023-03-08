using Management.Domain.Interfaces;
using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infraestructure.Repositories
{
    internal class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContextClass context) : base(context)
        {
        }
    }
}
