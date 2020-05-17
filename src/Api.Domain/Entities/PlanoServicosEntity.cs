using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PlanoServicosEntity: BaseEntity
    {
        public int PlanoId { get; set; }
        public PlanoEntity Plano { get; set; }
        public int ServicoId { get; set; }
        public ServicosEntity Servico { get; set; }
    }
}
