using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioDeportista:IRepositorioDeportista
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioDeportista(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Deportista
        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            bool creado=false;
            bool existe=ValidarDocumento(deportista);
            if(!existe)
            {
                try
                {
                    _appContext.Deportistas.Add(deportista);
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
        //Método buscar Deportista        
        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            /*var Deportista=_appContext.Deportistas.Find(idDeportista);
            return deportista;*/
            return _appContext.Deportistas.Find(idDeportista);
        }
        //Método Eliminar Deportista
        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            bool eliminado= false;
            var deportista=_appContext.Deportistas.Find(idDeportista);
            if(deportista!=null)
            {
                try
                {
                     _appContext.Deportistas.Remove(deportista);
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
         //Método Actualizar Deportista      
        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado= false;
            var dep=_appContext.Deportistas.Find(deportista.Id);
            if(dep!=null)
            {
                try
                {
                    dep.Documento=deportista.Documento;
                    dep.Nombres=deportista.Nombres;
                    dep.Apellidos=deportista.Apellidos;                    
                    dep.Direccion=deportista.Direccion;
                    dep.Telefono=deportista.Telefono;
                    dep.Email=deportista.Email;                    
                    dep.Rh=deportista.Rh;
                    dep.FechaNacimiento=deportista.FechaNacimiento;
                    dep.Genero=deportista.Genero;  
                    dep.EquipoId=deportista.EquipoId;                         

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
        //Método Listar Deportistas 
        IEnumerable <Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _appContext.Deportistas;
        }
        
        //Método que verifica la existencia de un Documento antes de guardarlo
        bool ValidarDocumento(Deportista deportista)
        {
            bool existe=false;
            var dep = _appContext.Deportistas.FirstOrDefault(d=>d.Documento==deportista.Documento);
            if (dep!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

