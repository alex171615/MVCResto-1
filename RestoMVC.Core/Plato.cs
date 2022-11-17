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

        public Plato () {}

        public Plato (int id ) => Id = id;
        public Plato (string nombre) => Nombre = nombre;
        public List<Plato> Platos { get; set; }
        public Plato (string nombre, string direccion, string mail, int telefono, string contrasenia) : this()
        
    {
        Id = Id;
        categoria = categoria;
        restaurante = restaurante;
        Nombre = nombre;
        Precio = Precio;
    }
    public void AgregarPlato(Plato plato) => Platos.Add(plato);

        
    }
}