using EstudoProjetoCS.Enum;
using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models.Consultas
{
    public class grpProcedimentosMes
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Mês")]
        public int Data_Solicitacao { get; set; }
    }
}
