using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers
{

    public class PlatoController : Controller
    {
        private readonly IAdo Ado;
        public PlatoController(IAdo ado) => Ado = ado;
        public async Task<IActionResult> Index()
        {
            var restaurantes = await Ado.ObtenerPlatoAsync();
            return View("Listado", restaurantes);
        }



        [HttpGet]
        public IActionResult AltaRestaurante()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AltaRestaurante(Restaurante restaurante)
        {
            await Ado.AltaRestauranteAsync(restaurante);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> EliminarRestaurante(Restaurante restaurante)
        {
            restaurante = await Ado.RestaurantePorIdAsync(restaurante.Id);
            if (restaurante is null)
            {
                return NotFound();
            }
            else
                await Ado.EliminarRestauranteAsync(restaurante);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> ActualizarRestaurante(int id)
        {
            Restaurante restos = await Ado.RestaurantePorIdAsync(id);
            if (restos is null)
            {
                return NotFound();
            }
            else
                return View(restos);
        }



        [HttpPost]
        public async Task<IActionResult> ActualizarRestauranteAsync(Restaurante restaurante)
        {
            await Ado.ActualizarRestauranteAsync(restaurante);
            await Ado.ActualizarRestauranteAsync(restaurante);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<ActionResult> Login(Restaurante resto)
        {
            var log = await Ado.restoPorPassAsync(resto.Contrasenia, resto.Mail);
            if (log is null)
                return NotFound();
            return View(log);
        }
        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            Restaurante restaurante = await Ado.RestaurantePorIdAsync(id);
            if (restaurante is null)
            {
                return NotFound();
            }
            return View(restaurante);
        }

    }
}
