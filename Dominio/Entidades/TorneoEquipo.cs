using System;
using System.Collections.Generic;
namespace Dominio
{
    public class TorneoEquipo
    {
        //llave principal compuesta por los siguientes dos campos enteros:
        public int EquipoId {get;set;}
        public int TorneoId {get;set;}
        //Propiedad navigacional hacia la tabla Equipo
        public Equipo Equipo {get;set;}
        //Propiedad navigacional hacia la tabla Torneo
        public Torneo Torneo {get;set;}

    }
}