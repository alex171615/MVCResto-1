using System.Collections.Generic;
using RestoMVC.Core;
using System.Threading.Tasks;
using System.Linq;

namespace RestoMVC.Core
{
    public interface IAdo
    {
        Task AltaRestauranteAsync(Restaurante restaurante);
        Task<List<Restaurante>> ObtenerRestauranteAsync();

        Task EliminarRestauranteAsync(Restaurante restaurante);
        Task ActualizarRestauranteAsync(Restaurante restaurante);
        Task<Restaurante> RestaurantePorIdAsync(int Id);

        Task<Restaurante> restoPorPassAsync(string contrasenia, string mail);

    }


}