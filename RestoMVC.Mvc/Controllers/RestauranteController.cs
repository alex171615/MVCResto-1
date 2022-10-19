using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers
{

    public class RestauranteController : Controller
    {
        private readonly IAdo Ado;
        public RestauranteController(IAdo ado) => Ado = ado;

        [HttpGet]
        public IActionResult Index()
        {
            return View("Listado", Ado.ObtenerRestaurante());
        }
        [HttpGet]
        public IActionResult AltaRestaurante()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaRestaurante(Restaurante restaurante)
        {
            Ado.AltaRestaurante(restaurante);
            return View("Listado", Ado.ObtenerRestaurante());
        }
        [HttpGet]
        public IActionResult EliminarRestaurante(Restaurante restaurante)
        {
            restaurante = Ado.
        }

    }
}
