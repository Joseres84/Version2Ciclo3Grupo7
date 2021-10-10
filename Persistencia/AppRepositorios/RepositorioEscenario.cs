using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioEscenario(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Escenario
        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado=false;
            bool existe=ValidarNombre(escenario);
            if(!existe)
            {
                try
                {
                    _appContext.Escenarios.Add(escenario);
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
        //Método buscar Escenario
        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            /*var escenario=_appContext.Escenarios.Find(idEscenario);
            return escenario;*/
            return _appContext.Escenarios.Find(idEscenario);
        }
        //Método Eliminar Escenario
        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado= false;
            var escenario=_appContext.Escenarios.Find(idEscenario);
            if(escenario!=null)
            {
                try
                {
                     _appContext.Escenarios.Remove(escenario);
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
         //Método Actualizar Escenario      
        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado= false;
            var esc=_appContext.Escenarios.Find(escenario.Id);
            if(esc!=null)
            {
                try
                {
                     esc.Nombre=escenario.Nombre;
                     esc.Telefono=escenario.Telefono;
                     esc.Direccion=escenario.Direccion;
                     esc.Barrio=escenario.Barrio;
                     esc.NombreAdmin=escenario.NombreAdmin;
                     esc.TipoEscenario=escenario.TipoEscenario;
                     esc.Medidas=escenario.Medidas;
                     esc.CapacidadAforo=escenario.CapacidadAforo;
                     esc.Estado=escenario.TipoEscenario;
                     esc.TipoUso=escenario.TipoUso;             
                     esc.TorneoId=escenario.TorneoId;                        

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
        //Método Listar Escenario
        IEnumerable <Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _appContext.Escenarios;
        }
        
        //Método que verifica la existencia de un Nombre antes de guardarlo
        bool ValidarNombre(Escenario escenario)
        {
            bool existe=false;
            var esc = _appContext.Escenarios.FirstOrDefault(e=>e.Nombre==escenario.Nombre);
            if (esc!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

