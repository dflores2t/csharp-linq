using System.Xml.Linq;

namespace LinqXml;


public class Program
{
  static void Main(string[] args)
  {
    //creamos un documento sencillo de XML con Linq
    XElement raiz = new XElement("raiz");
    XElement el1 = new XElement("Elemento1");
    el1.Add(new XAttribute("atributo", "valor"));
    el1.Add(new XElement("Anidado", "Contenido"));

    raiz.Add(el1);
    System.Console.WriteLine(raiz);
    System.Console.WriteLine("-------------------------------------");


    ///esta form de crear el documento se conoce como construccion funcional
    ///
    XElement documento = new XElement("Alumnos",
    new XElement("ana", new XAttribute("ID", "10100"),
    new XElement("Curso", "Administracion"),
    new XElement("Promedio", "10")//fin ana
    ),
    new XElement("Lus", new XAttribute("ID", "25350"),
    new XElement("Curso", "Programacion"),
    new XElement("Promedio", "9.5")) //fin de luis
    );

    //IMPRIMIR EL DOCUMENTO
    System.Console.WriteLine(documento);

    //ESCRIBIMOS EL DOCUMENTO A DISCO
    // documento.Save("/home/dail/dotNet5/csharp-linq/alumnos.xml");

    //CREACION DE UN DOCUMENTO XML MAS COMPLETO
    XDocument document = new XDocument(
    new XDeclaration("1.0", "utf-8", "yes"), //colocamos la declaracion del documento
    new XComment("Listado de Alumnos"), //esto es un comentario
    new XProcessingInstruction("xml-stylesheet", "href='mystyle.css' title='Compact' type='text/css'"),
    new XElement("{dflores2t}Alumnos", //lleva namespace
    new XElement("ana", new XAttribute("ID", "10100"),
    new XElement("Curso", "Administracion"),
    new XElement("Promedio", "10")//fin ana
    ),
    new XElement("Luis", new XAttribute("ID", "25350"),
    new XElement("Curso", "Programacion"),
    new XElement("Promedio", "9.5")) //fin de luis
    )//fin alumnos
    ); //fin documento.
    //mostramos el documento
    System.Console.WriteLine(document);
    // document.Save("/home/dail/dotNet5/csharp-linq/alumnos.xml");


    //crear un xml a partir de un arregol
    //crear un xml a partir de una cadena
    System.Console.WriteLine("A partir de un arreglo , clase o lista ");
    //usamos tipos anonimos pero funcion con clases normales tambien
    var listado = new[]{
      new {nambre="Jose", Calif=8, Curso="Programacion"},
      new {nambre="Susana", Calif=9, Curso="UML"},
      new {nambre="Maria", Calif=10, Curso="orientado a objetos"},
      new {nambre="Luis", Calif=10, Curso="UML"},
    };

    //ahora creamos el elemento
    XElement alumnos = new XElement("Alumnos", //este es la raiz
        from a in listado
        select new XElement("Alumno", new XAttribute("Nombre", a.nambre),
          new XElement("Curso", a.Curso),
          new XElement("Calificacion", a.Calif)
        )//fin Alumno
    ); //fin alumnos
    //lo mostramos
    Console.WriteLine(alumnos);
    // document.Save("/home/dail/dotNet5/csharp-linq/alumnos.xml");
    System.Console.WriteLine("XML A PARTIR DE UNA CADENA");
    System.Console.WriteLine("____________________________");
    string alumnosStr = @"<Alumnos>
  <Alumno Nombre = 'Jose Adrian'>
    <Curso> Programacion </Curso>
    <Calificacion> 8 </Calificacion>
  </Alumno>
  <Alumno Nombre = 'Marcia Betanco'>
    <Curso> UML </Curso>
    <Calificacion> 9 </Calificacion>
  </Alumno>
  <Alumno Nombre = 'Daniel Flores'>
    <Curso> orientado a objetos </Curso>
    <Calificacion> 10 </Calificacion>
  </Alumno>
  <Alumno Nombre = 'Fernanda Isabella'>
    <Curso> UML </Curso>
    <Calificacion> 10 </Calificacion>
  </Alumno>
</Alumnos>";

    XElement alumnosx = XElement.Parse(alumnosStr); //Pasamos la cadena para que haga parse

    //mostramos el xml
    System.Console.WriteLine(alumnosx);

  }
}