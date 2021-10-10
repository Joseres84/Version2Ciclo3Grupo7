using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Equipo
    {
        public int Id {get;set;}
        public string Nombre{get;set;}
        public string Email {get;set;}
        public string Deporte {get;set;}
        public DateTime FechaCreacion {get;set;}
        //Llave foránea de la relación con Patrocinador
        public int PatrocinadorId {get;set;}
        //Propiedad navigacional para la relación con tabla Entrenador
        public Entrenador Entrenador {get;set;}
        //Propiedad navigacional para la relación con tabla intermedia TorneoEquipo
        public List< TorneoEquipo > TorneoEquipos {get;set;}
        //Propiedad navigacional para la relación con tabla intermedia JuegoEquipo
        public List< JuegoEquipo > JuegoEquipos {get;set;}
        //Propiedad navigacional para la relación con tabla Deportista
        public List< Deportista > Deportistas {get;set;}
        
    }
}