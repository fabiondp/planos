using System;

namespace Api.Domain.DTO
{
    public class PessoaCreateDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}