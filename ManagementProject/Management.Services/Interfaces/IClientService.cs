using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Services.Interfaces
{
    public interface IClientService : IGenericService<Client>
    {
        public Task<List<Client>> GetClients();
    }
}
