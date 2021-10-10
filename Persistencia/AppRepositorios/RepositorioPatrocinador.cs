using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioPatrocinador:IRepositorioPatrocinador
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioPatrocinador(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Patrocinador
        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado=false;
            bool existe=ValidarDocumento(patrocinador);
            if(!existe)
            {
                try
                {
                    _appContext.Patrocinadores.Add(patrocinador);
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
        //Método buscar Patrocinador        
        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            /*var patrocinador=_appContext.Patrocinadores.Find(idPatrocinador);
            return patrocinador;*/
            return _appContext.Patrocinadores.Find(idPatrocinador);
        }
        //Método Eliminar Patrocinador
        bool IRepositorioPatrocinador.EliminarPatrocinador(int idPatrocinador)
        {
            bool eliminado= false;
            var patrocinador=_appContext.Patrocinadores.Find(idPatrocinador);
            if(patrocinador!=null)
            {
                try
                {
                     _appContext.Patrocinadores.Remove(patrocinador);
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
         //Método Actualizar Patrocinador      
        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado= false;
            var pat=_appContext.Patrocinadores.Find(patrocinador.Id);
            if(pat!=null)
            {
                try
                {
                    pat.Documento=patrocinador.Documento;
                    pat.TipoPersona=patrocinador.TipoPersona;
                    pat.Nombre=patrocinador.Nombre;
                    pat.Telefono=patrocinador.Telefono;
                    pat.Direccion=patrocinador.Direccion;
                    pat.Email=patrocinador.Email;
                    
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
        //Método Listar Patrocinador
        IEnumerable <Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _appContext.Patrocinadores;
        }
        
        //Método que verifica la existencia de un Documento antes de guardarlo
        bool ValidarDocumento(Patrocinador patrocinador)
        {
            bool existe=false;
            var pat = _appContext.Patrocinadores.FirstOrDefault(p=>p.Documento==patrocinador.Documento);
            if (pat!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

