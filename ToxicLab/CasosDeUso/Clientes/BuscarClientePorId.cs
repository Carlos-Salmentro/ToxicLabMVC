using MySqlConnector;
using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;
using Dapper;
using Microsoft.AspNetCore.Routing.Template;

namespace ToxicLab.CasosDeUso.Clientes
{
    public class BuscarClientePorIdRequest
    {
        int id { get; set; }
    }

    public class BuscarClientePorIdHandler
    {
        //private readonly AppDbContext _context;
        private readonly MySqlConnection _dbConnection;

        public BuscarClientePorIdHandler(/*AppDbContext context,*/ IConfiguration configuration)
        {
            //this._context = context;
            this._dbConnection = new MySqlConnection(configuration.GetConnectionString("ToxicLabString"));

        }

        public async Task<List<BuscarClientePorIdResponse>> Handle(int id)
        {

            string query = @"SELECT c.nome AS Nome, c.data_nascimento AS DataNascimento, c.rg AS Rg, c.cpf AS Cpf, c.cnh AS Cnh, c.vencimento_cnh AS VencimentoCnh,
                c.whatsapp AS WhatsApp, c.email AS Email, c.data_notificacao AS UltimaNotificacao, c.ativo AS Ativo
                FROM toxiclab.clientes AS c
                WHERE c.id = @identificador";
            
            var aux = await _dbConnection.QueryAsync<BuscarClientePorIdResponse>(query, new {identificador = id });

            //var aux = await _dbConnection.QueryAsync<BuscarClientePorIdResponse>(
            //   @"SELECT c.nome AS Nome, c.data_nascimento AS Nascimento, c.rg AS Rg, c.Cpf AS Cpf, c.Cnh AS Cnh,
            //    c.vencimento_cnh AS VencimentoCnh, c.whatsapp AS WhatsApp, c.email AS Email, c.data_notificacao AS UltimaNotificacao, c.ativo AS Ativo,
            //    Endereco.id AS Id, Endereco.cliente_id AS ClienteId, Endereco.tipo_logradouro AS TipoLogradouro, Endereco.logradouro AS Logradouro,
            //    Endereco.numero AS Numero, Endereco.complemento AS Complemento, Endereco.cep AS Cep, Endereco.bairro AS Bairro,
            //    Exame.id As Id, Exame.cliente_id AS ClienteId, Exame.data_realizado AS DataRealizado, Exame.data_vencimento AS DataVencimento, Exame.motivo_exame AS MotivoExame
            //    FROM toxiclab.clientes AS c, toxiclab.enderecos AS ende, toxiclab.exames AS ex
            //    INNER JOIN toxiclab.enderecos AS Endereco ON e.cliente_id = c.id
            //    INNER JOIN toxiclab.exames AS Exame ON ex.cliente_id = c.id
            //    WHERE c.id = id;");

            return aux.ToList();
        }
    }

    public class BuscarClientePorIdResponse
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime VencimentoCnh { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public DateTime UltimaNotificacao { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public bool Ativo { get; set; }
        //public Endereco Endereco { get; set; }
       // public List<Exame> Exames { get; set; }
    }
}
