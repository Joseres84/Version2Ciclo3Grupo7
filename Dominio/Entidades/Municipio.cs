using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Municipio
    {
        public int Id {get; set;}
	    public string Nombre {get;set;}
	    //Propiedad navigacional hacia la tabla Torneo
	    public List<Torneo> Torneos {get;set;}

    }
}
