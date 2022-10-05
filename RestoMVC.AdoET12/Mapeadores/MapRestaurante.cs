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
            Nombre = fila["nombre"].ToString(),
            Direccion = fila["direccion"].ToString(),
            Mail = fila["mail"].ToString(),
            Telefono = Convert.ToInt32(fila["telefono"]),
            Contrasenia = fila["contrasenia"].ToString()
        };
        public void AltaRestaurante(Restaurante restaurante)
            => EjecutarComandoCon("altaRestaurante", ConfigurarAltaRestaurante,PostAltaRestaurante, restaurante);

        private void ConfigurarAltaRestaurante(Restaurante restaurante)
        {
            SetComandoSP("altaRestaurante");

            BP.CrearParametro("unidRestaurante")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                    .SetValor(restaurante.Id)
                    .AgregarParametro();

            BP.CrearParametro("unnombre")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Nombre)
                    .AgregarParametro();

            BP.CrearParametro("unadireccion")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Direccion)
                    .AgregarParametro();

            BP.CrearParametro("unmail")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Mail)
                    .AgregarParametro();

            BP.CrearParametro("untelefono")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                    .SetValor(restaurante.Telefono)
                    .AgregarParametro();

            BP.CrearParametro("unacontrasenia")
                    .SetTipoVarchar(64)
                    .SetValor(restaurante.Contrasenia)
                    .AgregarParametro();

        }

        private Restaurante RestaurantePorId(int Id)
        {
            SetComandoSP("RestaurantePorId");

            BP.CrearParametro("unidRestaurante")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id)
                .AgregarParametro();

            return ElementoDesdeSP();
        }
        private Restaurante restoPorPass(string Mail ,string Contrasenia)
        {
            SetComandoSP("restoPorPass");

            BP.CrearParametro("unMail")
                .SetTipoVarchar(45)
                .SetValor(Mail)
                .AgregarParametro();
            
            BP.CrearParametro("unaContrasenia")
                .SetTipoVarchar(64)
                .SetValor(Contrasenia)
                .AgregarParametro();

            return ElementoDesdeSP();

        }
        private void PostAltaRestaurante(Restaurante restaurante)
        {
            var paramIdRestaurante = GetParametro("unidRestaurante");
            restaurante.Id = Convert.ToUInt16(paramIdRestaurante.Value);
        }
        public List<Restaurante> ObtenerRestaurante() => ColeccionDesdeTabla();
    }

}