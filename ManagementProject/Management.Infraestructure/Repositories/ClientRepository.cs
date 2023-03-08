using AutoMapper;
using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management.Infraestructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IMapper _mapper;

        public ClientRepository(DbContextClass context, IMapper mapper) : base(context)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<ClientResponseDto>> GetClientById(int clientId)
        {
            var result = await _dbContext.Clients.Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == clientId);

            //var clientMapper = result != null ? _mapper.Map<Client, ClientResponseDto>(result);

            return result != null ? _mapper.Map<Client, ClientResponseDto>(result) : throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        public async Task<ActionResult<List<ClientResponseDto>>> GetClients()
        {
            var clients = await _dbContext.Clients.Include(x => x.Person).ToListAsync();
            var clientsMapper = _mapper.Map<List<Client>, List<ClientResponseDto>>(clients);

            return clientsMapper;
        }
    }
}
