﻿using System;
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

        


        



        
    }

}