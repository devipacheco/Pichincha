using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons{ get; }
        IClientRepository Clients { get; }
        IAccountRepository Accounts { get; }
        IMovementRepository Movements { get; }

        //int Save();
    }
}
