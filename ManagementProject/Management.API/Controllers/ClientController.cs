using AutoMapper;
using FluentValidation;
using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Infraestructure.Repositories;
using Management.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var lst = await _unitOfWork.Clients.GetClients();

            return lst == null ? NotFound() : Ok(lst);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClientById(int Id)
        {
            var client = await _unitOfWork.Clients.GetClientById(Id);
            return client == null ? NotFound() : Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDto client)
        {
            return BadRequest();
            //var result = await _validator.ValidateAsync(client);

            //if (!result.IsValid)
            //{
            //    return BadRequest(result);
            //}

            //var clientToInsert = _mapper.Map<ClientDto, Client>(client);

            //// Person
            //var _person = new Person()
            //{
            //    Name = client.Names,
            //    Address = client.Address,
            //    Phone = client.Phone,
            //};

            //var personCreated = await _personService.Create(_person);

            //if(personCreated) clientToInsert.PersonId = _person.Id;
            //else return BadRequest("Error al crear la persona.");

            //var isclientCreated = await _clientService.Create(ClientDto);

            //if (isclientCreated)
            //{
            //    return Ok("Se agrego el cliente correctamente");
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }

        [HttpPut("clientId")]
        public async Task<IActionResult> Update(int clientId, ClientUpdatedDto client)
        {
            //if (client != null)
            //{
            //    //var result = await _validator.ValidateAsync(client);

            //    //if (!result.IsValid)
            //    //{
            //    //    return BadRequest(result);
            //    //}
            //    var clientToUpdate = _mapper.Map<ClientUpdatedDto, Client>(client);
            //    clientToUpdate.Id = clientId;

            //    clientToUpdate.Person.Name = client.Name;
            //    clientToUpdate.Person.Address = client.Address;
            //    clientToUpdate.Person.Phone = client.Phone;

            //    var isClientUpdated = await _clientService.Update(clientToUpdate);
            //    if (isClientUpdated)
            //    {
            //        return Ok(isClientUpdated);
            //    }
            //    return BadRequest();
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return BadRequest();
        }


        [HttpDelete("clientId")]
        public async Task<IActionResult> Delete(int clientId)
        {
            //var isClientDeleted = await _clientService.Delete(clientId);

            //if (isClientDeleted)
            //{
            //    return Ok(isClientDeleted);
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return BadRequest();

        }
    }
}
