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
                
        public ClienteController(AdicionarClienteHandler adicionarClienteHandler)
        {
            this.adicionarClienteHandler = adicionarClienteHandler;
        }
        

        [HttpPost]
        public IResult Action([FromBody]AdicionarClienteRequest request)
        {
            return Results.Ok(adicionarClienteHandler.Handle(request));
        }
    }
}
