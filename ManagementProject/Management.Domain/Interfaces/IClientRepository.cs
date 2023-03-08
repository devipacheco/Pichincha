using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ActionResult<List<ClientResponseDto>>> GetClients();
        Task<ActionResult<ClientResponseDto>> GetClientById(int clientId);
    }
}
