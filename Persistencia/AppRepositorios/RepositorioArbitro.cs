using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioArbitro:IRepositorioArbitro
    {
        // Atributos
        private readonly AppContext _appContext;
        //Métodos
        //Constructor por defecto
        public RepositorioArbitro(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Método crear Arbitro
        bool IRepositorioArbitro.CrearArbitro(Arbitro arbitro)
        {
            bool creado=false;
            bool existe=ValidarDocumento(arbitro);
            if(!existe)
            {
                try
                {
                    _appContext.Arbitros.Add(arbitro);
                    
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

        //Método buscar Arbitro        
        Arbitro IRepositorioArbitro.BuscarArbitro(int idArbitro)
        {
            /*var arbitro=_appContext.Arbitros.Find(idArbitro);
            return arbitro;*/
            return _appContext.Arbitros.Find(idArbitro);
        }
        //Método Eliminar Arbitro
        bool IRepositorioArbitro.EliminarArbitro(int idArbitro)
        {
            bool eliminado= false;
            var arbitro=_appContext.Arbitros.Find(idArbitro);
            if(arbitro!=null)
            {
                try
                {
                     _appContext.Arbitros.Remove(arbitro);
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
         //Método Actualizar Arbitro      
        bool IRepositorioArbitro.ActualizarArbitro(Arbitro arbitro)
        {
            bool actualizado= false;
            var arb=_appContext.Arbitros.Find(arbitro.Id);
            if(arb!=null)
            {
                try
                {
                    arb.Documento=arbitro.Documento;
                    arb.Nombres=arbitro.Nombres;
                    arb.Apellidos=arbitro.Apellidos;
                    arb.Genero=arbitro.Genero;
                    arb.Telefono=arbitro.Telefono;
                    arb.Email=arbitro.Email;                    
                    arb.Deporte=arbitro.Deporte;
                    arb.TorneoId=arbitro.TorneoId;                                                               
                    arb.ColegioArbitralId=arbitro.ColegioArbitralId;                       

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
        //Método Listar Arbitro         
        IEnumerable <Arbitro> IRepositorioArbitro.ListarArbitros()
        {
            return _appContext.Arbitros;
        }
        
        //Método que verifica la existencia de un documento antes de guardarlo
        bool ValidarDocumento(Arbitro arbitro)
        {
            bool existe=false;
            var arb = _appContext.Arbitros.FirstOrDefault(a=>a.Documento==arbitro.Documento);
            if (arb!=null)
            {
                existe=true;
            }
            return existe;
        }
    
    }

}

