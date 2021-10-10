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
    public class EditModel : PageModel
    {
        //Se crea el objeto para utilizar el repositorio
        private readonly IRepositorioMunicipio _repomuni;
        //Constructor
        public EditModel(IRepositorioMunicipio repomuni)
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
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }

        }
        public ActionResult OnPost()
        {
            bool funciono=_repomuni.ActualizarMunicipio(objMunicipio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El municipio ya existe";
                return Page();
            }
        }

    }
}
