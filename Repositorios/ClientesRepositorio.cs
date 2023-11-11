using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;

namespace EstudoProjetoCS.Repositorios
{
    public class ClientesRepositorio : IClienteRepositorio
    {
        private readonly Contexto _Contexto;

        public ClientesRepositorio(Contexto contexto) 
        {
            _Contexto = contexto;
        }

        public ClienteModel Adicionar(ClienteModel Cliente)
        {
            // Gravar no banco de dados

            _Contexto.Clientes.Add(Cliente);
            _Contexto.SaveChanges();

            return Cliente;

        }
    }
}
