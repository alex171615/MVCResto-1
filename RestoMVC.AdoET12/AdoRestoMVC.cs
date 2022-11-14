using System.Collections.Generic;
using RestoMVC.Core.AdoET12.Mapeadores;
using RestoMVC.AdoET12;
using RestoMVC.Core;
using et12.edu.ar.AGBD.Ado;

namespace RestoMVC.AdoET12
{
    public class AdoRestoMVC : IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapRestaurante MapRestaurante { get; set; }
        public AdoRestoMVC(AdoAGBD ado)
        {
            Ado = ado;
            MapRestaurante = new MapRestaurante(Ado);
        }
        public async Task AltaRestauranteAsync(Restaurante restaurante) => await MapRestaurante.AltaRestauranteAsync(restaurante);

        public async Task<List<Restaurante>> ObtenerRestauranteAsync() => await MapRestaurante.ObtenerRestauranteAsync();

        public async Task<Restaurante> RestaurantePoridAsync(int id) => await MapRestaurante.RestaurantePorIdAsync(id);

        public async Task EliminarRestauranteAsync(Restaurante restaurante) => await MapRestaurante.EliminarRestauranteAsync(restaurante);

        public async Task ActualizarRestauranteAsync(Restaurante restaurante) => await MapRestaurante.ActualizarRestauranteAsync(restaurante);

        public async Task<Restaurante> RestaurantePorIdAsync(int id)
        {
            return await MapRestaurante.RestaurantePorIdAsync(id);
        }

        public async Task<Restaurante> restoPorPassAsync(string contrasenia, string mail)
        {
            return await MapRestaurante.restoPorPassAsync(contrasenia, mail);
        }
    }
}