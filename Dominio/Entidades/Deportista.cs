using System;

namespace Dominio
{
    public class Deportista
    {
        public int Id {get;set;}
        public string Documento {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}
        public string Email {get;set;}
        public string Rh {get;set;}
        public string Eps {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public string Genero {get;set;}
        //llave foránea para la relación con Equipo
        public int EquipoId {get;set;}
    }
}