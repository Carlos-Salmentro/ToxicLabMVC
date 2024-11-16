using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ToxicLab.CasosDeUso.Clientes;
using ToxicLab.CasosDeUso.Exames;
using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;

namespace ToxicLab.Controllers
{
    [ApiController]
    [Route("/Clientes/")]
    public class ClientesController : ControllerBase
    {
        public static string[] Methods = new string[] { HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Put.ToString(), HttpMethod.Delete.ToString() };

        private readonly AdicionarClienteHandler _adicionarClienteHandler;
        private readonly MostrarClientesHandler _mostrarClientesHandler;
        private readonly DeletarClienteHandler _deletarClienteHandler;
        private readonly BuscarClientePorIdHandler _buscarClientePorIdHandler;
        private readonly AdicionarExameClienteHandler _adicionarExameClienteHandler;
       

        public ClientesController(AdicionarClienteHandler adicionarClienteHandler, MostrarClientesHandler _mostrarClientes, DeletarClienteHandler _deletarClienteHandler, BuscarClientePorIdHandler buscarClientePorIdHandler, AdicionarExameClienteHandler adicionarExameClienteHandler)
        {
            this._adicionarClienteHandler = adicionarClienteHandler;
            this._mostrarClientesHandler = _mostrarClientes;
            this._deletarClienteHandler = _deletarClienteHandler;
            this._buscarClientePorIdHandler = buscarClientePorIdHandler;
            this._adicionarExameClienteHandler = adicionarExameClienteHandler;            
        }

        //Buscar clientes pagina inicial
        [HttpGet]
        public async Task<IActionResult> BuscarClientesPaginaInicial()
        {
            return Ok(await _mostrarClientesHandler.Handle());
        }

        //buscar cliente por id
        [HttpGet("Cliente/{id}/")]
        public async Task<IActionResult> BuscarCLientePorId([FromRoute] int id)
        {
            return Ok(await _buscarClientePorIdHandler.Handle(id));
        }

        //adiciona cliente
        [HttpPost]
        public async Task<IActionResult> AdicionarCliente([FromBody] AdicionarClienteRequest request)
        {
            return Ok(await _adicionarClienteHandler.Handle(request));
        }

        //inativa o cliente
        [HttpPut("{id}/")]
        public async Task<IActionResult> InativarCLiente([FromRoute] int id)
        {
            return Ok(await _deletarClienteHandler.Handle(id));
        }

       
    }
}
