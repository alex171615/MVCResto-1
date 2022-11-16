using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using RestoMVC.Core;

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
            Id = Convert.ToInt32(fila["idRestaurante"]),
            Nombre = fila["nombre"].ToString(),
            Direccion = fila["direccion"].ToString(),
            Mail = fila["mail"].ToString(),
            Telefono = Convert.ToInt32(fila["telefono"]),
            Contrasenia = fila["contrasenia"].ToString()
        };
        public async Task AltaRestauranteAsync(Restaurante restaurante)
            => await EjecutarComandoAsync("altaRestaurante", ConfigurarAltaRestaurante, PostAltaRestaurante, restaurante);

        public void ConfigurarAltaRestaurante(Restaurante restaurante)
        {
            SetComandoSP("altaRestaurante");

            BP.CrearParametroSalida("unidRestaurante")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(restaurante.Id)
                    .AgregarParametro();

            BP.CrearParametro("unNombre")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Nombre)
                    .AgregarParametro();

            BP.CrearParametro("unaDireccion")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Direccion)
                    .AgregarParametro();

            BP.CrearParametro("unMail")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Mail)
                    .AgregarParametro();

            BP.CrearParametro("unTelefono")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(restaurante.Telefono)
                    .AgregarParametro();

            BP.CrearParametro("unaContrasenia")
                    .SetTipoVarchar(64)
                    .SetValor(restaurante.Contrasenia)
                    .AgregarParametro();

        }
        public void ConfigurarBajaRestaurante(Restaurante restaurante)
        {
            SetComandoSP("eliminarRestaurante");

            BP.CrearParametro("unidRestaurante")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(restaurante.Id)
                    .AgregarParametro();

        }
        public void ConfigurarActualizacionRestaurante(Restaurante restaurante)
        {
            SetComandoSP("actualizarRestaurante");

            BP.CrearParametro("unidRestaurante")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(restaurante.Id)
                    .AgregarParametro();

            BP.CrearParametro("unNombre")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Nombre)
                    .AgregarParametro();

            BP.CrearParametro("unaDireccion")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Direccion)
                    .AgregarParametro();

            BP.CrearParametro("unMail")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Mail)
                    .AgregarParametro();

            BP.CrearParametro("unTelefono")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
                    .SetValor(restaurante.Telefono)
                    .AgregarParametro();

            BP.CrearParametro("unaContrasenia")
                    .SetTipoVarchar(64)
                    .SetValor(restaurante.Contrasenia)
                    .AgregarParametro();
        }
        public async Task EliminarRestauranteAsync(Restaurante restaurante)
            => await EjecutarComandoAsync("eliminarRestaurante", ConfigurarBajaRestaurante, restaurante);
        public async Task ActualizarRestauranteAsync(Restaurante restaurante)
            => await EjecutarComandoAsync("actualizarRestaurante", ConfigurarActualizacionRestaurante, restaurante);

        public async Task<Restaurante> RestaurantePorIdAsync(int? Id)
        {
            SetComandoSP("RestaurantePorId");

            BP.CrearParametro("unidRestaurante")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id.Value)
                .AgregarParametro();
            return await ElementoDesdeSPAsync();
        }

        public async Task<Restaurante?> restoPorPassAsync(string? Mail, string? Contrasenia)

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
            Restaurante? resto;
            try
            {
                resto = ElementoDesdeSP();
            }
            catch (ArgumentOutOfRangeException)
            {
                resto = null;
            }

            return await ElementoDesdeSPAsync();

        }
        public void PostAltaRestaurante(Restaurante restaurante)
        {
            var paramIdRestaurante = GetParametro("unidRestaurante");
            restaurante.Id = Convert.ToInt32(paramIdRestaurante.Value);
        }
        public async Task<List<Restaurante>> ObtenerRestauranteAsync() => await ColeccionDesdeTablaAsync();


    }



}