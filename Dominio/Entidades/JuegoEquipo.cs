using System;
using System.Collections.Generic;
namespace Dominio

{
    public class JuegoEquipo
    {
        //llave principal compuesta por los siguientes dos campos enteros:
        public int JuegoId {get;set;}
        public int EquipoId {get;set;}
        
        public int Puntaje {get;set;}
        //Propiedad navigacional hacia la tabla Equipo
        public Equipo Equipo {get;set;}
        //Propiedad navigacional hacia la tabla Juego
        public Juego Juego {get;set;}        
    }
}