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
    public class DetailsModel : PageModel
    {
        //Crear un objeto para utilizar los repositorios
        private readonly IRepositorioMunicipio _repomuni;
        //Contructor
        public DetailsModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni=repomuni;
        }
        [BindProperty]
        public Municipio mun{get;set;}

        public ActionResult OnGet(int id)
        {
            mun=_repomuni.BuscarMunicipio(id);
            return Page();
        }
    }
}
