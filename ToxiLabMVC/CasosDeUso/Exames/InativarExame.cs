using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ToxicLabMVC.Dominio.Entidades;
using ToxicLabMVC.InfraEstrutura.Repositorio;

namespace ToxicLabMVC.CasosDeUso.Exames
{
    public class InativarExame
    {
        public class InativarExameRequest
        {
            public int Id;
        }

        public class InativarExameHandler
        {
            private readonly AppDbContext _context;
            
            public InativarExameHandler(AppDbContext _context, MySqlConnection _connection)
            {
                this._context = _context;
            }

            public async Task<InativarExameResponse> Handle(InativarExameRequest request)
            {
                Exame exame = await _context.exames.FirstOrDefaultAsync(x => x.ExameId == request.Id);
                exame.Ativo = false;

                _context.SaveChanges();

                return new InativarExameResponse() { Id = request.Id };
            }
        }

        public class InativarExameResponse
        {
            public int Id { get; set; }
        }
    }
}
