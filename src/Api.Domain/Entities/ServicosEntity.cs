using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ServicosEntity: BaseEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<PlanoServicosEntity> Planos { get; set; }
    }
}
