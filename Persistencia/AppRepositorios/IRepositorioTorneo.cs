using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneo
    {
        //Firmar los métodos
        bool CrearTorneo(Torneo torneo);
        Torneo BuscarTorneo(int idTorneo);
        bool EliminarTorneo(int idTorneo);
        bool ActualizarTorneo(Torneo torneo);
        IEnumerable <Torneo> ListarTorneos();
    }
}