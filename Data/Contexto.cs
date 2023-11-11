using EstudoProjetoCS.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoProjetoCS.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<ClienteModel> Clientes { get; set; }
        

    }
}
