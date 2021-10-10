using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioJuego:IRepositorioJuego
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioJuego(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Juego (a revisar)
        bool IRepositorioJuego.CrearJuego(Juego juego)
        {
            bool creado=false;
            try
            {
                _appContext.Juegos.Add(juego);
                _appContext.SaveChanges();
                creado= true;                    
            }
            catch (System.Exception)
            {
                //Console.WriteLine(e.ToString());
                return creado;               
            }
            return creado;
        }
        //Método buscar Juego       
        Juego IRepositorioJuego.BuscarJuego(int idJuego)
        {
            /*var juego=_appContext.Juegos.Find(idJuego);
            return juego;*/
            return _appContext.Juegos.Find(idJuego);
        }
        //Método Eliminar Juego
        bool IRepositorioJuego.EliminarJuego(int idJuego)
        {
            bool eliminado= false;
            var juego=_appContext.Juegos.Find(idJuego);
            if(juego!=null)
            {
                try
                {
                     _appContext.Juegos.Remove(juego);
                     _appContext.SaveChanges();
                     eliminado=true;
                }
                catch (System.Exception)
                {                    
                    return eliminado;
                }
            }
            return eliminado;
        }
         //Método Actualizar Juego    
        bool IRepositorioJuego.ActualizarJuego(Juego juego)
        {
            bool actualizado= false;
            var jue=_appContext.Juegos.Find(juego.Id);
            if(jue!=null)
            {
                try
                {
                    jue.FechaJuego=juego.FechaJuego;      
                    jue.HoraInicio=juego.HoraInicio;      
                    jue.HoraFin=juego.HoraFin;  
                    jue.Deporte=juego.Deporte; 
                    jue.TorneoId=juego.TorneoId;                                          

                    _appContext.SaveChanges();
                    actualizado=true;
                }
                catch (System.Exception)
                {                    
                    return actualizado;
                }
            }
            return actualizado;
        }
        //Método Listar Juego
        IEnumerable <Juego> IRepositorioJuego.ListarJuegos()
        {
            return _appContext.Juegos;
        }
    
    }

}

