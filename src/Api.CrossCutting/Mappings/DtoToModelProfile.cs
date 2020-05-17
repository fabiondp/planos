using Api.Domain.DTO;
using Api.Domain.Models;
using AutoMapper;
using Domain.DTO.Plano;
using Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile: Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<PessoaModel, PessoaDTO>()
                .ReverseMap();

            CreateMap<PlanoModel, PlanoCreateEditDTO>()
               .ReverseMap();
        }
    }
}