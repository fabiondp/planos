using System;

namespace Api.Domain.DTO
{
    public class PessoaUpdateDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}