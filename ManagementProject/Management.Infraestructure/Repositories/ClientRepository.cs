using AutoMapper;
using FluentValidation;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Client;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Management.Infraestructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IValidator<ClientDto> _validator;
        private readonly IValidator<ClientUpdatedDto> _validatorUpdate;
        private readonly IMapper _mapper;

        public ClientRepository(DbContextClass context, IMapper mapper, IValidator<ClientDto> validator, IValidator<ClientUpdatedDto> validatorUpdated) : base(context)
        {
            _dbContext = context;
            _mapper = mapper;
            _validator = validator;
            _validatorUpdate = validatorUpdated;
        }

        public async Task<ActionResult<ResultadoAccion>> CreateClient(ClientDto client)
        {
            try
            {
                var result = await _validator.ValidateAsync(client);

                if (!result.IsValid)
                {
                    return new ResultadoAccion(false, result.ToString());
                }

                var clientToInsert = _mapper.Map<ClientDto, Client>(client);

                // Person
                var _person = new Person()
                {
                    Name = client.Names,
                    Age = client.Age,
                    Genre = client.Genre,
                    Identification = client.Identification,
                    Address = client.Address,
                    Phone = client.Phone,
                };

                _dbContext.Add(_person);
                
                var personCreated = _dbContext.SaveChanges();

                if (personCreated >= 0) clientToInsert.PersonId = _person.Id;
                else return new ResultadoAccion(false, "Error al crear la persona.", 0);

                return await Add(clientToInsert);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ResultadoAccion>> DeleteCliente(int Id)
        {
            try
            {
                var _client = await _dbContext.Clients.Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == Id);

                _client.Status = false;

                return Update(_client);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientResponseDto> GetClientById(int clientId)
        {
            var result = await _dbContext.Clients.Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == clientId);

            return result != null ? _mapper.Map<Client, ClientResponseDto>(result) : new ClientResponseDto();

        }

        public async Task<ActionResult<List<ClientResponseDto>>> GetClients()
        {
            var clients = await _dbContext.Clients.Include(x => x.Person).Where(x => x.Status).ToListAsync();
            var clientsMapper = _mapper.Map<List<Client>, List<ClientResponseDto>>(clients);

            return clientsMapper;
        }

        public async Task<ActionResult<ResultadoAccion>> UpdateCliente(int id, ClientUpdatedDto clientUpdated)
        {
            try
            {
                var result = await _validatorUpdate.ValidateAsync(clientUpdated);

                if (!result.IsValid)
                {
                    return new ResultadoAccion(false, result.ToString());
                }

                //var clientToUpdate = _mapper.Map<ClientUpdatedDto, Client>(clientUpdated);
                var _client = _dbContext.Clients.Include(x => x.Person).FirstOrDefault(x => x.Id == id);

                var _person = _client.Person;

                _person.Age = clientUpdated.Age;
                _person.Address = clientUpdated.Address;
                _person.Identification = clientUpdated.Identification;
                _person.Name = clientUpdated.Name;
                _person.Phone = clientUpdated.Phone;
                _person.Genre = clientUpdated.Genre;

                _client.Status = clientUpdated.Status;
                _client.Password = clientUpdated.Password;

                //var resultado = await _dbContext.Persons.Update(_person);

                //var personUpdated = _dbContext.Persons.FirstOrDefault(x => x.Id);

                return Update(_client);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
