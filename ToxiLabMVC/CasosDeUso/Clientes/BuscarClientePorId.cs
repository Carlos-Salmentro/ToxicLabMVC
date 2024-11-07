using MySqlConnector;
using ToxicLabMVC.Dominio.Entidades;
using ToxicLabMVC.InfraEstrutura.Repositorio;
using Dapper;
using Microsoft.AspNetCore.Routing.Template;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components.Forms;

namespace ToxicLabMVC.CasosDeUso.Clientes
{
    public class BuscarClientePorIdRequest
    {
        int id { get; set; }
    }

    public class BuscarClientePorIdHandler
    {
        //private readonly AppDbContext _context;
        private readonly MySqlConnection _dbConnection;

        public BuscarClientePorIdHandler(IConfiguration configuration)
        {
            this._dbConnection = new MySqlConnection(configuration.GetConnectionString("ToxicLabString"));

        }

        public async Task<BuscarClientePorIdResponse> Handle(int id)
        {

            string query = @"SELECT c.id AS Id, c.nome AS Nome, c.data_nascimento AS DataNascimento, c.numero_custodia AS NumeroCustodia, c.cpf AS Cpf, c.cnh AS Cnh, c.vencimento_cnh AS VencimentoCnh,
                c.whatsapp AS WhatsApp, c.email AS Email, c.data_notificacao AS UltimaNotificacao, c.ativo AS Ativo, e.id AS EnderecoId, e.tipo_logradouro AS TipoLogradouro, e.logradouro AS Logradouro, e.numero AS Numero, e.complemento AS Complemento, e.cep AS Cep, e.bairro AS Bairro
                FROM ToxicLabMVC.clientes AS c, ToxicLabMVC.enderecos AS e
                INNER JOIN ToxicLabMVC.enderecos ON enderecos.cliente_id = @identificador
                WHERE c.id = @identificador";

            string query2 = @"SELECT e.id AS Id, e.cliente_id AS ClienteId, e.data_realizado AS DataRealizado, e.data_vencimento AS DataVencimento, e.motivo_exame AS MotivoExame
                            FROM ToxicLabMVC.exames AS e
                            WHERE e.cliente_id = @identificador ";



            ClienteResponse cliente = await _dbConnection.QueryFirstOrDefaultAsync<ClienteResponse>(query, new { identificador = id });
            List<Exame> aux = new List<Exame>(await _dbConnection.QueryAsync<Exame>(query2, new { identificador = id }));

            BuscarClientePorIdResponse response = new BuscarClientePorIdResponse() { Cliente = cliente, Exames = aux.ToList() };


            return response;
        }
    }

    public class ClienteResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public string NumeroCustodia { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime? VencimentoCnh { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public string? WhatsApp { get; set; }
        public string? Email { get; set; }
        public DateTime? UltimaNotificacao { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public bool Ativo { get; set; }
        public string EnderecoId { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
    }


    public class BuscarClientePorIdResponse
    {
        public ClienteResponse Cliente { get; set; }
        public List<Exame> Exames { get; set; }

    }
}
