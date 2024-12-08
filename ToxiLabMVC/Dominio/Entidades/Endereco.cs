using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToxicLabMVC.Dominio.Enums;

namespace ToxicLabMVC.Dominio.Entidades
{
    [Table("enderecos")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int EnderecoId { get; set; }
        [ForeignKey("Cliente")]
        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        [Column("tipo_logradouro")]
        public int TipoLogradouro { get; set; }
        [Required]
        [Column("logradouro")]
        public string Logradouro { get; set; }
        [Required]
        [Column("numero")]
        public string Numero { get; set; }
        [Column("complemento")]
        public string? Complemento { get; set; }
        [Required]
        [Column("cep")]
        public string Cep { get; set; }
        [Required]
        [Column("bairro")]
        public string Bairro { get; set; }

        public Endereco() { }

        public Endereco(int clienteId, int tipoLogradouro, string logradouro, string numero, string? complemento, string cep, string bairro)
        {
            ClienteId = clienteId;
            TipoLogradouro = tipoLogradouro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
        }

        public Endereco(int tipoLogradouro, string logradouro, string numero, string? complemento, string cep, string bairro)
        {
            TipoLogradouro = tipoLogradouro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
        }
    }
}
