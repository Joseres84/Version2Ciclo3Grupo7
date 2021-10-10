using System;
using System.Collections.Generic;
namespace Dominio
{
    public class Patrocinador
    {
        public int Id {get; set;}
        public string Documento {get;set;}
        public string TipoPersona {get;set;}
        public string Nombre {get;set;}
        public string Telefono{get;set;}
        public string Direccion{get;set;}
        public string Email {get;set;}
        //Propiedad navigacional para la relación con la tabla Equipo
        public List<Equipo> Equipos {get;set;}

    }
}