using System.Collections.Generic;
using RestoMVC.Core;


namespace Software.Core
{
    public interface IAdo
    {
        void AltaRestaurante(Restaurante restaurante);
        List<Restaurante> ObtenerRestaurante();
        
    }
}