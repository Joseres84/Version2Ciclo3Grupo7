using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioJuego
    {
        //Firmar los métodos
        bool CrearJuego(Juego juego);
        Juego BuscarJuego(int idJuego);
        bool EliminarJuego(int idJuego);
        bool ActualizarJuego(Juego juego);
        IEnumerable <Juego> ListarJuegos();       
    }
}