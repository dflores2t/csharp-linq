namespace OtrosOperadores
{
  public class Program{
    static void Main(string[] args)
    {
      // TAKE, SKIP, REVERSE, FIRST, LAST, ELEMENTAT, ANY, PROBLEMAS CON CAMBIOS DE VALORES
      //ORDENAMIENTOS Y OTROS OPERADORES.
      //CREAMOS UN ARREOL SOBRE EL CUAL TRABAJAR.
      int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

      IEnumerable<int> desdeInicio = numeros.Take(5);
      //mostramos los resultados.
      System.Console.WriteLine("-----TAKE-------");
      //take toma los primeros valores segun la cantidad proporcinada
      foreach (int num in desdeInicio)
        Console.WriteLine(num);

      System.Console.WriteLine("--------------skip------------");
      //SKIP nos sirve para brincar determinada cantidad de elemento desde el inicio.
      IEnumerable<int> brinco = numeros.Skip(5);
      foreach (int num in brinco)
        Console.WriteLine(num);

      System.Console.WriteLine("---------reverse-------");
      //toma la secuencia y la coloca en orden inversa
      IEnumerable<int> reversa = numeros.Reverse();
      foreach (int num in reversa)
        Console.WriteLine(num);

      System.Console.WriteLine("----------first---------");
      //encontramos el primero
      System.Console.WriteLine("El primero es: {0}", numeros.First());
      System.Console.WriteLine("--------ultimo-----------");
      System.Console.WriteLine("El ultimo es : {0}", numeros.Last());
      System.Console.WriteLine("-------------encontrar elemento por indice");
      System.Console.WriteLine("En el Indice 3 esta : {0}", numeros.ElementAt(3));
      System.Console.WriteLine("------vemos si  contiene a deterimnado elemento true/false-----------");
      System.Console.WriteLine("Contiene al 15 - {0}", numeros.Contains(15));
      System.Console.WriteLine("-------------comprobar si hay elementos en la coleccion----------");
      System.Console.WriteLine("Tiene elementos - {0}", numeros.Any());
      System.Console.WriteLine("vemos si tiene multiplo de 5");
      System.Console.WriteLine("hay multipos de 5 - {0}", numeros.Any(n => n % 5 == 0));
      System.Console.WriteLine("Cuidado con los cambios de valores entre la ejecucion de los query");
      System.Console.WriteLine("-----------------------------");
      int valor = 2;
      IEnumerable<int> resultado = numeros.Where(n => n % valor == 0); //uso variable externa de la expresion

      valor =3;
      foreach(int n in resultado){
        System.Console.WriteLine(n);
      }
    }

  }
}