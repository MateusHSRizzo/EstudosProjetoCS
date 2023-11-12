using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EstudoProjetoCS.Models
{
    [Table("Cliente")]
    public class ClienteModel
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
        [StringLength(13, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Contato")]
        public string Contato { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de Email invalido")]
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(13, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Display(Name = "Genero")]
        [StringLength(10, ErrorMessage = "Formato de Email invalido")]
        public string Genero { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public DateTime Nascimento { get; set; }


        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(200, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Rua/Bairro")]
        public string Endereco { get; set; }

        [Display(Name = "Cidade")]
        public int IdCidade { get; set; }
        [ForeignKey("IdCidade")]
        public CidadeModel Cidade { get; set; }
    }
        
        
}
