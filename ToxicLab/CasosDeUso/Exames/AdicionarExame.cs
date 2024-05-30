using Dapper;
using MySqlConnector;
using ToxicLab.Dominio.Entidades;
using ToxicLab.Dominio.Enums;
using ToxicLab.InfraEstrutura.Repositorio;

namespace ToxicLab.CasosDeUso.Exames
{
    public class AdicionarExame
    {
        public class AdicionarExameRequest
        {
            public int ClienteId { get; set; }
            public DateTime DataRealizado { get; set; }
            public DateTime DataVencimento { get; set; }
            public MotivoExame MotivoExame { get; set; }
            public bool Ativo { get; set; }
        }

        public class AdicionarExameRequestHandler
        {
            private readonly AppDbContext _context;
            private readonly MySqlConnection _connection;

            public AdicionarExameRequestHandler(AppDbContext context, MySqlConnection _connection)
            {
                this._context = context;
                this._connection = _connection;
            }


            public async Task<AdicionarExameResponse> Handle(AdicionarExameRequest request)
            {
                Exame exame = new Exame(request.ClienteId, request.DataRealizado, request.DataVencimento, request.MotivoExame, request.Ativo);

                await _context.exames.AddAsync(exame);

                int exameId = await _connection.QueryFirstOrDefaultAsync<int>(
                    @"SELECT e.id
                    FROM toxiclab.exames AS e
                    WHERE e.cliente_id = @idCliente AND e.ativo = true;", new { idCliente = request.ClienteId });
                //inativar penultimo exame
                await _context.SaveChangesAsync();

                return new AdicionarExameResponse(exame.Id, exame.ClienteId);
            }
        }


        public class AdicionarExameResponse
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }

            public AdicionarExameResponse(int id, int clienteId)
            {
                Id = id;
                ClienteId = clienteId;
            }
        }

    }
}
