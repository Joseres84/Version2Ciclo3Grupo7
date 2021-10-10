using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioEntrenador:IRepositorioEntrenador
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioEntrenador(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Entrenador
        bool IRepositorioEntrenador.CrearEntrenador(Entrenador entrenador)
        {
            bool creado=false;
            bool existe=ValidarDocumento(entrenador);
            if(!existe)
            {
                try
                {
                    _appContext.Entrenadores.Add(entrenador);
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
        //Método buscar Entrenador        
       Entrenador IRepositorioEntrenador.BuscarEntrenador(int idEntrenador)
        {
            /*var entrenador=_appContext.Entrenadores.Find(idEntrenador);
            return entrenador;*/
            return _appContext.Entrenadores.Find(idEntrenador);
        }
        //Método Eliminar Entrenador
        bool IRepositorioEntrenador.EliminarEntrenador(int idEntrenador)
        {
            bool eliminado= false;
            var entrenador=_appContext.Entrenadores.Find(idEntrenador);
            if(entrenador!=null)
            {
                try
                {
                     _appContext.Entrenadores.Remove(entrenador);
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
         //Método Actualizar Entrenador     
        bool IRepositorioEntrenador.ActualizarEntrenador(Entrenador entrenador)
        {
            bool actualizado= false;
            var ent=_appContext.Entrenadores.Find(entrenador.Id);
            if(ent!=null)
            {
                try
                {
                    ent.Documento=entrenador.Documento;
                    ent.Nombres=entrenador.Nombres;
                    ent.Apellidos=entrenador.Apellidos;
                    ent.Genero=entrenador.Genero;                      
                    ent.Telefono=entrenador.Telefono;
                    ent.Email=entrenador.Email;                
                    ent.EquipoId=entrenador.EquipoId;     

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
        //Método Listar Entrenador
        IEnumerable <Entrenador> IRepositorioEntrenador.ListarEntrenadores()
        {
            return _appContext.Entrenadores;
        }
        
        //Método que verifica la existencia de un Documento antes de guardarlo
        bool ValidarDocumento(Entrenador entrenador)
        {
            bool existe=false;
            var ent = _appContext.Entrenadores.FirstOrDefault(e=>e.Documento==entrenador.Documento);
            if (ent!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

