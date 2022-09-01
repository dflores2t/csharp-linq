using System.Collections;
namespace QueryProgresivo;

public class Program{
  static void Main(string[] args){
    /// QUERY PROGRESIVO
    /// INTO, ENVOLNIMIENTO LET
    /// EN EL PROGRESSIVE QUERY HACOMESO UN QUERY EN VARIOS PASOS
    /// ESO NOS PERMITE METER LOGICA ANTES DE OBTENER EL RESULTADO FINAL
    /// 
    //creamos un arrgelo sobre el cual trabajar
    string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema","pay de manzana y pera" };

    bool mayusculas = true;

    IEnumerable<string> resultado;

    var manzana = postres.Where(n => n.Contains("manzana"));
    var ordenadas = manzana.OrderBy(n => n);

    if(mayusculas)
      resultado = ordenadas.Select(n => n.ToUpper());
    else
      resultado = ordenadas;
    
    //mostramos los resultados
    foreach (string postre in resultado){
      System.Console.WriteLine(postre);
    }
    System.Console.WriteLine("-------------------");

    /// into se puede interpretar de dos formas, aqui lo vemos en una continuacion de query
    /// solo se puede usar despues de selcect o group
    /// digamos que reinicia el query permitiendo tener otros where, orberby y select
    /// ojo con into las variables de rango salen de ambito, p no sera conocido por el query de pays
    /// 
    //hacemos un query
    IEnumerable<string> encontrado = from p in postres
                                     where p.Contains("manzana")
                                     orderby p
                                     select p
    into pays
                                     where pays.Contains("pay")
                                     select pays;
  
  //mostramos los resultados
  foreach(string postre in encontrado){
    System.Console.WriteLine(postre);
  }
  System.Console.WriteLine("-----------WRAPPING-----------");

    // ENVOLVER QUERIES - WRAPPING
    // ES OTRA OPCION DE COMO PODEMOS TRABAJAR CON ELQUERY
    // NO CONFUNDIR ESTA TECNICA CON LOS SUBQURIES QUE COLOCAN EL QUERY EN LA EXPRION LAMDA

    IEnumerable<string> mipay = from p in
                                  (
                                    from p1 in postres
                                    where p1.Contains("manzana")
                                    orderby p1
                                    select p1
                                  )
                                where p.Contains("pay")
                                select p;

  //mostramos los resultados
  foreach(string postre in mipay){
    System.Console.WriteLine(postre);
  }
  System.Console.WriteLine("--------------LET------------");
  //LET NOS PERMITE COLOCAR UNA NUEVA VARIABLE JUNTO CON LA DE RANGO
    IEnumerable<string> mispays = from p in postres
                                  let manzanitas = (
                                    from p1 in postres
                                    where p1.Contains("manzana")
                                    orderby p1
                                    select p1
                                  )
                                  where manzanitas.Contains("pay")
                                  select p;
// MOSTRAMOS LOS RESULTADOS
foreach(string postre in mispays){
  System.Console.WriteLine(postre);
}
  }
}