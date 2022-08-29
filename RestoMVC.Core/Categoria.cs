using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoMVC.Core
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
        public Categoria(){}

        public Categoria(string razonSocial) => razonSocial = RazonSocial;
        public Categoria(int cuit) => cuit = Cuit;
        


    }
}