using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using RestoMVC.Core;
using RestoMVC.Core.AdoET12;

namespace RestoMVC.AdoET12.Mapeadores
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
        public void AltaCategoria(Categoria categoria)
            => EjecutarComandoCon("altaCategoria", ConfigurarAltaCategoria, PostAltaCategoria, categoria);

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

        public void PostAltaCategoria(Categoria categoria)
        {
            var paramIdCategoria = GetParametro("unIdCategoria");
            categoria.Id = Convert.ToByte(paramIdCategoria.Value);
        } 


        public Categoria CategoriaPorId(int Id)
        {
            SetComandoSP("RestaurantePorId");

            BP.CrearParametro("unId")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id)
                .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Categoria> ObtenerCategoria() => ColeccionDesdeTabla();
    }

}