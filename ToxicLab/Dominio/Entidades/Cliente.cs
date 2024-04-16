﻿using System.ComponentModel.DataAnnotations;
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
        public DateTime Nascimento { get; set; }
        [Column("endereco")]
        [Required]
        public string Endereco { get; set;}
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
        public DateTime VencimentoCnh { get; set; }
        [Column("whatsapp")]
        [Required]
        public string WhatsApp { get; set; }
        [Column("email")]
        [Required]
        public string Email { get; set; }
        

        public Cliente(string nome, DateTime nascimento, string endereco, string rg, string cpf, string cnh, DateTime vencimentoCnh, string whatsApp, string email)
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
        }

        public Cliente() { }
    }
}
