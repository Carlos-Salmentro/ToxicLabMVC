using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToxicLabMVC.Dominio.Enums;

namespace ToxicLabMVC.Dominio.Entidades
{
    public class Exame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("id")]
        public int ExameId { get; set; }
        [ForeignKey("Cliente")]
        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        [Column("data_realizado")]
        [Required]
        public DateTime DataRealizado { get; set; }
        [Column("data_vencimento")]
        [Required]
        public DateTime DataVencimento { get; set; }
        [Column("motivo_exame")]
        [Required]
        public MotivoExame MotivoExame { get; set; }
        [Column("ativo")]
        [Required]
        public bool Ativo { get; set; }
        [Column("valor_exame")]
        [Required]
        public decimal ValorExame { get; set; }
        [Column("valor_repasse")]
        [Required]
        public decimal ValorRepasse { get; set; }
        [Column("voucher")]
        [Required]
        public bool Voucher { get; set; }
        [Column("valor_analise")]
        [Required]
        public decimal ValorAnalise { get; set; }

        public Exame() { }

        public Exame(int clienteId, DateTime dataRealizado, DateTime dataVencimento, MotivoExame motivoExame, bool ativo, decimal valorExame, decimal valorRepasse, bool voucher, decimal valorAnalise)
        {
            ClienteId = clienteId;
            DataRealizado = dataRealizado;
            DataVencimento = dataVencimento;
            MotivoExame = motivoExame;
            Ativo = ativo;
            ValorExame = valorExame;
            ValorRepasse = valorRepasse;
            Voucher = voucher;
            ValorAnalise = valorAnalise;
        }
    }
}
