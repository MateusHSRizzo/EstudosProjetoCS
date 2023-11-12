using EstudoProjetoCS.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
