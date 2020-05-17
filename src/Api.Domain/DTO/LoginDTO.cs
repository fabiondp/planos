using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]

        [StringLength(12, ErrorMessage = "Senha deve ter no máximo {1} caracteres")]
        public string Senha { get; set; }
    }
}