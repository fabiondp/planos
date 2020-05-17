using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO
{
    public class PessoaDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [StringLength(6, ErrorMessage = "Senha deve ter no máximo {1} caracteres")]
        public string Senha { get; set; }

    }
}