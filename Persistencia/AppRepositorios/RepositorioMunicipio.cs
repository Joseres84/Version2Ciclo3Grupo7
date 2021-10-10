using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioMunicipio:IRepositorioMunicipio
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Municipio
        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool creado=false;
            bool existe=Validarnombre(municipio);
            if(!existe)
            {
                try
                {
                    _appContext.Municipios.Add(municipio);
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

        //Método buscar Municipio        
         Municipio IRepositorioMunicipio.BuscarMunicipio(int idMunicipio)
        {
            /*var municipio=_appContext.Municipios.Find(idMunicipio);
            return municipio;*/
            return _appContext.Municipios.Find(idMunicipio);
        }
        //Método Eliminar Municipio
        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado= false;
            var municipio=_appContext.Municipios.Find(idMunicipio);
            if(municipio!=null)
            {
                try
                {
                     _appContext.Municipios.Remove(municipio);
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
         //Método Actualizar Municipio       
        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio)
        {
            bool actualizado= false;
            var mun=_appContext.Municipios.Find(municipio.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=municipio.Nombre;
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
        IEnumerable <Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _appContext.Municipios;
        }
        
        //Método que verifica la existencia de un nombre antes de guardarlo
        bool Validarnombre(Municipio municipio)
        {
            bool existe=false;
            var mun = _appContext.Municipios.FirstOrDefault(m=>m.Nombre==municipio.Nombre);
            if (mun!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

