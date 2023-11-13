using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models
{
    [Table("Procedimento")]
    public class ProcedimentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [Display(Name = "Codigo do Procedimento")]
        public long Codigo_Procedimento { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(1000, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [StringLength(5, ErrorMessage = "Excedido o limite de caracteres")]
        [Display(Name = "Prioridade")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório*")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Valor")]
        public float Valor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da solicitação")]
        public DateTime Data_Solicitacao { get; set; }

        [Display(Name = "Atendente")]
        public int IdAtendente { get; set; }
        [ForeignKey("IdAtendente")]
        public AtendenteModel Atendente { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }
    }
}
