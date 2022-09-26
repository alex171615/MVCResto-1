using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers;
public class RestauranteController : Controller
{
    [HttpGet]
    public IActionResult Index()
        => View(Restaurante.Restaurantes);

    [HttpGet]
    public IActionResult Detalle(int id)
    {
        var restaurante = Restaurante.GetRestaurante(id);
        if (restaurante is null)
        {
            return NotFound();
        }
        return View(restaurante);
    }

    [HttpGet]
    public IActionResult FormAlta() => View();

    [HttpPost]
    public IActionResult FormAlta(Restaurante restaurante)
    {
       Restaurante.AgregarRestaurante(restaurante);
       return View("Index", Restaurante.Restaurantes);
    }

    [HttpPost]
    public IActionResult Eliminar(int id)
    {
        var restaurante = Restaurante.GetRestaurante(id);
        if (restaurante is null)
        {
            return NotFound();
        }
        Restaurante.EliminarRestaurante(restaurante);
        return View("Index", Restaurante.Restaurantes);
    }
}