namespace ArrayList;
using System.Collections;
public class Program
{
  static void Main(string[] args)
  {
    //TIPS PARA EL USO DE ARRAY LIST CON LINQ POR MEDIO DE OFTYPE

    //SELECCIONAMOS OBJETOS DE UN TIPO EN PARTICULAR QUE ESTEN EN UN ARRAY LIST

    ArrayList lista = new ArrayList();
    lista.AddRange(new object[] { "hola", 5, 6.7, false, 4, 2, "saludos", 3.5, 3 });
    //obtenemos solo los enteros
    var enteros = lista.OfType<int>();
    foreach (int n in enteros)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("---------------");

    //CREAMOS UN ARRAY LIST
    ArrayList estudiantes = new ArrayList(){
       new CEstudiante("Ana","A100","Mercadotecnia",10.0),
      new CEstudiante("Luis","S250","Orientado a Objetos",9.0),
      new CEstudiante("Juan","S875","Programacion Basica",5.0),
      new CEstudiante("Susana","A432","Mercadotecnia",8.7),
      new CEstudiante("Pablo","A156","Mercadotecnia",4.3),
      new CEstudiante("Alberto","A456","Orientado a Objetos",8.3),
    };
    //TRANSFORMAR EL ARRAYLIST A UN TIPO QUE IMPLEMENTE A
    //IENUMERABLE<T> PARA PODER SER USADO CON LINQ
    var estL = estudiantes.OfType<CEstudiante>();

    //ahora si usamos linq
    //encontramos los reprobados
    var reprobados = from e in estL
                     where e.Promedio <= 5.0
                     select e;

    //MOSTRAMOS
    System.Console.WriteLine("REPROBADOS");
    foreach(CEstudiante r in reprobados){
      System.Console.WriteLine(r);
    }

    //HACEMOS PROYECCION A UN NUEVO TIPO POR MEDIO DE TIPOS ANONIMOS
    //CREAMOS UNA LISTA
    System.Console.WriteLine("---HACER PROYECCION----");
    List<CEstudiante> estudiante = new List<CEstudiante>{
       new CEstudiante("Ana","A100","Mercadotecnia",10.0),
      new CEstudiante("Luis","S250","Orientado a Objetos",9.0),
      new CEstudiante("Juan","S875","Programacion Basica",5.0),
      new CEstudiante("Susana","A432","Mercadotecnia",8.7),
      new CEstudiante("Pablo","A156","Mercadotecnia",4.3),
      new CEstudiante("Alberto","A456","Orientado a Objetos",8.3),
    };
    var nombrePromedio = from e in estudiante
                         select new { e.Nombre, e.Promedio }; //aca se hace la proyeccion. tipo anonimo con la inf que int.
    foreach(var np in nombrePromedio){
      System.Console.WriteLine(np.ToString());
    }
  }

}
