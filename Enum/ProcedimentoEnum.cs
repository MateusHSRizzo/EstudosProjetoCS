using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Enum
{
    public enum ProcedimentoEnum
    {
        [Display(Name = "Em Andamaneto")]
        EmAndamento = 0,
        [Display(Name = "Concluído")]
        Concluido = 1,
        [Display(Name = "Cancelado pelo Cliente")]
        Cancelado = 2
    }
}
