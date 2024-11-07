using System.ComponentModel.DataAnnotations.Schema;

namespace ToxicLabMVC.Dominio.ObjetosDeValor
{
    [Table("tabela_precos")]
    public class TabelaDePrecos
    {
        [Column("valor_exame")]
        public double ValorExame;
        [Column("valor_repasse")]
        public double ValorRepasse;
        [Column("valor_analise")]
        public double ValorAnalise;
        [Column("valor_voucher")]
        public double ValorVoucher;
    }
}
