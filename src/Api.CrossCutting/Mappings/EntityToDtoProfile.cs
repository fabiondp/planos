using Api.Domain.DTO;
using Api.Domain.Entities;
using AutoMapper;
using Domain.DTO.Plano;
using Domain.Entities;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<PessoaDTO, ChaveAPIEntity>()
                .ReverseMap();

            CreateMap<PessoaCreateDTO, ChaveAPIEntity>()
                .ReverseMap();

            CreateMap<PessoaUpdateDTO, ChaveAPIEntity>()
                .ReverseMap();


            CreateMap<PlanoCreateEditDTO, PlanoEntity>()
               .ReverseMap();


        }
    }
}