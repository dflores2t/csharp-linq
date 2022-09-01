namespace LinqSuquery;

public class Program{
  static void Main(string[] args)
  {
    /// CONCEPTOS DE SUBQUERY
    /// COLOCAR UN QUERY EN LA EXPRESION LAMBDA
    /// un subqueri es un query que esta contenido en la expresion lambda de otro query
    ///el scope que tiene existe dentro de la expresion que lo contiene
    ///
    //CREAMOS UN ARREGLO SOBLE EL CUAL TRABAJAR
    string[] postres = { "pay de manzana1111111111", "pastel de chocolate", "manzana caramelizada", "fresa con crema" };

    //ORDENAMSO ALFABETICAMENT DE ACUERDO AL A ULTIMA PALABRA DE CADA ELEMENTO,
    //SPILT DIVIDE EN UNA COLECCION A LA CADENA
    // pSpilt().Last() es el subquery
    IEnumerable<string> resultados = postres.OrderBy(p => p.Split().Last());

    //mostramos el resultado
    foreach (string postre in resultados){
      System.Console.WriteLine(postre);
    }
    System.Console.WriteLine("TRABAJANDO CON NUMEROS");
    //trabajando con numeros
    int[] numeros = { 19, 14, 56, 32, 11, 8, 45, 7, 18, 2, 17, 23 };
    IEnumerable<int> nums = numeros
    .Where(n => n < numeros.First()); //develver los numeros menores al 19

    //mostramos los resultados
    foreach(int n in nums){
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("--------------numeros sean menores o iguales al primer entero---");
    IEnumerable<int> nums2 = numeros
    .Where(n => n <= (numeros.Where(n2 => n2 % 2 == 0)).First());
    foreach(int n in nums2){
      System.Console.WriteLine(n);
    }
  }
}