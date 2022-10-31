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
            restaurante = Ado.RestaurantePorId(restaurante.Id);
            if (restaurante is null)
            {
            return NotFound();
        }
        else
            Ado.EliminarRestaurante(restaurante);
        return Redirect(nameof(Index));
        }
         [HttpGet]
        public IActionResult ActualizarRestaurante(int id)
        {
            Restaurante restos = Ado.RestaurantePorId(id);
            if (restos is null)
            {
             return NotFound();
            }
            else
                return View(restos);
    }

    [HttpPost]
    public IActionResult ActualizarRestaurantea(Restaurante restaurante)
    {
        Ado.ActualizarRestaurante(restaurante);
        return View("Listado", Ado.ObtenerRestaurante());
    }
    }
}
