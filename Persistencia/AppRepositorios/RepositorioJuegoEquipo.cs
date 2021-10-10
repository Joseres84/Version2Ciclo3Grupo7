using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioJuegoEquipo:IRepositorioJuegoEquipo
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioJuegoEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }

 //Método crear JuegoEquipo (a revisar)
        bool IRepositorioJuegoEquipo.CrearJuegoEquipo(JuegoEquipo juegoequipo)
        {
            bool creado=false;
            try
            {
                _appContext.JuegoEquipos.Add(juegoequipo);
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
        //Método buscar JuegoEquipo        
        JuegoEquipo IRepositorioJuegoEquipo.BuscarJuegoEquipo(int idJuegoEquipo)
        {
            /*var juegoequipo=_appContext.JuegoEquipos.Find(idJuegoEquipo);
            return juegoequipo;*/
            return _appContext.JuegoEquipos.Find(idJuegoEquipo);
        }
        //Método Eliminar JuegoEquipo
        bool IRepositorioJuegoEquipo.EliminarJuegoEquipo(int idJuegoEquipo)
        {
            bool eliminado= false;
            var juegoequipo=_appContext.JuegoEquipos.Find(idJuegoEquipo);
            if(juegoequipo!=null)
            {
                try
                {
                     _appContext.JuegoEquipos.Remove(juegoequipo);
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
         //Método Actualizar JuegoEquipo  
        bool IRepositorioJuegoEquipo.ActualizarJuegoEquipo(JuegoEquipo juegoequipo)
        {
            bool actualizado= false;
            var juee=_appContext.JuegoEquipos.Find(juegoequipo.JuegoId);
            if(juee!=null)
            {
                try
                {
                    juee.Puntaje=juegoequipo.Puntaje;      
                                                                                                     
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
        //Método Listar JuegoEquipo
        IEnumerable <JuegoEquipo> IRepositorioJuegoEquipo.ListarJuegosEquipos()
        {
            return _appContext.JuegoEquipos;
        }       
    
    }

}
