using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CMunicipio
{
    public class DeleteModel : PageModel
    {
        //Crear un objeto para utilizar los repositorios
        private readonly IRepositorioMunicipio _repomuni;
        //Contructor
        public DeleteModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni=repomuni;
        }
        //Propiedad transportable
        [BindProperty]
        public Municipio objMunicipio{get;set;}

        public ActionResult OnGet(int id)
        {
            objMunicipio=_repomuni.BuscarMunicipio(id);
            if(objMunicipio!=null)
            {
                ViewData["Mensaje"]="¿Está seguro que desea eliminar el registro?";
                return Page();
            }
             
            return RedirectToPage("./Index");
        }
        public ActionResult OnPost()
        {
            bool funciono=_repomuni.EliminarMunicipio(objMunicipio.Id);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El Municipio no se puede eliminar";
                return Page();
            }
        }
        

    }
}
