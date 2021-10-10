using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioTorneoEquipo:IRepositorioTorneoEquipo
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioTorneoEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear TorneoEquipo
        bool IRepositorioTorneoEquipo.CrearTorneoEquipo(TorneoEquipo torneoequipo)
        {
            bool creado=false;
            try
            {
                _appContext.TorneoEquipos.Add(torneoequipo);
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
        //Método buscar TorneoEquipo      
        TorneoEquipo IRepositorioTorneoEquipo.BuscarTorneoEquipo(int idTorneoEquipo)
        {
            /*var torneoequipo=_appContext.TorneoEquipos.Find(idTorneoEquipo);
            return torneoequipo;*/
            return _appContext.TorneoEquipos.Find(idTorneoEquipo);
        }
        //Método Eliminar TorneoEquipo
        bool IRepositorioTorneoEquipo.EliminarTorneoEquipo(int idTorneoEquipo)
        {
            bool eliminado= false;
            var torneoequipo=_appContext.TorneoEquipos.Find(idTorneoEquipo);
            if(torneoequipo!=null)
            {
                try
                {
                     _appContext.TorneoEquipos.Remove(torneoequipo);
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
         //Método Actualizar TorneoEquipo    
        bool IRepositorioTorneoEquipo.ActualizarTorneoEquipo(TorneoEquipo torneoequipo)
        {
            bool actualizado= false;
            var tore=_appContext.TorneoEquipos.Find(torneoequipo.TorneoId);
            if(tore!=null)
            {
                try
                {
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
        //Método Listar TorneoEquipo
        IEnumerable <TorneoEquipo> IRepositorioTorneoEquipo.ListarTorneosEquipos()
        {
            return _appContext.TorneoEquipos;
        }       
    
    }

}