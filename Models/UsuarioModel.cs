using EstudoProjetoCS.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoProjetoCS.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(100, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(100, ErrorMessage = "Excedido o limite de caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(100, ErrorMessage = "Excedido o limite de caracteres")]
        public string Password { get; set; }

        public bool SenhaValida(string senha)
        {
            return Password == senha;
        }
    }
}
