using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PlanoEntity: BaseEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<PlanoServicosEntity> Servicos { get; set; }
    }
}
