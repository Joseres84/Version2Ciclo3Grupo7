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
    public class CreateModel : PageModel
    {
        //Crear el objeto para hacer uso del IRepositorioMunicipio
        private readonly IRepositorioMunicipio _repomuni;
        //Constructor
        public CreateModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni=repomuni;
        }
        //Crear propiedad transportable
        [BindProperty]
        public Municipio Municipio {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono=_repomuni.CrearMunicipio(Municipio);
            if(funciono)
            {
                return RedirectToPage("./Index");        
            }
            else
            {
                ViewData["Error"]="El municipio ingresado ya existe...";
                return Page();
            }
        }
    }
}
