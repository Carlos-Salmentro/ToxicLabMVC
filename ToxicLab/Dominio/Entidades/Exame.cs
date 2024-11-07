using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToxicLab.Dominio.Enums;

namespace ToxicLab.Dominio.Entidades
{
    public class Exame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Column("cliente_id")]
        [ForeignKey("cliente_id")]
        [Required]
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
        public double ValorExame { get; set; }
        [Column("valor_repasse")]
        [Required]
        public double ValorRepasse { get; set; }
        [Column("voucher")]
        [Required]
        public bool Voucher { get; set; }
        [Column("valor_analise")]
        [Required]
        public double ValorAnalise { get; set; }

        public Exame() { }

        public Exame(int clienteId, DateTime dataRealizado, DateTime dataVencimento, MotivoExame motivoExame, bool ativo, double valorExame, double valorRepasse, bool voucher, double valorAnalise)
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
