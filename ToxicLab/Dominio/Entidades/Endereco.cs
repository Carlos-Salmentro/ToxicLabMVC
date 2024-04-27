using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToxicLab.Dominio.Enums;

namespace ToxicLab.Dominio.Entidades
{
    [Table("enderecos")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Cliente")]
        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        [Required]
        [Column("tipo_logradouro")]
        public TiposLogradouro TiposLogradouro { get; set; }
        [Required]
        [Column("logradouro")]
        public string Logradouro { get; set; }
        [Required]
        [Column("numero")]
        public string Numero { get; set; }
        [Required]
        [Column("complemento")]
        public string Complemento { get; set; }
        [Required]
        [Column("cep")]
        public string Cep { get; set; }
        [Required]
        [Column("bairro")]
        public string Bairro { get; set; }

        public Endereco() { }

        public Endereco(TiposLogradouro tiposLogradouro, string logradouro, string numero, string complemento, string cep, string bairro)
        {
            TiposLogradouro = tiposLogradouro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
        }
    }
}
