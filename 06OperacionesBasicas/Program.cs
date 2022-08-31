using System.Collections;

namespace OperacionesBasicas;

public class Program{
  static void Main(){
    //VEMOS VARIAS OPERACIONES QUE PODEMOS REALIZAR CON LINQ

    //CREAMOS UNA LISTA
    List<CEstudiante> estudiantes = new List<CEstudiante>{
       new CEstudiante("Ana","A100","Mercadotecnia",10.0),
      new CEstudiante("Luis","S250","Orientado a Objetos",9.0),
      new CEstudiante("Juan","S875","Programacion Basica",5.0),
      new CEstudiante("Susana","A432","Mercadotecnia",8.7),
      new CEstudiante("Pablo","A156","Mercadotecnia",4.3),
      new CEstudiante("Alberto","A456","Orientado a Objetos",8.3),
    };

    //CONTEO
    int cantidad = (from e in estudiantes
                    where e.Promedio > 5
                    select e).Count();

    System.Console.WriteLine("LA CANTIDAD DE APROBADOS ES {0} ",cantidad);
    System.Console.WriteLine("-------------------------------");
    //REVERSA
    var aprobados = from e in estudiantes
                    where e.Promedio > 5
                    select e;
    foreach(CEstudiante est in aprobados){
      System.Console.WriteLine(est);
    }
    System.Console.WriteLine("ORDEN INVERSO");
    foreach(CEstudiante est in aprobados.Reverse()){
      System.Console.WriteLine(est);
    }
    System.Console.WriteLine("-------------------------------");
    //ORDENAMIENTO
    System.Console.WriteLine("ORDENADOS");
    var ordenados = from e in estudiantes
                    orderby e.Promedio descending
                    select e;
    foreach(var est in ordenados){
      System.Console.WriteLine(est);
    }
    System.Console.WriteLine("-------------------------------");
    System.Console.WriteLine("ASCENDENTE");
    var ordenadosA = from e in estudiantes
                     orderby e.Promedio ascending
                     select e;

  foreach(var est in ordenadosA){
    System.Console.WriteLine(est);
  }
    System.Console.WriteLine("-------------------------------");
    int[] numeros = { 2, 5, 3, 9, 1, 6, 4, 7, 8,3 };
    //ENCONTRAMOS EL MAXIMO
    int maximo = (from n in numeros select n).Max();
    System.Console.WriteLine("EL MAXIMO ES : {0}", maximo);
    //ENCONTRAMOS EL MINIMO
    System.Console.WriteLine("-------------------------------");
    int minimo = (from n in numeros select n).Min();
    System.Console.WriteLine(" EL MINIMO ES : {0}", minimo);
    System.Console.WriteLine("-------------------------------");
    //ENCONTRAMOS EL PROMEDIO
    double promedio = (from n in numeros select n).Average();
    System.Console.WriteLine("EL PROMEDIO ES : {0}", promedio);
    System.Console.WriteLine("-------------------------------");
    //SUMATORIA
    int sum = (from n in numeros select n).Sum();
    System.Console.WriteLine("LA SUMATORIA ES : {0}", sum);
  }
}