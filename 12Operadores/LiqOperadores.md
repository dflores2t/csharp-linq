# Linq - Operadores
* clasificacion de  operadores
* where para filtrado por indice 
* StartsWith
Hay tres categorias para los operadores de query
> secuencia a secuencia (secuencia de entrada, secuencia de salida)
> secuencia de entrada , elemento sencillo o escalar
> nada de entrada, secuencia de salida
## Secuencia a Secuencia
 Filtro: 
 > Where: Regresa un subconjunto de elementos que satisfgacen una condicion. Aparte de lo que hemos visto, where permite un segundo argumento de tipo int que simboliza el indice del elemento. Esto se conoce como filtrado por indice
 > Take: Regresa el primer elemento n e ignora el resto.
 > Skip: Ignora los primeros n elementos y regresa el resto.
 > TakeWhile: emite elementos de la secuencia de entrada hasta que el predicado es falso.
 > SkipWhile: Ignora los elementos de la sequencia de entrada hasta que el predicado es falso, luego emite el resto.
 > Distinct: Regresa una secuencia de excluye a los duplicados.

 Proyeccion: 
 >select , selectMany
 Union: 
 >join, groupjoin, zip
 ordenamiento: 
 > orderby, thenby,reverse
 agrupamiento: 
 > groupby
  operadores de conjunto:
  > cancat, uninon, intersect, except
  conversion import: 
  > Offtype, Cast
  conversion export: 
  > ToArray, ToDictionary, ToLookup, AsEnumerable, AsQeryable.
## Secuencia a Elemento o Escalar
  Operadores de elemento: 
  > First, FirstOrDefault,Lost, LastOrDefault, Single, SingleOrDefault, ElemetAt,ElemetAtOrDefault, DefaultEmpty
  Agreagacion: 
  >Aggregate, Average, Count, LongCount , Sum, Max, Min
  Cuantificador: 
  > All, Any, Contains, SequenceEqual

## Nada de entrada, Secuencia de salida
  Generaicon: 
  > Empty, Range, Repeat