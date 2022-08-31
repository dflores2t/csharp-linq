namespace MetodosLinq;

public class CClaseExplicita
{
  //CREAMOS UN ARREGLO SOBLE EL CUAL TRABABAL
  private static string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };

  //CREAMOS EL QUERY
  //NO PUEDE USARSE DE FORMA IMPLICITA
  // DEBE SER STATICO

  private static IEnumerable<string> encontrados = from p in postres
                                                   where p.Contains("manzana")
                                                   orderby p
                                                   select p;

  //EL METODO REGRESA Y TODO SE TRABAJA INTERNAMENTE.
  public static IEnumerable<int> ObtenerNumerospares()
  {
    int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };
    IEnumerable<int> pares = from n in numeros
                             where n % 2 == 0
                             select n;

    return pares;
  }

  //ESTE METODO REGRESA EL RESULTADO DEL QUERY
  public static IEnumerable<string> ObtenerPostres()
  {
    return encontrados;
  }

  //ESTE METODO REGRESA EL RESULTADO DE UN QUERY INMEDIATO
  public static int[] ObtenerNumerosImpares(){
    int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

    var resultados = from n in numeros
                     where n % 2 != 0
                     select n;
    return resultados.ToArray();
  }
}