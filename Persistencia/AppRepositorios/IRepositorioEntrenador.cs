using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEntrenador
    {
        //Firmar los métodos
        bool CrearEntrenador(Entrenador entrenador);
        Entrenador BuscarEntrenador(int idEntrenador);
        bool EliminarEntrenador(int idEntrenador);
        bool ActualizarEntrenador(Entrenador entrenador);
        IEnumerable <Entrenador> ListarEntrenadores();       
    }
}