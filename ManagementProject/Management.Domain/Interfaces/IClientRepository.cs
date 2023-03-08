using Management.API.Dtos.Response;
using Management.Domain.Dtos.Client;
using Management.Domain.Models;
using Management.Domain.Others.Result;
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
        Task<ClientResponseDto> GetClientById(int clientId);
        Task<ActionResult<ResultadoAccion>> CreateClient(ClientDto client);
        Task<ActionResult<ResultadoAccion>> UpdateCliente(int Id, ClientUpdatedDto client);
        Task<ActionResult<ResultadoAccion>> DeleteCliente(int Id);


    }
}
