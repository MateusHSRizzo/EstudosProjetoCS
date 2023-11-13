using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "*Campo Obrigatório*")]
        public string Login { get; set; }
        [Required(ErrorMessage = "*Campo Obrigatório*")]
        public string Password { get; set; }
    }
}
