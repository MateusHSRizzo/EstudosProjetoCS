using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models
{
    [Table("Cidade")]
    public class CidadeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(100, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Cidade")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(2, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "UF")]
        public string Estado { get; set; }
    }
}
