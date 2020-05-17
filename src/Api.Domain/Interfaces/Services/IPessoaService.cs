using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<PessoaDTO> GetTask(Guid id);
        Task<IEnumerable<PessoaDTO>> GetAll();
        Task<PessoaCreateDTO> Post(PessoaDTO pessoa);
        Task<PessoaUpdateDTO> Put(PessoaDTO pessoa);
        Task<bool> Delete(Guid id);
    }
}