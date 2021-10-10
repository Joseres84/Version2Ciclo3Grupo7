using System;
using System.Collections.Generic;

namespace Dominio

{
    public class Arbitro
    {
        public int Id {get; set;}
        public string Documento {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Genero {get;set;}
        public string Telefono {get;set;}
        public string Email {get;set;}        
        public string Deporte {get;set;}      
        //Llave foránea para la relación con la tabla ColegioArbitral
        public int ColegioArbitralId {get;set;} 
        //Llave foránea para la relación con la tabla Torneo
        public int TorneoId {get;set;}                 
    }
}