using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioColegioArbitral:IRepositorioColegioArbitral
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioColegioArbitral(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear ColegioArbitral
        bool IRepositorioColegioArbitral.CrearColegioArbitral(ColegioArbitral colegioarbitral)
        {
            bool creado=false;
            bool existe=ValidarNit(colegioarbitral);
            if(!existe)
            {
                try
                {
                    _appContext.ColegiosArbitrales.Add(colegioarbitral);
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
        //Método buscar ColegioArbitral        
        ColegioArbitral IRepositorioColegioArbitral.BuscarColegioArbitral(int idColegioArbitral)
        {
            /*var colegioArbitral=_appContext.ColegiosArbitrales.Find(idColegioArbitral);
            return colegioarbitral;*/
            return _appContext.ColegiosArbitrales.Find(idColegioArbitral);
        }
        //Método Eliminar ColegioArbitral
        bool IRepositorioColegioArbitral.EliminarColegioArbitral(int idColegioArbitral)
        {
            bool eliminado= false;
            var colegioarbitral=_appContext.ColegiosArbitrales.Find(idColegioArbitral);
            if(colegioarbitral!=null)
            {
                try
                {
                     _appContext.ColegiosArbitrales.Remove(colegioarbitral);
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
         //Método Actualizar ColegioArbitral      
        bool IRepositorioColegioArbitral.ActualizarColegioArbitral(ColegioArbitral colegioarbitral)
        {
            bool actualizado= false;
            var col=_appContext.ColegiosArbitrales.Find(colegioarbitral.Id);
            if(col!=null)
            {
                try
                {
                    col.Nit=colegioarbitral.Nit;
                    col.Nombre=colegioarbitral.Nombre;
                    col.Resolucion=colegioarbitral.Resolucion;
                    col.Telefono=colegioarbitral.Telefono;
                    col.Direccion=colegioarbitral.Direccion;    
                    col.Email=colegioarbitral.Email;                                                     
                    
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
        //Método Listar ColegioArbitral 
        IEnumerable <ColegioArbitral> IRepositorioColegioArbitral.ListarColegiosArbitrales()
        {
            return _appContext.ColegiosArbitrales;
        }
        
        //Método que verifica la existencia de un NIT antes de guardarlo
        bool ValidarNit(ColegioArbitral colegioarbitral)
        {
            bool existe=false;
            var col = _appContext.ColegiosArbitrales.FirstOrDefault(c=>c.Nit==colegioarbitral.Nit);
            if (col!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

