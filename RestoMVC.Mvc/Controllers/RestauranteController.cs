using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers
{

    public class RestauranteController : Controller
    {
        private readonly IAdo Ado;
        public RestauranteController(IAdo ado) => Ado = ado;
        public async Task<IActionResult> Index()
        {
            var restaurantes = await Ado.ObtenerRestauranteAsync();
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
        public async Task<IActionResult> ActualizarRestaurante(Restaurante restaurante)
        {

            await Ado.ActualizarRestauranteAsync(restaurante);
            return RedirectToAction(nameof(Index));
        }

    }
}
