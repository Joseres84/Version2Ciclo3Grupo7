using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class CreateModel : PageModel
    {
        //Crear el objeto para hacer uso del IRepositorioPatrocinador
        private readonly IRepositorioPatrocinador _repomuni;
        //Constructor
        public CreateModel(IRepositorioPatrocinador repomuni)
        {
            this._repomuni=repomuni;
        }
        //Crear propiedad transportable
        [BindProperty]
        public Patrocinador Patrocinador {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono=_repomuni.CrearPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./Index");        
            }
            else
            {
                ViewData["Error"]="El patrocinador ingresado ya existe...";
                return Page();
            }
        }
    }
}
