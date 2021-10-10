using System;
using System.Collections.Generic;
namespace Dominio

{
    public class Juego
    {
        public int Id {get; set;}
        public DateTime FechaJuego {get;set;}
        public TimeSpan HoraInicio {get;set;}
        public TimeSpan HoraFin {get;set;}
        public string Deporte {get;set;}
        //Propiedad navigacional para la relación con tabla intermedia JuegoEquipo
        public List< JuegoEquipo > JuegoEquipos {get;set;}
        //Llave foránea para la relación con la tabla Torneo
        public int TorneoId {get;set;}
    }
}