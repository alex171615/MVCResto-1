using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using RestoMVC.Core;
using RestoMVC.Core.AdoET12;

namespace RestoMVC.Core.AdoET12.Mapeadores
{
    public class MapCategoria : Mapeador<Categoria>
    {
        public MapCategoria(AdoAGBD ado) : base(ado)
        {
            Tabla = "Categoria";
        }
        public override Categoria ObjetoDesdeFila(DataRow fila)
        => new Categoria()
        {
            Id = Convert.ToInt32(fila["id"]),
            Nombre = fila["nombre"].ToString()
        };
        public async Task AltaCategoriaAsync(Categoria categoria)
            => await EjecutarComandoAsync("altaCategoria", ConfigurarAltaCategoria, PostAltaCategoria, categoria);

        public void ConfigurarAltaCategoria(Categoria categoria)
        {
            SetComandoSP("altaCategoria");

            BP.CrearParametroSalida("unIdCategoria")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("Nombre")
                    .SetTipoVarchar(45)
                    .SetValor(categoria.Nombre)
                    .AgregarParametro();
        }
        public void ConfigurarBajaCategoria(Categoria categoria)
        {
            SetComandoSP("eliminarCategoria");

            BP.CrearParametro("unidCategoria")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(categoria.Id)
                    .AgregarParametro();

        }
        public void ConfigurarActualizacionCategoria(Categoria categoria)
        {
            SetComandoSP("actualizarCategoria");

            BP.CrearParametro("unidCategoria")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(categoria.Id)
                    .AgregarParametro();

            BP.CrearParametro("unNombre")
                    .SetTipoVarchar(45)
                    .SetValor(categoria.Nombre)
                    .AgregarParametro();

        }
        public async Task EliminarCategoriaAsync(Categoria categoria)
            => await EjecutarComandoAsync("eliminarCateria", ConfigurarBajaCategoria, categoria);
        public async Task ActualizarCategoriaAsync(Categoria categoria)
            => await EjecutarComandoAsync("actualizarPlato", ConfigurarActualizacionCategoria, categoria);


        public void PostAltaCategoria(Categoria categoria)
        {
            var paramIdCategoria = GetParametro("unIdCategoria");
            categoria.Id = Convert.ToByte(paramIdCategoria.Value);
        }


        public async Task<Categoria> CategoriaPorIdAsync(int? Id)
        {
            SetComandoSP("CategoriaPorId");

            BP.CrearParametro("unidCategoria")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id.Value)
                .AgregarParametro();
            return await ElementoDesdeSPAsync();
        }
        public Categoria CategoriaPorId(int? Id)
        {
            SetComandoSP("CategoriaPorId");

            BP.CrearParametro("unidCategoria")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id.Value)
              .AgregarParametro();

            return ElementoDesdeSP();
        }
        public async Task<List<Categoria>> ObtenerCategoriaAsync() => await ColeccionDesdeTablaAsync();
    }

}