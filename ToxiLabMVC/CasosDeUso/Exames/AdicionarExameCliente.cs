using Dapper;
using MySqlConnector;
using ToxicLabMVC.Dominio.Entidades;
using ToxicLabMVC.Dominio.Enums;
using ToxicLabMVC.InfraEstrutura.Repositorio;

namespace ToxicLabMVC.CasosDeUso.Exames
{

    public class AdicionarExameClienteRequest
    {
        public int ClienteId { get; set; }
        public DateTime DataRealizado { get; set; }
        public DateTime DataVencimento { get; set; }
        public MotivoExame MotivoExame { get; set; }
        public bool Ativo { get; set; }
        public decimal ValorExame { get; set; }
        public decimal ValorRepasse { get; set; }
        public bool Voucher { get; set; }
        public decimal ValorAnalise { get; set; }
    }

    public class AdicionarExameClienteHandler
    {
        private readonly AppDbContext _context;
        private readonly MySqlConnection _connection;

        public AdicionarExameClienteHandler(AppDbContext context, MySqlConnection _connection)
        {
            this._context = context;
            this._connection = _connection;
        }


        public async Task<AdicionarExameClienteResponse> Handle(AdicionarExameClienteRequest request)
        {
            Exame exame = new Exame(request.ClienteId, request.DataRealizado, request.DataVencimento, request.MotivoExame, request.Ativo, request.ValorExame, request.ValorRepasse, request.Voucher, request.ValorAnalise);

            await _context.exames.AddAsync(exame);

            int exameId = await _connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT e.id
                    FROM ToxicLabMVC.exames AS e
                    WHERE e.cliente_id = @idCliente AND e.ativo = true;", new { idCliente = request.ClienteId });
            //inativar penultimo exame
            await _context.SaveChangesAsync();

            return new AdicionarExameClienteResponse(exame.ExameId, exame.ClienteId);
        }
    }


    public class AdicionarExameClienteResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public AdicionarExameClienteResponse(int id, int clienteId)
        {
            Id = id;
            ClienteId = clienteId;
        }
    }



}
