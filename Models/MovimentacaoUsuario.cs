using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoProjetoCS.Models
{
    [Table("Movimentacao")]
    public class MovimentacaoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string usuario { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataCadastro { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataAtualizacao { get; set; }
    }
}
