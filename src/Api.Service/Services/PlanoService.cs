using Api.Domain.DTO;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using AutoMapper;
using Domain.DTO.Plano;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PlanoService: IPlanoService
    {
        private IRepository<PlanoEntity> _repository;
        private readonly IMapper _mapper;

        public PlanoService(IRepository<PlanoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<PlanoCreateEditDTO> Post(PlanoCreateEditDTO pessoa)
        {
            var model = _mapper.Map<PlanoModel>(pessoa);
            var entity = _mapper.Map<PlanoEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PlanoCreateEditDTO>(result);
        }

        public Task<PessoaDTO> GetTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PessoaDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PessoaCreateDTO> Post(PessoaDTO pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaUpdateDTO> Put(PessoaDTO pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
