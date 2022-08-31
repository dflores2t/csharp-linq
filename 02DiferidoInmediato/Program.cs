namespace DiferidoInmediato;

public class Program
{
  static void Main(string[] args)
  {
    //EJEMPLO CON NUMERO

    //CREAMOS EL ARRGELO SOBRE EL CUAL TRABAJAR
    int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

    //HACEMOS EL QUERY Y USAMOS EL TIPO IMPLICITO POR MEDIO DE VAR
    var valores = from n in numeros
                  where n % 2 == 0
                  select n;

    //MOSTRAMOS LOS RESULTADOS
    foreach (int n in valores)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("-----------------------");
    //HACEMOS LA REFLEXION
    InformacionResultados(valores);
    System.Console.WriteLine("--------EJECUCION DIFERIDA---------");
    //HACEMOS EJECUCION DIFERIDA
    // LA EXPRESION DE QUERY NO SE EVALUA HASTA QUE SE ITERA SOBRE EL ARREGLO
    // SE PUEDE USAR EL MISMO QUERY Y SIEMPRE OBTENEMOS EL RESULTADO ACTUALIZADO
    //MODIFICAMOS EL ARREGLO
    numeros[1] = 12;
    //MOSTRAMOS LOS RESULTADOS
    foreach (var item in valores)
    {
      System.Console.WriteLine(item);
    }

    System.Console.WriteLine("---------------");
    System.Console.WriteLine("EJECUCION INMEDIATA");
    // SE EJECUTA EL QUERY EN EL MOMENTO EXACTO
    //GUARDAMOS LOS RESULTADOS COMO UN ARREGLO
    int[] arrayValores = (from n in numeros
                          where n % 2 == 0
                          select n).ToArray<int>();

    //GUARDAMOS LOS RESULTADOS COM UN LIST
    List<int> listValores = (from n in numeros
                             where n % 2 == 0
                             select n).ToList<int>();

    // MOSTRAMOS
    System.Console.WriteLine("EL ARREGLO");
    //MOSTRAMOS LOS RESULTADOS
    foreach (int num in arrayValores)
    {
      System.Console.WriteLine(num);
    }

    numeros[0] = 28;
    System.Console.WriteLine("-----SE ACTUALIZA DESPUES DE LA MODIFICION?");
    //MOSTRAMOS LOS RESULTADOS
    foreach(int num in arrayValores){
      System.Console.WriteLine(num);
    }

    System.Console.WriteLine("LA LISTA");
    System.Console.WriteLine("----------------------------");
    //MOSTRAMOS LOS RESULTADOS
    foreach(int num in listValores){
      System.Console.WriteLine(num);
    }

  }
  static void InformacionResultados(object pResultados)
  {
    System.Console.WriteLine("Tipo {0} ", pResultados.GetType().Name);
    System.Console.WriteLine("Locacion {0} ", pResultados.GetType().Assembly.GetName().Name);
  }
}