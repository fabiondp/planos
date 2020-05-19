using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PlanoRepository: BaseRepository<PlanoEntity>, IPlanoRepository
    {

        private DbSet<PlanoEntity> _dataSet;
        private DbSet<PlanoCalculoUnidadesEntity> _dataSetCalculoUnidade;
        private DbSet<PlanoCalculoFuncionariosEntity> _dataSetCalculoFuncionario;

        public PlanoRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<PlanoEntity>();
            _dataSetCalculoUnidade = context.Set<PlanoCalculoUnidadesEntity>();
            _dataSetCalculoFuncionario = context.Set<PlanoCalculoFuncionariosEntity>();
        }

        public async Task<float> CalculaPrecoPlano(int idPlano, int qtdUnidades, int qtdFuncionarios)
        {
            float valorCalculo = 0;

            // calculo de unidades
            var consultaCalcUnidades = _dataSetCalculoUnidade.Where(x => x.PlanoId == idPlano && x.QuantidadeMinima < qtdUnidades)
                                                 .OrderByDescending(x=> x.ValorPorUnidade).ToList();


            if (consultaCalcUnidades != null && consultaCalcUnidades.Any())
            {
                foreach (PlanoCalculoUnidadesEntity item in consultaCalcUnidades)
                {
                    var qtdUnidadesCalculo = (item.QuantidadeMaxima > 0) ? item.QuantidadeMaxima - item.QuantidadeMinima : qtdUnidades; // pego o intervalo de unidades definida
                    var qtdPossiveis = qtdUnidades - qtdUnidadesCalculo; //subtraio das quantidades informadas pelo user
                    valorCalculo += (qtdPossiveis > 0) ? qtdUnidadesCalculo * item.ValorPorUnidade : qtdUnidades * item.ValorPorUnidade;

                    qtdUnidades = qtdUnidades - qtdUnidadesCalculo;
                }
            }

            // calculo de unidades
            var consultaFuncionarios = _dataSetCalculoFuncionario.Where(x => x.PlanoId == idPlano && x.QuantidadeMinima < qtdFuncionarios)
                                                 .OrderByDescending(x => x.ValorPorFuncionario).ToList();


            if (consultaFuncionarios != null && consultaFuncionarios.Any())
            {
                foreach (PlanoCalculoFuncionariosEntity item in consultaFuncionarios)
                {
                    var qtdUnidadesCalculo = (item.QuantidadeMaxima > 0) ? item.QuantidadeMaxima - item.QuantidadeMinima : qtdFuncionarios; // pego o intervalo de unidades definida
                    var qtdPossiveis = qtdFuncionarios - qtdUnidadesCalculo; //subtraio das quantidades informadas pelo user
                    valorCalculo += (qtdPossiveis > 0) ? qtdUnidadesCalculo * item.ValorPorFuncionario : qtdFuncionarios * item.ValorPorFuncionario;

                    qtdFuncionarios = qtdFuncionarios - qtdUnidadesCalculo;
                }
            }

            return valorCalculo;
        }


    }
}
