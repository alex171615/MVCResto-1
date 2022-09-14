using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoMVC.Core
{
    public class Categoria
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public Categoria (string nombre) => Nombre = nombre;
        public List<Plato> Platos {get; set;}
        public Categoria (int id) => Id = id;
        public Categoria()
        {
            Platos = new List<Plato>();
        }
        public void AgregarProducto(Plato plato)
            => Platos.Add(plato);
        public void EliminarProducto(Plato plato)
            => Platos.Remove(plato);
    }
}