using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoMVC.Core
{
    public class Restaurante 
    {
        public int Id {get; set;}

        public string Nombre {get; set;}

        public string Direccion {get; set;}

        public string Mail {get; set;}

        public int Telefono {get; set;}

        public string Contrasenia {get; set;}
        public List<Plato> Platos {get; set;}
        public Restaurante () {
            Platos = new List<Plato>();
        }

        public Restaurante (int id) => Id = id;

        public Restaurante (string nombre) => Nombre = nombre;
        static int idRestaurante = 1;
        
        static readonly List<Restaurante> restaurantes = new List<Restaurante>();
        public static IEnumerable<Restaurante> Restaurantes 
            => restaurantes;
        public static Restaurante GetRestaurante(int id)
            => restaurantes.Find(r => r.Id == id);
        public static void AgregarRestaurante(Restaurante restaurante)
        {
            restaurante.Id = idRestaurante++;
            restaurantes.Add(restaurante);
        }

        public static void EliminarRestaurante(Restaurante restaurante)
            => restaurantes.RemoveAll(r => r.Id == restaurante.Id);
        public static void ActualizarRestaurante(Restaurante restaurante)
        {
            var indice = restaurantes.FindIndex(r => r.Id == restaurante.Id);
            if (indice!=-1)
            {
                restaurantes[indice] = restaurante;
            }            
        }
    }

}