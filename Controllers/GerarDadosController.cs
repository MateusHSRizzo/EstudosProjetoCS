using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace EstudoProjetoCS.Controllers
{
    public class GerarDadosController : Controller
    {
        private readonly Contexto _contexto;

        public GerarDadosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Cidades()
        {
            _contexto.Database.ExecuteSqlRaw("delete from Cidade");
            _contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Cidade', RESEED, 0)");

            Encoding ecode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("ExcelData/CidadesData.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            
            reader.Read();

            do
            {
                while (reader.Read())
                {
                    CidadeModel cidade = new CidadeModel();
                    cidade.Estado = reader[0].ToString();
                    cidade.Descricao = reader[1].ToString();

                    _contexto.Cidades.Add(cidade);
                }
                _contexto.SaveChanges();
            } while (reader.NextResult());
            reader.Close();
            return View(_contexto.Cidades.OrderBy(c => c.Id).ToList()) ;
        }

        public IActionResult Clientes()
        {
            _contexto.Database.ExecuteSqlRaw("delete from Cliente");
            _contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Cliente', RESEED, 0)");
            Random randNum = new Random();

            string[] vDominios = { "gmail.com", "yahoo.com.br", "outlook.com" };

            Encoding ecode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("ExcelData/ClientesData.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            reader.Read();

            do
            {
                while (reader.Read())
                {
                    ClienteModel cliente = new ClienteModel();
                    cliente.Nome = reader[0].ToString();
                    cliente.Contato = reader[1].ToString();
                    cliente.Email = reader[0].ToString().ToLower() + "@" + vDominios[randNum.Next() % 3].ToLower();
                    cliente.Documento = reader[2].ToString();
                    cliente.Genero = reader[3].ToString();
                    cliente.Nascimento = DateTime.ParseExact(reader[4].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    cliente.Endereco = reader[5].ToString();
                    cliente.IdCidade = randNum.Next(1, 5570);

                    _contexto.Clientes.Add(cliente);
                }
                _contexto.SaveChanges();
            }while (reader.NextResult());

            reader.Close();
            return View(_contexto.Clientes.OrderBy(c=>c.Id).ToList());
        }

        public IActionResult Atendentes()
        {
            _contexto.Database.ExecuteSqlRaw("delete from Atendente");
            _contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Atendente', RESEED, 0)");
            Random randNum = new Random();

            Encoding ecode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("ExcelData/AtendentesData.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            reader.Read();

            do
            {
                while (reader.Read())
                {
                    AtendenteModel atendente = new AtendenteModel();
                    atendente.Nome = reader[0].ToString();
                    atendente.Registro = reader[1].ToString();
                    _contexto.Atendentes.Add(atendente);
                }
                _contexto.SaveChanges();
            } while (reader.NextResult());

            reader.Close();
            return View(_contexto.Atendentes.OrderBy(a => a.Id).ToList());
        }

        public IActionResult Procedimentos()
        {
            _contexto.Database.ExecuteSqlRaw("delete from Procedimento");
            _contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Procedimento', RESEED, 0)");
            Random randNum = new Random();

            Encoding ecode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("ExcelData/ProcedimentosData.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            reader.Read();

            do
            {
                while (reader.Read())
                {
                    ProcedimentoModel procedimento = new ProcedimentoModel();
                    procedimento.Codigo_Procedimento = long.Parse(reader[0].ToString());
                    procedimento.Descricao = reader[1].ToString();
                    procedimento.Prioridade = reader[2].ToString();
                    procedimento.Valor = float.Parse(reader[3].ToString());
                    procedimento.Data_Solicitacao = DateTime.ParseExact(reader[4].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    procedimento.IdAtendente = randNum.Next(1, 12);
                    procedimento.IdCliente = randNum.Next(1, 100);
                    _contexto.Procedimentos.Add(procedimento);
                }
                _contexto.SaveChanges();
            } while (reader.NextResult());

            reader.Close();
            return View(_contexto.Procedimentos.OrderBy(p => p.Id).ToList());
        }

        public IActionResult Tecnicos()
        {
            _contexto.Database.ExecuteSqlRaw("delete from Tecnico");
            _contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Tecnico', RESEED, 0)");
            Random randNum = new Random();

            Encoding ecode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("ExcelData/TecnicosData.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            reader.Read();

            do
            {
                while (reader.Read())
                {
                    TecnicoModel tecnico = new TecnicoModel();
                    tecnico.Nome = reader[0].ToString();
                    tecnico.Registro = long.Parse(reader[1].ToString());
                    tecnico.IdProcedimento = randNum.Next(1, 14);
                    _contexto.Tecnicos.Add(tecnico);
                }
                _contexto.SaveChanges();
            } while (reader.NextResult());

            reader.Close();
            return View(_contexto.Tecnicos.OrderBy(t => t.Id).ToList());
        }
    }
}
