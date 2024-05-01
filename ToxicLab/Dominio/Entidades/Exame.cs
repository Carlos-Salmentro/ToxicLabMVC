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
        [ForeignKey("cliente_id")]
        [Required]
        public int ClienteId { get; set; }
        [Column("data_realizado")]
        [Required]
        public DateOnly DataRealizado { get; set; }
        [Column("data_vencimento")]
        [Required]
        public DateOnly DataVencimento { get; set; }
        [Column("motivo_exame")]
        [Required]
        public MotivoExame MotivoExame { get; set; }
        [Column("ativo")]
        [Required]
        public bool Ativo { get; set; }

        public Exame() { }
        
        public Exame(int clienteId, DateOnly dataRealizado, DateOnly dataVencimento, MotivoExame motivoExame, bool ativo)
        {
            ClienteId = clienteId;
            DataRealizado = dataRealizado;
            DataVencimento = dataVencimento;
            MotivoExame = motivoExame;
            Ativo = ativo;
        }
    }
}
