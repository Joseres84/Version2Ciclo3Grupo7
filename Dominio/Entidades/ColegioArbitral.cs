using System;
using System.Collections.Generic;

namespace Dominio

{
    public class ColegioArbitral
    {
	public int Id {get; set;}
	public string Nit {get;set;}
	public string Nombre {get;set;}
	public string Resolucion {get;set;}
	public string Telefono{get;set;}
	public string Direccion{get;set;}
	public string Email {get;set;}
	//Propiedad navigacional para la relación con la tabla Arbitro
	public List<Arbitro> Arbitros {get;set;}        
    }
}