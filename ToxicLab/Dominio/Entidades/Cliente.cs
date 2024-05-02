using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToxicLab.Dominio.Enums;

namespace ToxicLab.Dominio.Entidades
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Column("nome")]    
        [Required]
        public string Nome { get; set; }
        [Column("data_nascimento")]
        [Required]
        public DateOnly Nascimento { get; set; }
        [Column("endereco")]
        [Required]
        public Endereco Endereco { get; set;}
        [Column("rg")]
        [Required]
        public string Rg { get; set; }
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
        [Required]
        public string Email { get; set; }
        [Column("data_notificacao")]
        [Required]
        public DateOnly DataNotificacao { get; set ; }
        [Column("ativo")]
        [Required]
        public bool Ativo { get; set; }

        public Cliente(string nome, DateOnly nascimento, Endereco endereco, string rg, string cpf, string cnh, DateOnly vencimentoCnh, string whatsApp, string email, DateOnly dataNotificacao, bool ativo)
        {
            Nome = nome;
            Nascimento = nascimento;
            Endereco = endereco;
            Rg = rg;
            Cpf = cpf;
            Cnh = cnh;
            VencimentoCnh = vencimentoCnh;
            WhatsApp = whatsApp;
            Email = email;
            Ativo = ativo;

            if (dataNotificacao != null)
            {
                DataNotificacao = DataNotificacao;
            }
            else
            {
                DateTime now = DateTime.Now;

                DataNotificacao = DateOnly.Parse(now.ToString());
            }
        }

        public Cliente() { }

      
    }
}
