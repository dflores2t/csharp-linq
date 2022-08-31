namespace MetodosLinq;
public class Program{
  static void Main(string[] args){
    //OBTENER RESULTADOS DE QUERY DESDE METODOS
    //INVOCAMOS EL METODO

    //INVOCAMOS EL METODO
    IEnumerable<int> resultados = CClaseExplicita.ObtenerNumerospares();

    //MOSTRAMOS LOS RESULTADOS
    foreach(int num in resultados){
      System.Console.WriteLine(num);
    }
    System.Console.WriteLine("----------------");

    IEnumerable<string> postres = CClaseExplicita.ObtenerPostres();
    //mostramos los resultados
    foreach(string p in postres){
      System.Console.WriteLine(p);
    }
    System.Console.WriteLine("----------------------");

    //EJEMPLO DE RESULTADO DE QUERY INMEDIATO
    int[] impares = CClaseExplicita.ObtenerNumerosImpares();
    //mostramos los resultados
    foreach(int m in impares){
      System.Console.WriteLine(m);
    }
  }
}