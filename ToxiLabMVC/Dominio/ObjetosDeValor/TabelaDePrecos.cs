using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToxicLabMVC.Dominio.ObjetosDeValor
{
    [Table("tabela_precos")]
    public class TabelaDePrecos
    {
        [Column("valor_exame")]
        public decimal ValorExame;
        [Column("valor_repasse")]
        public decimal ValorRepasse;
        [Column("valor_analise")]
        public double ValorAnalise;
        [Column("valor_voucher")]
        public decimal ValorVoucher;
    }
}
