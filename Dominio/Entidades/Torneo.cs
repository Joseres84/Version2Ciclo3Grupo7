using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Torneo
    {
        public int Id {get; set;}
        public string Nombre {get;set;}
        public string Categoria {get;set;}
        public DateTime FechaIni {get;set;}
        public DateTime FechaFin {get;set;}
        //Llave foránea para la relación con la tabla Municipio
        public int MunicipioId {get;set;}
        //Propiedad navigacional hacia la tabla intermedia TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos {get;set;}
        //Propiedad navigacional hacia la tabla intermedia Escenario
        public List<Escenario> Escenarios {get;set;}
        //Propiedad navigacional hacia la tabla Juego
        public List<Juego> Juegos {get;set;}
        //Propiedad navigacional hacia la tabla Arbitro
        public List<Arbitro> Arbitros {get;set;}

    }
}