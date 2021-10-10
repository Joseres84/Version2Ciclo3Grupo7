using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneoEquipo
    {
        //Firmar los métodos
        bool CrearTorneoEquipo(TorneoEquipo torneoequipo);
        TorneoEquipo BuscarTorneoEquipo(int idTorneoEquipo);
        bool EliminarTorneoEquipo(int idTorneoEquipo);
        bool ActualizarTorneoEquipo(TorneoEquipo torneoequipo);
        IEnumerable <TorneoEquipo> ListarTorneosEquipos();
    }
}