using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models.Consultas
{
    public class grpProcedimentosAno
    {
        public int Id { get; set; }
        public string Tecnico { get; set; }
        public double Valor { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ano")]
        public int Data { get; set; }
    }
}
