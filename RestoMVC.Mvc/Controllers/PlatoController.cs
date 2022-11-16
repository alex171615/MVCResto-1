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
            var platos = await Ado.ObtenerPlatoAsync();
            return View("Listado", platos);
        }



        [HttpGet]
        public IActionResult AltaPlato()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AltaPlato(Plato plato)
        {
            await Ado.AltaPlatoAsync(plato);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> EliminarPlato(Plato plato)
        {
            plato = await Ado.PlatoPorIdAsync(plato.Id);
            if (plato is null)
            {
                return NotFound();
            }
            else
                await Ado.EliminarPlatoAsync(plato);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> ActualizarPlato(int id)
        {
            Plato platos = await Ado.PlatoPorIdAsync(id);
            if (platos is null)
            {
                return NotFound();
            }
            else
                return View(platos);
        }



        [HttpPost]
        public async Task<IActionResult> ActualizarPlatoAsync(Plato plato)
        {
            await Ado.ActualizarPlatoAsync(plato);
            await Ado.ActualizarPlatoAsync(plato);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            Plato plato = await Ado.PlatoPorIdAsync(id);
            if (plato is null)
            {
                return NotFound();
            }
            return View(plato);
        }

    }
}
