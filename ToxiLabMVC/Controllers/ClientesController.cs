using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using ToxicLabMVC.Dominio.Entidades;
using ToxicLabMVC.Dominio.Enums;
using ToxicLabMVC.InfraEstrutura.Repositorio;
using ToxiLabMVC.Interfaces;
using ToxiLabMVC.Models.Clientes.ClienteServico;

namespace ToxiLabMVC.Controllers
{
    public class ClientesController : Controller, ICliente
    {

        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes = _context.clientes.Where(x => x.Ativo == true).ToList();

            ClientesModel clientesModel = new ClientesModel();
            clientesModel.Clientes = clientes;

            return View(clientesModel);

        }

        [HttpGet]
        public IActionResult AdicionarCliente()
        {
            ClientesModel clientesModel = new ClientesModel();
            return View(clientesModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente([FromForm] ClientesModel clientesModel)
        {
            Cliente cliente = Model_Cliente.ModelToCliente(clientesModel);
            
            //string whatsapp = String.Concat(clientesModel.DDD, clientesModel.WhatsApp);

            //Endereco endereco = new Endereco(clientesModel.TipoLogradouro, clientesModel.TipoLogradouro, clientesModel.Logradouro,
            //    clientesModel.Numero, clientesModel.Complemento, clientesModel.CEP, clientesModel.Bairro);

            //Cliente cliente = new Cliente(clientesModel.Nome, clientesModel.Nascimento,
            //    clientesModel.NumeroCustodia, clientesModel.Cpf, clientesModel.Cnh, clientesModel.VencimentoCnh,
            //     endereco, whatsapp, clientesModel.Email.ToString(), clientesModel.DataNotificacao, true);

            await _context.clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();


            return View("EditarCliente", clientesModel);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCliente([FromForm] string? Cnh, string? Cpf, string? Nome)
        {

            if (String.IsNullOrEmpty(Cnh) && String.IsNullOrEmpty(Cpf) && String.IsNullOrEmpty(Nome))
            {
                return View("ErroBuscaCliente");
            }

            Cliente cliente = new Cliente();

            if (String.IsNullOrEmpty(Cnh) == false)
            {
                cliente = await _context.clientes.FirstOrDefaultAsync(x => x.Cnh == Cnh);

                if(cliente != null)
                {
                    return View("EditarCliente", cliente);
                }
            }

            if (cliente == null)
            {
                return View("ErroClienteNaoEncontrado");
            }

            ClientesModel clientesModel = new ClientesModel();
            clientesModel.Nome = cliente.Nome;
            clientesModel.Nascimento = cliente.Nascimento;
            clientesModel.TipoLogradouro = cliente.Endereco.TipoLogradouro;
            clientesModel.Logradouro = cliente.Endereco.Logradouro;
            clientesModel.Numero = cliente.Endereco.Numero;
            clientesModel.Complemento = cliente.Endereco.Complemento;
            clientesModel.Bairro = cliente.Endereco.Bairro;
            clientesModel.CEP = cliente.Endereco.Cep;
            clientesModel.Cnh = cliente.Cnh;
            clientesModel.VencimentoCnh = cliente.VencimentoCnh;
            clientesModel.Cpf = cliente.Cpf;
            clientesModel.DDD = cliente.WhatsApp.Substring(1, 2);
            clientesModel.WhatsApp = cliente.WhatsApp.Substring(3, cliente.WhatsApp.Length - 2);
            clientesModel.Email = cliente.Email;
            clientesModel.Ativo = cliente.Ativo;

            return View("EditarCliente", clientesModel);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCliente([FromForm] string Cpf)
        {
            Cliente cliente = await _context.clientes.FirstOrDefaultAsync(x => x.Cnh == Cpf);



            ClientesModel clientesModel = new ClientesModel();
            clientesModel.Nome = cliente.Nome;
            clientesModel.Nascimento = cliente.Nascimento;
            clientesModel.TipoLogradouro = cliente.Endereco.TipoLogradouro;
            clientesModel.Logradouro = cliente.Endereco.Logradouro;
            clientesModel.Numero = cliente.Endereco.Numero;
            clientesModel.Complemento = cliente.Endereco.Complemento;
            clientesModel.Bairro = cliente.Endereco.Bairro;
            clientesModel.CEP = cliente.Endereco.Cep;
            clientesModel.Cnh = cliente.Cnh;
            clientesModel.VencimentoCnh = cliente.VencimentoCnh;
            clientesModel.Cpf = cliente.Cpf;
            clientesModel.DDD = cliente.WhatsApp.Substring(1, 2);
            clientesModel.WhatsApp = cliente.WhatsApp.Substring(3, cliente.WhatsApp.Length - 2);
            clientesModel.Email = cliente.Email;
            clientesModel.Ativo = cliente.Ativo;

            return View("EditarCliente", clientesModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditarCliente(int clienteId)
        {
            Cliente cliente = await _context.clientes.FirstOrDefaultAsync(x => x.ClienteId == clienteId);

            ClientesModel clientesModel = new ClientesModel();

            clientesModel.Nome = cliente.Nome;
            clientesModel.Nascimento = cliente.Nascimento;
            clientesModel.TipoLogradouro = cliente.Endereco.TipoLogradouro;
            clientesModel.Logradouro = cliente.Endereco.Logradouro;
            clientesModel.Numero = cliente.Endereco.Numero;
            clientesModel.Complemento = cliente.Endereco.Complemento;
            clientesModel.Bairro = cliente.Endereco.Bairro;
            clientesModel.CEP = cliente.Endereco.Cep;
            clientesModel.Cnh = cliente.Cnh;
            clientesModel.VencimentoCnh = cliente.VencimentoCnh;
            clientesModel.Cpf = cliente.Cpf;
            clientesModel.DDD = cliente.WhatsApp.Substring(1, 2);
            clientesModel.WhatsApp = cliente.WhatsApp.Substring(3, cliente.WhatsApp.Length - 2);
            clientesModel.Email = cliente.Email;
            clientesModel.Ativo = cliente.Ativo;
            //Endereco endereco = await _context.enderecos.FirstOrDefaultAsync(x => x.ClienteId == cliente.ClienteId);
            //List<Exame> exames = _context.exames.Where(x => x.ClienteId == id).OrderByDescending(x => x.DataRealizado).ToList();
            //ClientesModel clienteModel = new ClientesModel() { Nome = cliente.Nome, Endereco = endereco, };
            return View(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> EditarCliente(ClientesModel clienteModel, Cliente cliente)
        {
            return View();
        }

        [HttpGet]
        public IActionResult DesativarConfirmacao([FromForm] ClientesModel clienteModel)
        {
            return View(clienteModel);
        }

        [HttpPut]
        public IActionResult Desativar(ClientesModel clienteModel)
        {
            Cliente cliente = _context.clientes.FirstOrDefault(x => x.ClienteId == clienteModel.Id);

            if (cliente != null)
            {
                cliente.Ativo = false;
                _context.clientes.Update(cliente);
                _context.SaveChanges();
                return View("Index");
            }

            else
            {
                return View("Erro");
            }
        }
    }
}
