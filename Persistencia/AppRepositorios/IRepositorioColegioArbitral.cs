using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioColegioArbitral
    {
        //Firmar los métodos
        bool CrearColegioArbitral(ColegioArbitral colegioarbitral);
        ColegioArbitral BuscarColegioArbitral(int idColegioArbitral);
        bool EliminarColegioArbitral(int idColegioArbitral);
        bool ActualizarColegioArbitral(ColegioArbitral colegioarbitral);
        IEnumerable <ColegioArbitral> ListarColegiosArbitrales();       
    }
}