using Api.Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IPlanoRepository : IRepository<PlanoEntity>
    {
        Task<float> CalculaPrecoPlano(int idPlano, int qtdUnidades, int qtdFuncionarios);
    }
}
