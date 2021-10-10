using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioEquipo:IRepositorioEquipo
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Equipo
        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)
        {
            bool creado=false;
            bool existe=ValidarNombre(equipo);
            if(!existe)
            {
                try
                {
                    _appContext.Equipos.Add(equipo);
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
        //Método buscar Equipo        
        Equipo IRepositorioEquipo.BuscarEquipo(int idEquipo)
        {
            /*var equipo=_appContext.Equipos.Find(idEquipo);
            return equipo;*/
            return _appContext.Equipos.Find(idEquipo);
        }
        //Método Eliminar Equipo
        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            bool eliminado= false;
            var equipo=_appContext.Equipos.Find(idEquipo);
            if(equipo!=null)
            {
                try
                {
                     _appContext.Equipos.Remove(equipo);
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
         //Método Actualizar Equipo      
        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            bool actualizado= false;
            var equ=_appContext.Equipos.Find(equipo.Id);
            if(equ!=null)
            {
                try
                {
                    equ.Nombre=equipo.Nombre;
                    equ.Email=equipo.Email;
                    equ.Deporte=equipo.Deporte;
                    equ.FechaCreacion=equipo.FechaCreacion;
                    equ.PatrocinadorId=equipo.PatrocinadorId;   

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
        //Método Listar Equipo 
        IEnumerable <Equipo> IRepositorioEquipo.ListarEquipos()
        {
            return _appContext.Equipos;
        }
        
        //Método que verifica la existencia de un Nombre antes de guardarlo
        bool ValidarNombre(Equipo equipo)
        {
            bool existe=false;
            var equ = _appContext.Equipos.FirstOrDefault(e=>e.Nombre==equipo.Nombre);
            if (equ!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

