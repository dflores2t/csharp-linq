using System.Xml.Linq;

namespace LinqXmlElement;

public class Program {
  static void Main(string[] args){
    //Nodes ()
    // Elements()
    //FirstNode
    //Parent.Name
    //LastNode
    //uso de xdom
    var escuela = new XElement("Escuela",
      new XElement("Cienncias",
        new XElement("Materia", "Matematicas"),
        new XElement("Materia", "Fisica")
      ),
        new XElement("artes",
      new XElement("Materia", "Historia del Arte"),
      new XElement("Practica", "Pintura")
        )
    );
    System.Console.WriteLine(escuela);

    System.Console.WriteLine("------------------------------------------------");

    //NODE REGRESA LOS HIJOS
    foreach(XNode nodo in escuela.Nodes()){
      System.Console.WriteLine(nodo.ToString());
    }
    System.Console.WriteLine("--------------------ELEMENT----------------------------");
    //ELEMENTS REGRESA LOS HIJOS DE LOS NODOS DE TIPO XELEMENT
    foreach(XElement elemento in escuela.Elements())
      System.Console.WriteLine(elemento.Name + " = " + elemento.Value);

    System.Console.WriteLine("-----------------FIRST NODE-------------------------");
    //encontramos el padre el primer nodo
    System.Console.WriteLine(escuela.FirstNode);
    System.Console.WriteLine("-----------------ENCONTRAMOS EL PADDRE FIRST NODE-------------------------");
    //encontramos el padre el primer nodo
    System.Console.WriteLine(escuela.FirstNode.Parent.Name);
    System.Console.WriteLine("---------------- ULTIMO NODE-------------------------");
    //encontramos el ultimo nodo
    System.Console.WriteLine(escuela.LastNode);

    //SEGUNDA PARTE 
    //Queries utilse, count, element, nextnode

    //obtiene todos los elementos del donde se encuentre fisica

    IEnumerable<string> materias = from curso in escuela.Elements()
                                   where curso.Elements().Any(materia => materia.Value == "Fisica")
                                   select curso.Value;
    foreach(string s in materias)
      System.Console.WriteLine(s);
    System.Console.WriteLine("------------------------------------------");

    //obtiene el nombre del elemento padre de fisica
    IEnumerable<XName> tipoCurso = from curso in escuela.Elements()
                                   where curso.Elements().Any(materia => materia.Value == "Fisica")
                                   select curso.Name;
    foreach(XName s in tipoCurso)
      System.Console.WriteLine(s);
    System.Console.WriteLine("---------------------------------");

    //regresa a los hijos
    IEnumerable<string> materias2 = from curso in escuela.Elements()
                                    from asignatura in curso.Elements()
                                    where asignatura.Name == "Materia"
                                    select asignatura.Value;
    //mostramos los resultados
    foreach(string m in materias2)
      System.Console.WriteLine(m);
    
    System.Console.WriteLine("----------------------------------------");

    //contar los elementos de un tipo en particular
    int n = escuela.Elements("Cienncias").Count();
    System.Console.WriteLine("Hay {0} Cienncias :", n);

    System.Console.WriteLine("---------------------------");
    //element nos da la primera ocurrencia de un elemento con ese nombre
    string mat = escuela.Element("Cienncias").Element("Materia").Value;
    System.Console.WriteLine(mat);

    System.Console.WriteLine("------------------");

    //obtenomos el siguiente nodo, estilo lista ligada
    XNode? ss = escuela.FirstNode;
    System.Console.WriteLine(ss);
    System.Console.WriteLine("tomamos el siguiente");
    ss = ss.NextNode;
    System.Console.WriteLine(ss);
    System.Console.WriteLine("----------------------");


    ///TRABAJANDO CON ELEMENTOS III
    ///ADDAFTERSELF(),ADDBEFORESELF() ELEMENT VALUE REMOVE DESCENDANTS
    ///
    //OTRA FORMA DE CREAR UN ELEMENTO, EL PARENT ES ESCUELA
    escuela.SetElementValue("Deportes", "no hay");
    System.Console.WriteLine(escuela);
    System.Console.WriteLine("-----------------------");
    //si ya existe ese elemento, lo actualiza
    escuela.SetElementValue("Deportes", "Sin presupuesto");
    System.Console.WriteLine(escuela);

    //para adicionar, despues de un elemento, el primer nodo es el punto referencia
    escuela.FirstNode.AddAfterSelf(new XElement("Asignaturas"));
    System.Console.WriteLine(escuela);

    //ahora adicionamos uno elemento antes de ese
    escuela.FirstNode.AddBeforeSelf(new XElement("EscuelaLibre"));
    System.Console.WriteLine(escuela);

    //obtener a matematicas
    var mate = escuela.Element("Cienncias").Element("Materia");
    //le damos valor
    mate.SetValue("Geometria no EUclidiana");
    System.Console.WriteLine(escuela);

    //obtenemos el valor de ese elemento
    string valorMate = mate.Value;
    System.Console.WriteLine(valorMate);


    //DESCENDANT regresa a los nodos hijos y todos sus descendientes
    //CARGAMOS UN XML DE ARCHIVO
    //NO OLVIDAR PONER UN .XML EN EL DIRECTORIO A CARGA

    XDocument alumnosD = XDocument.Load("/home/dail/dotNet5/csharp-linq/alumnos.xml");
    //lo mostramos
    System.Console.WriteLine(alumnosD);
    System.Console.WriteLine("------------------------------");


    //Elimanr a los alumnos
    // System.Console.WriteLine("Eliminar alumnos");
    // alumnosD.Descendants("Luis").Remove();
    // System.Console.WriteLine(alumnosD);
    // System.Console.WriteLine("---------------------");

    //elimnamos las calificaciones
    // System.Console.WriteLine("remover promedio");
    // alumnosD.Descendants("Promedio").Remove();
    // System.Console.WriteLine(alumnosD);
    // System.Console.WriteLine("-----------------------------");

    //obtenemos las calificaciones
    var califs = from a in alumnosD.Descendants("Promedio")
                 select a.Value;
System.Console.WriteLine("mostrando u obteniendo calificaciones.");
  foreach(var prom in califs){
    System.Console.WriteLine(prom);
  }

  }
}
