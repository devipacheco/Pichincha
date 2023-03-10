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
            CreateMap<Account, AccountResponseDto>()
                .ForMember(dest => dest.Balance, act => act.MapFrom(act => act.InitialBalance)); ;

            CreateMap<MovementDto, Movement>()
                    .ForMember(dest => dest.ActionId, act => act.MapFrom(or => or.MovementType));
            CreateMap<MovementUpdatedDto, Movement>();
            CreateMap<Movement, MovementResponseDto>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(or => or.Id))
                    .ForMember(dest => dest.Date, act => act.MapFrom(or => or.CreatedDate))
                    .ForMember(dest => dest.Client, act => act.MapFrom(or => or.Account.Client.Person.Name))
                    .ForMember(dest => dest.Number, act => act.MapFrom(or => or.Account.Number))
                    .ForMember(dest => dest.Type, act => act.MapFrom(or => or.Account.Type))
                    .ForMember(dest => dest.InitialBalance, act => act.MapFrom(or => or.Account.InitialBalance))
                    .ForMember(dest => dest.State, act => act.MapFrom(or => or.Status))
                    .ForMember(dest => dest.Movement, act => act.MapFrom(or => or.Action.Name))
                    .ForMember(dest => dest.FinalBalance, act => act.MapFrom(or => or.Balance))
                    .ForMember(dest => dest.Description, act => act.MapFrom(or => or.Description));

        }
    }
}
