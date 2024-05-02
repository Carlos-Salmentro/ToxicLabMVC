using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;
using Dapper;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;

namespace ToxicLab.CasosDeUso.Clientes
{
    public class MostrarClientesRequest
    {

    }
    public class MostrarClientesHandler
    {
        private readonly AppDbContext _context;
        private readonly SqlConnection dbConexao;
        private readonly string dbString;

        public MostrarClientesHandler(AppDbContext _context, IConfiguration configuration)
        {
            this._context = _context;
            this.dbConexao = new SqlConnection (configuration["ConnectionStrings:ToxicLabString"]);
        }

        //Perguntar como transformar em async e List
        public async Task<List<MostrarClientesResponse>> Handle()
        {
            List<MostrarClientesResponse> clientesResponse = dbConexao.Query<MostrarClientesResponse>(
                @"SELECT c.id AS 'IdCliente', c.nome AS 'NomeCliente', timestampdiff(YEAR, c.data_nascimento, CURDATE()) AS 'Idade', c.vencimento_cnh AS 'VencimentoCnh', c.whatsapp AS 'WhatsApp', c.data_notificacao AS 'DataNotificacao',
                e.data_vencimento AS 'VencimentoExame', e.ativo AS 'Ativo'
                FROM toxiclab.clientes AS c
                INNER JOIN toxiclab.exames AS e ON e.cliente_id = c.id
                WHERE a.ativo = true AND e.ativo = true AND datediff(NOW(), c.data_notificacao) > 30 AND(datediff(c.vencimento_cnh, NOW()) < 30 OR datediff(e.data_vencimento, NOW()) < 30)
                ORDER BY e.data_vencimento;").ToList();

            return clientesResponse;
        }
    }

    public class MostrarClientesResponse
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public int Idade { get; set; }
        public DateOnly VencimentoCnh { get; set; }
        public string WhatsApp { get; set; }
        public DateOnly UltimaNotificacao { get; set; }
        public DateOnly VencimentoExame { get; set; }

    }
}




