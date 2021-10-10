using System;
using System.Collections.Generic;

namespace Dominio

{
    public class Escenario
    {
        public int Id {get; set;}
        public string Nombre {get;set;}
        public string Telefono {get;set;}
        public string Direccion {get;set;}
        public string Barrio {get;set;}
        public string NombreAdmin {get;set;}
        public string TipoEscenario {get;set;}
        public string Medidas {get;set;}
        public int CapacidadAforo {get;set;}
        public string Estado {get;set;}
        public string TipoUso {get;set;} 
        //Llave foránea para la relación con la tabla Torneo
        public int TorneoId {get;set;}                             
    }
}