namespace SintaxisFluida;

public class Program{
  static void Main(string[] args){
    //formalizar conceptos
    //sintaxis de query y sintaxis fluida
    //encadenamiento de operadores.
    /*
      hasta hora hemos visto la sintaxis que se llama query expression
      pero tambien existe la sintaxis que se conoce como fluent sintax
      formalicemos alguno conceptos.
      Sequence es un objeto que implementa a IEnumerable<T>
      element es cada item en la secuencia
      Query Operator es un metodo que transforma una secuencia
      acepta una sequencia de entrada y da como resultado una secuencia de salida.
      se tienen cerca de 40 operadores para linq, estos forman parte de los standar query operators, elquery es una expresion que cando se enumera transforma a la secuencia usando los operadores

    */

    //CREAMOS UN ARREGLO SOBLE EL CUAL TRABAJAR
    int[] numeros = { 1, 5,4, 7, 6, 3, 5, 9, 8, 11 };
    //usemos la expresion lambda como argumento, n es el argumento de entrada
    IEnumerable<int> pares = numeros.Where(n => n % 2 == 0);
    //mostramos los resultados
    foreach(int num in pares){
      System.Console.WriteLine(num);
    }

    System.Console.WriteLine("-------------------------");

    //creamos un arregol de tipo string, encontrar todos aquellos que llevan la palabra manzana
    string[] postres = { "pay de manzana1111111111", "pastel de chocolate", "manzana caramelizada", "fresa con crema" };

    IEnumerable<string> encontrados = postres.Where(p=> p.Contains("manzana"));
    
    //imprimimos el resultado
    foreach(string e in encontrados){
      System.Console.WriteLine(e);
      }

  System.Console.WriteLine("----------------");
    //encadenamiento de operadores
    //se van adicionando operadores. para que se valla haciendo un query mas complejo.
    IEnumerable<string> manzanas = postres
    .Where(p => p.Contains("manzana"))
    .OrderBy(o => o.Length)
    .Select(s => s.ToUpper());

    //mostramos el resultado
    foreach(string postre in manzanas){
      System.Console.WriteLine(postre);
    }

  }
}
