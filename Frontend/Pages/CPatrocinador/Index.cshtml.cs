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
    public class IndexModel : PageModel
    {
        //Crear un objeto para poder utilizar a IRepositorioPatrocinador
        private readonly IRepositorioPatrocinador _repomuni;
        //Crear propiedad para el objeto transportado
        public IEnumerable <Patrocinador> Patrocinadores{get;set;}

        //Constructor de la clase
        public IndexModel(IRepositorioPatrocinador repomuni)
        {
            this._repomuni=repomuni;
        }

        public void OnGet()
        {
            Patrocinadores=_repomuni.ListarPatrocinadores();
        }
    }
}
