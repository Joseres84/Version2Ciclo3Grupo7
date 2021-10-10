using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioTorneo:IRepositorioTorneo
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioTorneo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Torneo
        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)
        {
            bool creado=false;
            bool existe=ValidarNombre(torneo);
            if(!existe)
            {
                try
                {
                    _appContext.Torneos.Add(torneo);
                    _appContext.SaveChanges();
                    creado= true;
                    
                }
                catch (System.Exception)
                {
                    //Console.WriteLine(e.ToString());
                    return creado;               
                }
            }            
            return creado;
        }
        //Método buscar Torneo        
        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            /*var torneo=_appContext.Torneos.Find(idTorneo);
            return torneo;*/
            return _appContext.Torneos.Find(idTorneo);
        }
        //Método Eliminar Torneo
        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado= false;
            var torneo=_appContext.Torneos.Find(idTorneo);
            if(torneo!=null)
            {
                try
                {
                     _appContext.Torneos.Remove(torneo);
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
         //Método Actualizar Torneo     
        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado= false;
            var tor=_appContext.Torneos.Find(torneo.Id);
            if(tor!=null)
            {
                try
                {
                     tor.Nombre=torneo.Nombre;
                     tor.Categoria=torneo.Categoria;
                     tor.FechaIni=torneo.FechaIni;
                     tor.FechaFin=torneo.FechaFin;
                     tor.MunicipioId=torneo.MunicipioId;

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
        //Método Listar Torneo
        IEnumerable <Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.Torneos;
        }
        
        //Método que verifica la existencia de un Nombre antes de guardarlo
        bool ValidarNombre(Torneo torneo)
        {
            bool existe=false;
            var tor = _appContext.Torneos.FirstOrDefault(t=>t.Nombre==torneo.Nombre);
            if (tor!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}