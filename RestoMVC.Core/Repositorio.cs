using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoMVC.Core
{
    public class Repositorio
    {
         static int idCategoria = 1;
        static int idPlato = 1;
        static readonly List<Categoria> categorias = new List<Categoria>();
        public static IEnumerable<Categoria> Categorias
            => categorias;
        public static Categoria GetCategoria(int id)
            => categorias.Find(c => c.Id == id);
        public static void AgregarCategoria(Categoria categoria)
        {
            categoria.Id = idCategoria++;
            categorias.Add(categoria);
        }

        public static void EliminarCategoria(Categoria categoria)
            => categorias.RemoveAll(c => c.Id == categoria.Id);
        public static void ActualizarCategoria(Categoria categoria)
        {
            var indice = categorias.FindIndex(c => c.Id == categoria.Id);
            if (indice!=-1)
            {
                categorias[indice] = categoria;
            }            
        }
        public static void AgregarPlato(Plato plato)
        {
            plato.Id = idPlato++;
        }
        public static IEnumerable<Plato> platos
            => categorias.SelectMany(c => c.Platos);
        public static IEnumerable<Plato> ProductosDe(int idCategoria)
        {
            var categoria = GetCategoria(idCategoria);
            if (categoria is null)
            {
                return null;
            }
            return categoria.Platos;
        }
        public static Plato GetPlato(int id)
            => platos.First(p => p.Id == id);
        public static IEnumerable<PrecioHistorico> GetPreciosDe(int id)
            => GetProducto(id).Precios;
        public static void EliminarPlato(Plato plato)
        {
            var categoria = categorias.Find(c => c.Platos.Exists(p => p.Id==plato.Id));
            categoria.Platos.RemoveAll(p => p.Id == plato.Id);
        }
    }
}
    
