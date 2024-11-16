using Microsoft.AspNetCore.Mvc;
using ToxicLabMVC.InfraEstrutura.Repositorio;

namespace ToxiLabMVC.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult AdicionarCliente()
        {
            ClientesModel clientesModel = new ClientesModel();
            return View(clientesModel);
        }
    }
}
