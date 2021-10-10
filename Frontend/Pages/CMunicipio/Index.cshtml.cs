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
    public class IndexModel : PageModel
    {
        //Crear un objeto para poder utilizar a IRepositorioMunicipio
        private readonly IRepositorioMunicipio _repomuni;
        //Crear propiedad para el objeto transportado
        public IEnumerable<Municipio> Municipios{get;set;}

        //Constructor de la clase

        public IndexModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni=repomuni;
        }
        public void OnGet()
        {
            Municipios=_repomuni.ListarMunicipios();
        }
    }
}
