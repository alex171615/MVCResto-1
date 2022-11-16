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
        public MapPlato MapPlato { get; set; }
        public AdoRestoMVC(AdoAGBD ado)
        {
            Ado = ado;
            MapRestaurante = new MapRestaurante(Ado);
            MapPlato = new MapPlato(Ado);
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

        public async Task<Restaurante?> restoPorPassAsync(string contrasenia, string mail)
        {
            return await MapRestaurante.restoPorPassAsync(contrasenia, mail);
        }

        //Todo lo plato

        public async Task AltaPlatoAsync(Plato plato) => await MapPlato.AltaPlatoAsync(plato);

        public async Task<List<Plato>> ObtenerPlatoAsync() => await MapPlato.ObtenerPlatoAsync();

        public async Task<Plato> PlatoAsync(int id) => await MapPlato.PlatoPorIdAsync(id);

        public async Task EliminarPlatoAsync(Plato plato) => await MapPlato.EliminarPlatoAsync(plato);

        public async Task ActualizarPlatoAsync(Plato plato) => await MapPlato.ActualizarPlatoAsync(plato);

        public async Task<Plato> PlatoPorIdAsync(int id)
        {
            return await MapPlato.PlatoPorIdAsync(id);
        }
    }
}