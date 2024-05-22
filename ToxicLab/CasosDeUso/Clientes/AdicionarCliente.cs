using Microsoft.AspNetCore.Mvc;
using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;
using ToxicLab.Validadores;
using FluentValidation;
using System.Globalization;

namespace ToxicLab.CasosDeUso.Clientes
{
    public class AdicionarClienteRequest
    {
        public string Nome { get; set; }
        public string Nascimento { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public Endereco Endereco { get; set; }
        public string NumeroCustodia { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public string VencimentoCnh { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public string DataNotificacao { get; set; } //Alterado de DateOnly para string - Conversao no construtor
        public bool Ativo { get; set; }
    }

    public class AdicionarClienteHandler
    {
        private AppDbContext _context;

        public AdicionarClienteHandler(AppDbContext context)
        {
            _context = context;
        }


        public async Task<AdicionarClienteResponse> Handle(AdicionarClienteRequest request)
        {
            Cliente cliente = new Cliente(request.Nome, DateOnly.ParseExact(request.Nascimento, "yyyy-MM-dd"), request.Endereco, request.NumeroCustodia, request.Cpf, request.Cnh, DateOnly.ParseExact(request.VencimentoCnh, "yyyy-MM-dd"),
            request.WhatsApp, request.Email, DateOnly.ParseExact(request.DataNotificacao, "yyyy-MM-dd"), request.Ativo);

            await _context.clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return new AdicionarClienteResponse(cliente.Id);
        }
    }


    public class AdicionarClienteResponse
    {
        public int Id { get; set; }

        public AdicionarClienteResponse(int id)
        {
            Id = id;
        }

    }

    public class AdicionarClienteRequestValidador : AbstractValidator<AdicionarClienteRequest>
    {
        public AdicionarClienteRequestValidador()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Nome).MinimumLength(8).MaximumLength(100).WithMessage("O nome precisa ser ter entre 8 e 100 caracteres.");
            RuleFor(x => x.Nascimento).NotEmpty().NotNull().WithMessage("Preencha a data de nascimento");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("O E-mail deve ser válido.");

            RuleFor(x => x.Cpf).Must(CpfValido).WithMessage("CPF inválido.");
        }

        private bool CpfValido(string cpf)
        {
            int sum = 0;
            int teste = 0;
            int dig1 = cpf[9] - '0';
            int dig2 = cpf[10] - '0';


            for (int i = 0; i < 9; i++)
            {
                int aux = cpf[i] - '0';
                sum += aux * (i + 1);
            }

            teste = sum % 11;

            if (teste == 10)
                teste = 0;

            if (dig1 != teste)
            {
                return false;
            }

            sum = 0;
            teste = 0;

            for (int i = 0; i < 10; i++)
            {
                int aux = cpf[i] - '0';
                sum += aux * i;
            }

            teste = sum % 11;

            if (teste == 10)
                teste = 0;

            if (dig2 != teste)
            {
                return false;
            }

            return true;
        }
    }



}
