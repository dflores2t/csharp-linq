namespace QueryClase;
using System.Collections.Generic;

public class Program
{
  static void Main()
  {
    //USO DE LINQ CON CLASES
    //CREAMOS UNA LISTA

    List<CEstudiante> estudiantes = new List<CEstudiante>
    {
      new CEstudiante("Ana","A100","Mercadotecnia",10.0),
      new CEstudiante("Luis","S250","Orientado a Objetos",9.0),
      new CEstudiante("Juan","S875","Programacion Basica",5.0),
      new CEstudiante("Susana","A432","Mercadotecnia",8.7),
      new CEstudiante("Pablo","A156","Mercadotecnia",4.3),
      new CEstudiante("Alberto","A456","Orientado a Objetos",8.3),
    };

    //ENCONTREMOS LOS REPROBADOS
    var reprobados = from e in estudiantes
                     where e.Promedio <= 5.0
                     select e;
    //MOSTRAMOS
    System.Console.WriteLine("REPROBADOS");
    foreach (CEstudiante r in reprobados)
    {
      System.Console.WriteLine(r);
    }
    //MOSTRAMOS SOLO UN ATRIBUTO DE LOS ESCONTRADOS POR MEDIO DE LA PROPIEDAD
    System.Console.WriteLine("SOLO UN ATRIBUTO");
    foreach (CEstudiante r in reprobados)
    {
      System.Console.WriteLine(r.Nombre);
    }

    //ENCONTRAMOS SOLO LOS NOMBRES DE LOS DE MECADOTECNIA
    var mercadotecnia = from e in estudiantes
                        where e.Curso == "Mercadotecnia"
                        select e.Nombre;

    System.Console.WriteLine("NOMBRES DE MERCADOTECNIA");
    foreach (string n in mercadotecnia)
    {
      System.Console.WriteLine(n);
    }
  }
}