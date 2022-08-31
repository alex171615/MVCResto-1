using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using RestoMVC.Core;
using RestoMVC.Core.AdoET12;


namespace RestoMVC.Core.AdoET12.Mapeadores
{
    public class MapPlato : Mapeador<Plato>
    {
        public MapPlato(AdoAGBD ado) : base(ado)
        {
            Tabla = "Plato";
        }
        public override Plato ObjetoDesdeFila(DataRow fila)
        => new Plato()
        {
            Id = Convert.ToInt32(fila["id"]),
            Nombre = fila["nombre"].ToString()

        };
        public void AltaPlato(Plato plato)
            => EjecutarComandoCon("altaRestaurante", ConfigurarAltaPlato, plato);

        public void ConfigurarAltaPlato(Plato plato)
        {
            SetComandoSP("altaRestaurante");

            BP.CrearParametro("Id")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                    .SetValor(restaurante.Id)
                    .AgregarParametro();

            BP.CrearParametro("Nombre")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Nombre)
                    .AgregarParametro();
        }

        public Restaurante RestaurantePorId(int Id)
        {
            SetComandoSP("RestaurantePorId");

            BP.CrearParametro("unId")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id)
                .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Restaurante> ObtenerRestaurante() => ColeccionDesdeTabla();
    }

}