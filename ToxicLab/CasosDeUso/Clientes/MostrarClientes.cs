using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;
using Dapper;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using MySqlConnector;
using System.Text.Json.Serialization;

namespace ToxicLab.CasosDeUso.Clientes
{
    public class MostrarClientesRequest
    {

    }
    public class MostrarClientesHandler
    {
        private readonly MySqlConnection dbConexao;

        public MostrarClientesHandler(IConfiguration configuration)
        {
            this.dbConexao = new MySqlConnection(configuration.GetConnectionString("ToxicLabString"));
        }

        public async Task<List<MostrarClientesResponse>> Handle()
        {
            var aux = await dbConexao.QueryAsync<MostrarClientesResponse>(
                @"SELECT c.id AS 'IdCliente', c.nome AS 'NomeCliente', timestampdiff(YEAR, c.data_nascimento, CURDATE()) AS 'Idade', c.vencimento_cnh AS 'VencimentoCnh', c.whatsapp AS 'WhatsApp', c.data_notificacao AS 'DataNotificacao', c.ativo AS 'Ativo',
                e.data_vencimento AS 'VencimentoExame', e.ativo AS 'Ativo'
                FROM toxiclab.clientes AS c
                INNER JOIN toxiclab.exames AS e ON e.cliente_id = c.id
                WHERE c.ativo = true AND e.ativo = true");


            List<MostrarClientesResponse> response = aux.ToList();

            return response;
        }
    }

    public class MostrarClientesResponse
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public int Idade { get; set; }
        public DateTime VencimentoCnh { get; set; }
        public string WhatsApp { get; set; }
        public DateTime UltimaNotificacao { get; set; }
        public DateTime VencimentoExame { get; set; }
        public bool Ativo { get; set; }
    }
}




