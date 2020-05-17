using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO.Plano
{
    public class PlanoCreateEditDTO
    {
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }

    }
}
