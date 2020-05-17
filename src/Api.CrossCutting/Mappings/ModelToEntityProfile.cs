using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ChaveAPIEntity, PessoaModel>()
                .ReverseMap();

            CreateMap<PlanoEntity, PlanoModel>()
                .ReverseMap();
        }
    }
}