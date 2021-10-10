using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioPatrocinador
    {
        //Firmar los métodos
        bool CrearPatrocinador(Patrocinador patrocinador);
        Patrocinador BuscarPatrocinador(int idPatrocinador);
        bool EliminarPatrocinador(int idPatrocinador);
        bool ActualizarPatrocinador(Patrocinador patrocinador);
        IEnumerable <Patrocinador> ListarPatrocinadores();
    }
}