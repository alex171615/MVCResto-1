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
        public MapCategoria MapCategoria { get; set; }
        public MapRestaurante MapRestaurante { get; set; }
        public MapPlato(AdoAGBD ado) : base(ado) => Tabla = "Plato";
        public MapPlato(MapCategoria mapCategoria) : this(mapCategoria.AdoAGBD)
        => MapCategoria = mapCategoria;
        public MapPlato(MapRestaurante mapRestaurante) : this(mapRestaurante.AdoAGBD)
        => MapRestaurante = mapRestaurante;





        public override Plato ObjetoDesdeFila(DataRow fila)
        => new Plato()
        {
            Id = Convert.ToInt32(fila["id"]),
            categoria = MapCategoria.CategoriaPorId(Convert.ToByte(fila["idRubro"])),
            Nombre = fila["nombre"].ToString(),
            Precio = Convert.ToDouble(fila["precio"])

        };


        public async Task AltaPlatoAsync(Plato plato)
            => await EjecutarComandoAsync("altaPlato", ConfigurarAltaPlato, PostAltaPlato, plato);

        public void ConfigurarAltaPlato(Plato plato)
        {
            SetComandoSP("altaRestaurante");

            BP.CrearParametroSalida("unidPlato")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(plato.Id)
                    .AgregarParametro();

            BP.CrearParametro("unNombre")
                    .SetTipoVarchar(45)
                    .SetValor(plato.Nombre)
                    .AgregarParametro();

            BP.CrearParametro("unPrecio")
                    .SetTipoVarchar(45)
                    .SetValor(plato.Precio)
                    .AgregarParametro();
        }
        public void ConfigurarBajaPlato(Plato plato)
        {
            SetComandoSP("eliminarPlato");

            BP.CrearParametro("unidPlato")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(plato.Id)
                    .AgregarParametro();

        }
        public void ConfigurarActualizacionPlato(Plato plato)
        {
            SetComandoSP("actualizarPlato");

            BP.CrearParametro("unidRestaurante")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(plato.Id)
                    .AgregarParametro();

            BP.CrearParametro("unNombre")
                    .SetTipoVarchar(45)
                    .SetValor(plato.Nombre)
                    .AgregarParametro();

            BP.CrearParametro("unPrecio")
                    .SetTipoVarchar(45)
                    .SetValor(plato.Precio)
                    .AgregarParametro();

        }
        public async Task EliminarPlatoAsync(Plato plato)
            => await EjecutarComandoAsync("eliminarPlato", ConfigurarBajaPlato, plato);
        public async Task ActualizarPlatoAsync(Plato plato)
            => await EjecutarComandoAsync("actualizarPlato", ConfigurarActualizacionPlato, plato);

        public async Task<Plato> PlatoPorIdAsync(int? Id)
        {
            SetComandoSP("PlatoPorId");

            BP.CrearParametro("unidPlato")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id.Value)
                .AgregarParametro();
            return await ElementoDesdeSPAsync();
        }


        public void PostAltaPlato(Plato plato)
        {
            var paramIdPlato = GetParametro("unidPlato");
            plato.Id = Convert.ToInt32(paramIdPlato.Value);
        }
        public async Task<List<Plato>> ObtenerPlatoAsync() => await ColeccionDesdeTablaAsync();

    }

}