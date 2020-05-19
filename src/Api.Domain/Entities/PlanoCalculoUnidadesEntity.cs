using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PlanoCalculoUnidadesEntity: BaseEntity
    {
        public int Id { get; set; }
        public int PlanoId { get; set; }
        public PlanoEntity Plano { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public float ValorPorUnidade { get; set; }
    }
}
