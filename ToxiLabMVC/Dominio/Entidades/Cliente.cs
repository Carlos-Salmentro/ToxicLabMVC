using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToxicLabMVC.Dominio.Enums;

namespace ToxicLabMVC.Dominio.Entidades
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Required]
        public int ClienteId { get; set; }
        [Column("nome")]    
        [Required]
        public string Nome { get; set; }
        [Column("data_nascimento")]
        [Required]
        public DateOnly Nascimento { get; set; }
        [Column("numero_custodia")]
        [Required]
        public string NumeroCustodia { get; set; }
        [Column("cpf")]
        [Required]
        public string Cpf { get; set; }
        [Column("cnh")]
        [Required]
        public string Cnh { get; set; }
        [Column("vencimento_cnh")]
        [Required]
        public DateOnly VencimentoCnh { get; set; }
        [Column("whatsapp")]
        [Required]
        public string WhatsApp { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("data_notificacao")]
        public DateOnly DataNotificacao { get; set ; }
        [Column("ativo")]
        [Required]
        public bool Ativo { get; set; }
        public List<Exame> Exames { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente(string nome, DateOnly nascimento, string numeroCustodia, string cpf, string cnh, DateOnly vencimentoCnh, Endereco endereco, string whatsApp, string email, DateOnly dataNotificacao, bool ativo)
        {
            Nome = nome;
            Nascimento = nascimento;
            NumeroCustodia = numeroCustodia;
            Cpf = cpf;
            Cnh = cnh;
            VencimentoCnh = vencimentoCnh;
            Endereco = endereco;
            WhatsApp = whatsApp;
            Email = email;
            Ativo = ativo;

            if (dataNotificacao != null)
            {
                DataNotificacao = dataNotificacao;
            }
            else
            {
                DateTime now = DateTime.Now;

                DataNotificacao = DateOnly.FromDateTime(now);
            }
        }

        public Cliente() { }

      
    }
}
