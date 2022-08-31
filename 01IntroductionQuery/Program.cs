using System.Linq;
namespace IndroductionQuery;

public class Program
{
  static void Main(string[] args)
  {
    //QERIES SENCILLOS CON ARRGELO Y REFLEXION
    //EJEMPLO CON NUMEROS

    int[] numeros = { 1, 5, 7, 3, 5, 9, 8 };

    //HACEMOS EL QUERY
    IEnumerable<int> valores = from n in numeros
                               where n > 3 && n < 8
                               select n;

    //MOSTRAMOS LOS RESULTADOS
    foreach (int num in valores)
    {
      System.Console.WriteLine(num);
    }
    System.Console.WriteLine("----------------");
    //EJEMPLO CON CADENAS
    string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };
    //hacemos el queri, aquello que tienen manzana

    IEnumerable<string> encontrados = from p in postres
                                      where p.Contains("manzana")
                                      orderby p
                                      select p;

    //MOSTRAMOS LOS RESULTADOS
    foreach (string postre in encontrados)
    {
      System.Console.WriteLine(postre);
    }
    System.Console.WriteLine("-----------------------");

    //HACEMOS REFLEXIONS
    InformacionResultados(valores);
    System.Console.WriteLine("--------");
    InformacionResultados(encontrados);


  }

  static void InformacionResultados(object pResultados){
    System.Console.WriteLine("Tipo {0} ", pResultados.GetType().Name);
    System.Console.WriteLine("Locacion {0} ", pResultados.GetType().Assembly.GetName().Name);
  }
}