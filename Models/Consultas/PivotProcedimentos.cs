using System.ComponentModel.DataAnnotations;

namespace EstudoProjetoCS.Models.Consultas
{
    public class PivotProcedimentos
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        [Display(Name = "Concluido")]
        public double Estado1 { get; set; }
        [Display(Name = "Em Andamento")]
        public double Estado2 { get; set; }
    }
}
