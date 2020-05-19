using Domain.DTO.Plano;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IPlanoService
    {
        Task<PlanoCreateEditDTO> Post(PlanoCreateEditDTO pessoa);
        Task<float> CalculaPrecoPlano(int idPlano, int qtdUnidades, int qtdFuncionarios);
    }
}
