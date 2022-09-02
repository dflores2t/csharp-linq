# Linq para XML
* X-DOM
* XELEMENT
* CREACION DE UN DOCUMENTO
* CONSTRUCCION FUNCIONAL
* SALVAR A DISCO EL DOCUMENTO

XML es muy utilizado, pero es tedioso trabajar con el, aunque sencillo.
El framework provee System.Xml.dll y XmlReader, XmlWriter
Pero es mas sencillo trabajar con Linq para xml

Cada parte de XML: declaraicon, elementos, atributos. Pueden representarse por clases , si esas clasas tienen colecciones, entonces podemos representar un arbol que describe al documento XML, esas es la basa de DOM document object model.

Linq para XML tiene un dom conocido como X-DOM y operadores extra. Xobject- clase abstracta que es la base para todo el contenido xml
XNode - Clase base para la mayoria del contenido xml, excepto atributos
Xcontainer - Define miembros para trabajar con sus hijos y es la clase padro de Xelement y XDocument.
XElement - Define a un elemento.
XDocument - Representa la raiz de un arbol XML, en realidad envuelve a un XElement que actua como raiz y lo podemos usar para adicion la declaracion e instrucciones de procesamiento. se puede usar X-dom sin tener un Xdocument.

### XDocument
> XDeclaration
> XComment XprocessingIstrunction
> NameSpace al xml