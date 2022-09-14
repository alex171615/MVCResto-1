using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoMVC.Core
{
    public class Plato
    {
        public int Id {get; set;}

        public Categoria categoria {get; set;}

        public Restaurante restaurante {get; set;}

        public string Nombre {get; set;}

        public double Precio {get; set;}

        public Plato () {List<Categoria> categorias = new List<Categoria>();}

        public List<
        
        public Plato (int id ) => Id = id;
        public Plato (string nombre) => Nombre = nombre;

        
    }
}