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
        public void AltaRestaurante(Restaurante restaurante) => MapRestaurante.AltaRestaurante(restaurante);

        public List<Restaurante> ObtenerRestaurante() => MapRestaurante.ObtenerRestaurante();

        public void EliminarRestaurante(Restaurante restaurante) => MapRestaurante.EliminarRestaurante(restaurante);

        public void ActualizarRestaurante(Restaurante restaurante) => MapRestaurante.ActualizarRestaurante(restaurante);
        
        public Restaurante RestaurantePorId(int id)
        {
            return MapRestaurante.RestaurantePorId(id);
        }

        public Restaurante restoPorPass(string contrasenia, string mail)
        {
            return MapRestaurante.restoPorPass(contrasenia , mail);
        }
    }
}