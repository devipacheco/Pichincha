using AutoMapper;
using Management.API.Dtos;
using Management.API.Dtos.Response;
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

        }
    }
}
