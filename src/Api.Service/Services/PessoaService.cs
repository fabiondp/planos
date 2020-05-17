using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepository<ChaveAPIEntity> _repository;
        private readonly IMapper _mapper;

        public PessoaService(IRepository<ChaveAPIEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PessoaDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
             return _mapper.Map<IEnumerable<PessoaDTO>>(listEntity);
        }

        public async Task<PessoaDTO> GetTask(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PessoaDTO>(entity);
        }

        public async Task<PessoaCreateDTO> Post(PessoaDTO pessoa)
        {
            var model = _mapper.Map<PessoaModel>(pessoa);
            var entity = _mapper.Map<ChaveAPIEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PessoaCreateDTO>(result);
        }

        public async Task<PessoaUpdateDTO> Put(PessoaDTO pessoa)
        {
            var model = _mapper.Map<PessoaModel>(pessoa);
            var entity = _mapper.Map<ChaveAPIEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<PessoaUpdateDTO>(result);
        }
    }
}