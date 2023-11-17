using EstudoProjetoCS.Models;
using Microsoft.EntityFrameworkCore;
using EstudoProjetoCS.Models.Consultas;

namespace EstudoProjetoCS.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<CidadeModel> Cidades { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<AtendenteModel> Atendentes { get; set; }
        public DbSet<ProcedimentoModel> Procedimentos { get; set; }
        public DbSet<TecnicoModel> Tecnicos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<EstudoProjetoCS.Models.Consultas.grpProcedimentosMes> grpProcedimentos { get; set; }
        public DbSet<EstudoProjetoCS.Models.Consultas.grpPivotProcedimentos> grpPivotProcedimentos { get; set; }
        public DbSet<EstudoProjetoCS.Models.Consultas.PivotProcedimentos> PivotProcedimentos { get; set; }
        public DbSet<EstudoProjetoCS.Models.Consultas.grpProcedimentosAno> grpProcedimentosAno { get; set; }
    }
}
