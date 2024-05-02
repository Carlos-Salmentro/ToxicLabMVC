using Microsoft.AspNetCore.Mvc;
using ToxicLab.CasosDeUso.Clientes;
using ToxicLab.Dominio.Entidades;
using ToxicLab.InfraEstrutura.Repositorio;

namespace ToxicLab.Controllers.ClienteControllers
{
    [ApiController]
    [Route("/Clientes")]
    public class ClienteController : Controller
    {
        public static string[] Methods = new string[] {HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Put.ToString(), HttpMethod.Delete.ToString()};

        
        private readonly AdicionarClienteHandler adicionarClienteHandler;
        private readonly MostrarClientesHandler _mostrarClientesHandler;
        private readonly DeletarClienteHandler _deletarClienteHandler;
                
        public ClienteController(AdicionarClienteHandler adicionarClienteHandler, MostrarClientesHandler _mostrarClientes, DeletarClienteHandler _deletarClienteHandler)
        {
            this.adicionarClienteHandler = adicionarClienteHandler;
            this._mostrarClientesHandler = _mostrarClientes;
            this._deletarClienteHandler = _deletarClienteHandler;
        }

        [HttpGet]
        public IResult Action()
        {
            return Results.Ok(_mostrarClientesHandler.Handle());
        }

        [HttpPost]
        public IResult Action([FromBody]AdicionarClienteRequest request)
        {
            return Results.Ok(adicionarClienteHandler.Handle(request));
        }

        //inativa o cliente
        [HttpDelete("/{id}")]
        public IResult Action([FromRoute]int id)
        {
            return Results.Ok(_deletarClienteHandler.Handle(id));
        }


    }
}
