using System.Collections.Generic;
using RestoMVC.Core;


namespace RestoMVC.Core
{
    public interface IAdo
    {
        void AltaRestaurante(Restaurante restaurante);
        List<Restaurante> ObtenerRestaurante();
        
    }
}