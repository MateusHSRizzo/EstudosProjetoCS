using EstudoProjetoCS.Enum;

namespace EstudoProjetoCS.Models.Consultas
{
    public class grpPivotProcedimentos
    {
        public int Id { get; set;}
        public float Valor { get; set; }
        public int Data {  get; set;}
        public ProcedimentoEnum Estado { get; set;}
    }
}
