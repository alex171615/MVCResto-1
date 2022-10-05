using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers;
public class RestauranteController : Controller
{
    private readonly IAdo Ado;
    public RestauranteController (IAdo ado) => Ado = ado;

    
    public IActionResult Index()
    {
        var restaurantes = Ado.ObtenerRestaurante();
        return View("Listado", restaurantes);
        }
    [HttpGet]
    public IActionResult AltaRestaurante () {
        return View();
    }
    public IActionResult AltaRestaurante(Restaurante restaurante)
    {
        Ado.AltaRestaurante(restaurante);
        return RedirectToAction(nameof(Index));
    }


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