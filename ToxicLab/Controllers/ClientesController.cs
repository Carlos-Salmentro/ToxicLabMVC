using Microsoft.AspNetCore.Mvc;
using ToxicLab.CasosDeUso.Clientes;
using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;

namespace ToxicLab.Controllers
{
    [ApiController]
    [Route("/Clientes")]
    public class ClientesController : ControllerBase
    {
        public static string[] Methods = new string[] { HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Put.ToString(), HttpMethod.Delete.ToString() };


        private readonly AdicionarClienteHandler adicionarClienteHandler;
        private readonly MostrarClientesHandler _mostrarClientesHandler;
        private readonly DeletarClienteHandler _deletarClienteHandler;
        private readonly BuscarClientePorIdHandler _buscarClientePorIdHandler;

        public ClientesController(AdicionarClienteHandler adicionarClienteHandler, MostrarClientesHandler _mostrarClientes, DeletarClienteHandler _deletarClienteHandler, BuscarClientePorIdHandler buscarClientePorIdHandler)
        {
            this.adicionarClienteHandler = adicionarClienteHandler;
            this._mostrarClientesHandler = _mostrarClientes;
            this._deletarClienteHandler = _deletarClienteHandler;
            this._buscarClientePorIdHandler = buscarClientePorIdHandler;
        }

        //Buscar clientes pagina inicial
        [HttpGet]
        public async Task<IActionResult> Action()
        {
            return Ok(_mostrarClientesHandler.Handle());
        }

        //buscar cliente por id
        [HttpGet("/Clientes/{id}")]
        public async Task<IActionResult> Action([FromRoute] int id)
        {
            return Ok(_buscarClientePorIdHandler.Handle(id));
        }

        [HttpPost]
        public async Task<IActionResult> Action([FromBody] AdicionarClienteRequest request)
        {
            return Ok(await adicionarClienteHandler.Handle(request));
        }

        //inativa o cliente
        [HttpPost("/{id}")]
        public async Task<IActionResult> AAction([FromRoute] int id)
        {
            return Ok(_deletarClienteHandler.Handle(id));
        }


    }
}
