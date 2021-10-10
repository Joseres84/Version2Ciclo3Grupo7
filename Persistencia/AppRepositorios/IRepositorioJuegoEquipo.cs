using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioJuegoEquipo
    {
        //Firmar los métodos
        bool CrearJuegoEquipo(JuegoEquipo juegoequipo);
        JuegoEquipo BuscarJuegoEquipo(int idJuegoEquipo);
        bool EliminarJuegoEquipo(int idJuegoEquipo);
        bool ActualizarJuegoEquipo(JuegoEquipo juegoequipo);
        IEnumerable <JuegoEquipo> ListarJuegosEquipos();       
    }
}