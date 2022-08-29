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
        public Categoria (){List<Plato> platos = new List<Plato>();}

        public Categoria (string nombre) => Nombre = nombre;

        public Categoria (int id) => Id = id;
    }
}