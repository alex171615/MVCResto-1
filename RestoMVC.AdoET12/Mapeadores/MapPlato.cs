using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using RestoMVC.Core;
using RestoMVC.Core.AdoET12;


namespace RestoMVC.Core.AdoET12.Mapeadores
{
    public class MapRestaurante : Mapeador<Restaurante>
    {
        public MapRestaurante(AdoAGBD ado) : base(ado)
        {
            Tabla = "Restaurante";
        }
        public override Restaurante ObjetoDesdeFila(DataRow fila)
        => new Restaurante()
        {
            Id = Convert.ToInt32(fila["id"]),
            Nombre = fila["nombre"].ToString()
        };
        public void AltaRestaurante(Restaurante restaurante)
            => EjecutarComandoCon("altaRestaurante", ConfigurarAltaRestaurante, restaurante);

        public void ConfigurarAltaRestaurante(Restaurante restaurante)
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