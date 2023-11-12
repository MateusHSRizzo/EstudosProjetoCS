using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models
{
    [Table("Atendente")]
    public class AtendenteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(35, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [Display(Name = "NRF-(Numero de registro de funcionário)")]
        public int Registro { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }

    }
}
