using Microsoft.AspNetCore.Mvc;
using ToxicLab.CasosDeUso.Clientes;
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

        public ClientesController(AdicionarClienteHandler adicionarClienteHandler, MostrarClientesHandler _mostrarClientes, DeletarClienteHandler _deletarClienteHandler, BuscarClientePorIdHandler buscarClientePorIdHandler)
        {
            this._adicionarClienteHandler = adicionarClienteHandler;
            this._mostrarClientesHandler = _mostrarClientes;
            this._deletarClienteHandler = _deletarClienteHandler;
            this._buscarClientePorIdHandler = buscarClientePorIdHandler;
        }

        //Buscar clientes pagina inicial
        [HttpGet]
        public async Task<IActionResult> Action()
        {
            return Ok(await _mostrarClientesHandler.Handle());
        }

        //buscar cliente por id
        [HttpGet("Cliente/{id}")]
        public async Task<IActionResult> Action([FromRoute] int id)
        {
            return Ok(await _buscarClientePorIdHandler.Handle(id));
        }

        [HttpPost]
        public async Task<IActionResult> Action([FromBody] AdicionarClienteRequest request)
        {
            return Ok(await _adicionarClienteHandler.Handle(request));
        }

        //inativa o cliente
        [HttpPost("/{id}")]
        public async Task<IActionResult> DeleteAction([FromRoute] int id)
        {
            return Ok(await _deletarClienteHandler.Handle(id));
        }


    }
}
