using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEquipo
    {
        //Firmar los métodos
        bool CrearEquipo(Equipo equipo);
        Equipo BuscarEquipo(int idEquipo);
        bool EliminarEquipo(int idEquipo);
        bool ActualizarEquipo(Equipo equipo);
        IEnumerable <Equipo> ListarEquipos();       
    }
}