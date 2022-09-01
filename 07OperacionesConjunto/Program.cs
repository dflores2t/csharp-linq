namespace OperacionesConjunto;
using System.Collections;

public class Program
{
  static void Main(string[] args)
  {
    List<int> conjunto1 = new List<int> { 2, 4, 6, 8, 9 };
    List<int> conjunto2 = new List<int> { 2, 5, 6, 7, 9 };

    //EXCEPT NOS DA LA DIFERENCIA ENTRO DOS CONTENEDORES
    var exep = (from n1 in conjunto1 select n1).Except(from n2 in conjunto2 select n2);

    System.Console.WriteLine("EXCEPT");
    foreach(int num in exep){
      System.Console.WriteLine(num);
    }

    //INTERSECT NOS DA LO COMUN ENTRE LOS DOS CONTENEDORES.
    var ints = (from n1 in conjunto1 select n1).Intersect(from n2 in conjunto2 select n2);

    System.Console.WriteLine("INTERSECT");
    foreach (int unm in ints)
    {
      System.Console.WriteLine(unm);
    }
    //UNION NOS DA LA UNION DE LOS DOS CONTENEDORES SIN REPETICIONES.
    var un = (from n1 in conjunto1 select n1).Union(from n2 in conjunto2 select n2);

    System.Console.WriteLine("UNION");
    foreach (int unm in un)
    {
      System.Console.WriteLine(unm);
    }
    //CONCAT, CONCATENA DIRECTAMENTE LOS CONTENEDORES, TODO LO DEL CONTENEDOR 1 Y TODO LO DEL CONTENEDOR2
    var ct = (from n1 in conjunto1 select n1).Concat(from n2 in conjunto2 select n2);

    System.Console.WriteLine("CANCAT");
    foreach (int unm in ct)
    {
      System.Console.WriteLine(unm);
    }
    //DISTINCT, REMUEVE LOS DUPLICADOS, APLICADO DIRECTAMENTE SOBRE EL RESULTADO DE UN QUERY, ES RECORRER TODO EL CONTEDIDO DE ESA COLECCIEON Y ELIMINARA TODOS AQUELLOS ELEMENTOS QUE ESTEN DUPLICADOS.
    System.Console.WriteLine("DISTINCT");
    foreach (int unm in un.Distinct())
    {
      System.Console.WriteLine(unm);
    }

    

  }
}
