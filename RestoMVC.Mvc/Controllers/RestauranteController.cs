using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers
{

    public class RestauranteController : Controller
    {
        private readonly IAdo Ado;
        public RestauranteController(IAdo ado) => Ado = ado;
        public IActionResult Index()
        {
            var restaurantes = Ado.ObtenerRestaurante();
            return View("Listado", restaurantes);
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
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EliminarRestaurante(Restaurante restaurante)
        {
            restaurante = Ado.EliminarRestaurante(restaurante);


        }
    }
}
