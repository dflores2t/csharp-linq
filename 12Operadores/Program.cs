namespace QueryOperadores;

using System.Collections;

public class Program
{
  static void Main(string[] args)
  {
    //WHERE STARTWITHS
    string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema", "pay de pera y manzana"
  };
    System.Console.WriteLine("--------WHERE-----\r");
    IEnumerable<string> r1 = postres.Where((n, i) => i % 2 == 0);
    //mostramos los resultados
    foreach (string postre in r1)
    {
      System.Console.WriteLine(postre);
    }
    System.Console.WriteLine("--------STARTSWITH-----\r");

    IEnumerable<string> r2 = from p in postres
                             where p.StartsWith("pay") //empieza con pay
                             select p;

    //mostramos los resultados
    foreach (string postre in r2)
    {
      System.Console.WriteLine(postre);
    }
    System.Console.WriteLine("------ENDSWITH-------\r");
    IEnumerable<string> r3 = from p in postres
                             where p.EndsWith("manzana")
                             select p;
    //mostramos los resultados
    foreach (string postre in r3)
      System.Console.WriteLine(postre);
    System.Console.WriteLine("------TAKEwHILE-------\r");
    int[] numeros = { 1, 5, 7, 3, 5, 9, 8, 11, 2, 4 };
    var r4 = numeros.TakeWhile(n => n < 8);
    //mostramos los resultados
    foreach (int n in r4)
      System.Console.WriteLine(n);
    System.Console.WriteLine("----------SKIPWHILE");
    var r5 = numeros.SkipWhile(n => n < 8);
    //mostramos los resultados
    foreach (int n in r5)
      System.Console.WriteLine(n);

    System.Console.WriteLine("------PROYECCION");
    //proyecction son select y selectmany, transforma el elemento de entrada con la expresion lambda que se coloca y eso es proyectado o colocado como tal en la secuencia de salida.
    System.Console.WriteLine("-------PROYECCION INDEXADA-----------");
    IEnumerable<string> r6 = postres.Select((p, i) => "Indice: " + i + " para el postre=> " + p);

    //mostramos los resultados
    foreach (string postre in r6)
      System.Console.WriteLine(postre);

    System.Console.WriteLine("------------SELECTMANY------------");
    IEnumerable<string> r7 = postres.SelectMany(p => p.Split());
    //mostramos los resultados
    foreach (string postre in r7)
      System.Console.WriteLine(postre);
    System.Console.WriteLine("------------COMPARAMOS CON SELECT ------------");
    //
    IEnumerable<string[]> r8 = postres.Select(p => p.Split());
    //mostramos los resultados
    foreach (string[] n in r8)
    {
      System.Console.WriteLine("--");
      foreach (string m in n)
      {
        System.Console.WriteLine(m);
      }
    }


    //select con multiples variables de rango 
    //join
    System.Console.WriteLine("--------------select con multiples variable ------------\r\n");
    IEnumerable<string> r9 = from p in postres
                             from p1 in p.Split()
                             select p1 + "======>" + p;
    //mostramos los resultados
    foreach (string n in r9)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("------------------------");

    IEnumerable<string> r10 = from p in postres
                              from p1 in postres
                              select "yo quiero: " + p1 + " y tu quieres: " + p;
    //mostramos los resultados
    foreach (string n in r10)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("------------------------");
    System.Console.WriteLine("-----------JOIN --------------");
    List<CEstudiante> estudiantes = new List<CEstudiante>
    {
      new CEstudiante("Ana",100),
      new CEstudiante("Mario",150),
      new CEstudiante("Susana",180)
    };
    List<CCurso> cursos = new List<CCurso>{
      new CCurso("Programacion",100),
      new CCurso("Orientado a Objetos",150),
      new CCurso("Programacion",150),
      new CCurso("Programacion",180),
      new CCurso("UML",100),
      new CCurso("Orientado a Objetos",100),
      new CCurso("UML",180)
    };

    // var viejo = from e in estudiantes
    //             from c in cursos
    //             where c.Id == e.id
    //             select e.Nombre + " esta en el curso " + c.curso;

    var listado = from e in estudiantes
                  join c in cursos on e.Id equals c.Id
                  select e.Nombre + " esta en el curso " + c.Curso;

    //mostramos los resultados 
    foreach (string n in listado)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("-------------------");

    ///GROUP JOIN E INTO
    ///ZIP , ORDERBY ORDERBYDESCENDING
    System.Console.WriteLine("--------group join--------");
    //los resultados se obtienen de forma jerarquia
    //la sintaxis es la misma pero utilizamos into
    var listado2 = from e in estudiantes
                   join c in cursos on e.Id equals c.Id
                   into tempListado
                   select new { estudiante = e.Nombre, tempListado };
    //mostramos los resultados 
    foreach (var lst in listado2)
    {
      System.Console.WriteLine(lst.estudiante);
      foreach (var lst2 in lst.tempListado)
      {
        System.Console.WriteLine(lst2);
      }
    }
    System.Console.WriteLine("-------------------");

    //ZIP REGRESA UNA SECUENCIA QUE APLICA UNA  FUNCIO A CADA PAR
    //se trabaja con dos collecciones, postres y helados
    //zip cada elementos de postres va a pasara determinado funcion junto con los elemenos de otra coleccion
    System.Console.WriteLine("---------ZIP------------");
    string[] helados = { "chocolate", "vainilla", "fresa", "limon" };
    IEnumerable<string> r12 = postres.Zip(helados, (p, h) => p + " con helado de " + h);

    foreach (string n in r12)
      System.Console.WriteLine(n);
    System.Console.WriteLine("-------------------------------------");

    //Ordenamiento, OrderBy, ThenBy, ordena en orden ascendente
    //OrderBydescending, ThenByDescending ordena en orden descentdene
    //Reverse regresa en el orden inverso
    System.Console.WriteLine("------ORDENAMIENTO-------------");
    IEnumerable<int> numOrder = numeros.OrderBy(n => n);
    IEnumerable<int> numDes = numeros.OrderByDescending(n => n);

    foreach (int n in numOrder)
    {
      System.Console.WriteLine(n);
    }
    foreach (int n in numDes)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("----------------");

    string[] palabras = { "hola", "piedra", "pato", "pastel", "carro", "auto" };
    IEnumerable<string> palabrasOrd = palabras.OrderBy(p => p.Length).ThenBy(p => p);
    //primero ordena las palabras por tamano y luego se orden por orden ascendende

    //mostramos los resultados
    foreach (string n in palabrasOrd)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("----------------------");

    //grou by, first, firstordefault, single , singleordefault

    //groupby agrupa una secuencia en subsecuencia
    System.Console.WriteLine("-------agrupamiento -------");
    string[] archivos = System.IO.Directory.GetFiles("/home/dail/Documentos");

    System.Console.WriteLine("ARCHIVOS OBTENIDOS POR GETFILE");
    foreach (string n in archivos)
    {
      System.Console.WriteLine(n);
    }
    //AGRUPAMOS BASADOS EN LA EXTENSION
    //ADENTRO DE () COLOCAMOS EL CRITERIO DE AGRUPAMIENTO
    var archivoAg = archivos.GroupBy(a => System.IO.Path.GetExtension(a));
    System.Console.WriteLine("Resultados Agrupados");
    foreach (IGrouping<string, string> g in archivoAg)
    {
      System.Console.WriteLine("Archivos de extension {0}", g.Key); //usamos la llave de agrupamiento.
      foreach (string a in g)
      {
        System.Console.WriteLine("\t {0}", a);
      }
    }

    //OPERADORES DE ELEMENTO
    //NOS REGRESAN UN UNICO ELEMENTO
    System.Console.WriteLine("-----de elemento-----");
    int primer = numeros.First();
    System.Console.WriteLine(primer);

    //primero que cumpla cierta condicion
    int primerC = numeros.First(n => n % 2 == 0);
    System.Console.WriteLine(primerC);

    //primer elemento o default
    int primerod = numeros.FirstOrDefault(n => n % 57 == 0); //default del entero es 0
    System.Console.WriteLine(primerod);

    //operadores Sum, Aggregate, All, SequenceEqual, Empty, Repeat, Range
    //Cout, LongCount -> regresa la cantidad de elementos en la secuencia into int64
    //Min -> Regresa el elemento menor de la secuencia.
    //Max -> Regresa el elemento mayor de la secuencia.
    //Sum -> Regresa la sumatoria de los elementos.
    //Average -> Regresa el promedio de los elementos.
    //Aggregate -> Hace una agregacion usando nuestro algoritmo.
    System.Console.WriteLine("-----------------AGREGACION--------------");
    int sumatoria = numeros.Sum();
    System.Console.WriteLine(sumatoria);
    int[] numeros2 = { 1, 2, 3, 4, 5 };
    // en este caso la semilla es cero, si no se pone la semilla, toma el primer valor
    int agregado = numeros2.Aggregate(0, (t, n) => t + (n * 2)); //t representa la acmulacion y n representa el valor del Elemento 
    System.Console.WriteLine(agregado);
    System.Console.WriteLine("-------------------------------------");

    System.Console.WriteLine("CUANTIFICADORES");
    //Cuantificadores
    //Contains -> Regresa true si la secuencia contiene al elemento.
    //Any -> Regresa true si un elemento satisface al predicado.
    //All -> Regresa true si todos los elementos satisfacen al predicado
    //SequenceEqual -> Regresa true si la segunda secuencia tiene elementos identios a la de entrada.
    System.Console.WriteLine("----------------------------------");
    bool todos = numeros2.All(n => n < 10);
    System.Console.WriteLine(todos);

    bool iguales = numeros2.SequenceEqual(numeros);
    System.Console.WriteLine(iguales);
    System.Console.WriteLine("----------------------------");

    System.Console.WriteLine("---------------GENERACION ----------");
    //Empty -> crea una suecuencia vacia
    //Repeat -> crea una secuencia de elementos que se repiten
    //Range -> crea una secuencia de enteros dependiendo de lo que se le indique

    System.Console.WriteLine("----------------------------------------------");
    var vacia = Enumerable.Empty<int>();
    foreach (int n in vacia)
    {
      System.Console.WriteLine(n);
    }
    System.Console.WriteLine("-----------------------REPEAT-----------------------");
    var REPETIR = Enumerable.Repeat("Hosa", 10);
    foreach(string n in REPETIR)
      System.Console.WriteLine(n);

      System.Console.WriteLine("--------------------range----------------");
    var rango = Enumerable.Range(5, 15);// inicio, elemennto
    foreach(int n in rango)
      System.Console.WriteLine(n);
  }
}