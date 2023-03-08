using AutoMapper;
using Management.API.Dtos;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Movement;
using Management.Domain.Dtos.Response;
using Management.Domain.Models;
using System.Net;

namespace Management.API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();

            CreateMap<ClientDto, Client>();
            CreateMap<ClientUpdatedDto, Client>();
            CreateMap<Client, ClientResponseDto>();
            CreateMap<Client, ClientShortDto>();

            CreateMap<AccountDto, Account>();
            CreateMap<AccountUpdatedDto, Account>();
            CreateMap<Account, AccountResponseDto>();

            CreateMap<MovementDto, Movement>();
            CreateMap<MovementUpdatedDto, Movement>();
            CreateMap<Movement, MovementResponseDto>();

        }
    }
}
