using Microsoft.AspNetCore.Mvc;
using RestoMVC.Core;

namespace RestoMVC.Mvc.Controllers;
public class RestauranteController : Controller
{
    [HttpGet]
    public IActionResult Index()
        => View(Repositorio.platos);

    [HttpGet]
    public IActionResult Detalle(int id)
    {
        var plato = Repositorio.GetCategoria(id);
        if (plato is null)
        {
            return NotFound();
        }
        return View(plato);
    }

    [HttpGet]
    public IActionResult FormAlta() => View();

    [HttpPost]
    public IActionResult FormAlta(Plato plato)
    {
       Repositorio.AgregarPlato(plato);
       return View("Index", Repositorio.platos);
    }

    [HttpPost]
    public IActionResult Eliminar(int id)
    {
        var plato = Repositorio.GetPlato(id);
        if (plato is null)
        {
            return NotFound();
        }
        Repositorio.EliminarPlato(plato);
        return View("Index", Repositorio.platos);
    }
}