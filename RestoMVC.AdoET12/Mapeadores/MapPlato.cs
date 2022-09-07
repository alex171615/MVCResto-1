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
        public MapCategoria MapCategoria {get; set;}
        public MapRestaurante MapRestaurante {get; set;}
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





        public void AltaPlato(Plato plato)
            => EjecutarComandoCon("altaPlato", ConfigurarAltaPlato, plato);


        public void ConfigurarAltaPlato(Plato plato)
        {
            SetComandoSP("altaPlato");

            BP.CrearParametro("Id")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                    .SetValor(plato.Id)
                    .AgregarParametro();

            BP.CrearParametro("Nombre")
                    .SetTipoVarchar(45)
                    .SetValor(plato.Nombre)
                    .AgregarParametro();

            BP.CrearParametro("unIdCategoria")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .SetValor(plato.categoria.Id)
              .AgregarParametro();

            BP.CrearParametro("unIdRestaurante")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .SetValor(plato.restaurante.Id)
              .AgregarParametro();


            BP.CrearParametro("Precio")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .SetValor(plato.Precio)
              .AgregarParametro();  
            
        }





        public Plato PlatoPorId(int Id)
        {
            SetComandoSP("PlatoPorId");

            BP.CrearParametro("unId")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id)
                .AgregarParametro();

            return ElementoDesdeSP();
        }


        public List<Plato> ObtenerPlato() => ColeccionDesdeTabla();
    }

}