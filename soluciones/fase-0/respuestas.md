# Respuestas de la Fase 0

> Lee una respuesta **solo después** de haber escrito la tuya. Si tu respuesta es distinta pero la puedes defender con buenos argumentos, también vale.

---

## Lección 1: Cómo pensar un problema

**Encuentra el error.** El `SI NO` final solo está pegado al segundo `SI`. Con un número positivo (por ejemplo 5), el primer `SI` muestra "Positivo", pero el segundo `SI` (5 < 0) es falso, así que su `SI NO` también muestra "Cero". Resultado: "Positivo" y "Cero" a la vez. La solución es encadenar las preguntas: `SI ... SI NO SI ... SI NO ...`.

**¿Por qué el desglose va de mayor a menor?** Para dar la menor cantidad de billetes posible. Si fuera de menor a mayor, el cambio de RD$ 615 se daría en 615 monedas de RD$ 1.

**¿Qué pasa si escriben "ocho"?** `double.Parse` lanza un error (`FormatException`) y el programa se cierra. Lo arreglarás en la Lección 8.

---

## Lección 2: Variables y tipos

**Elige el tipo.** Edad: `int`. Precio: `decimal`. Nombre: `string`. VIP: `bool`. Temperatura: `double`. Inventario: `int`. Cédula: `string` (no se hacen cuentas con ella, tiene guiones y puede empezar con 0).

**Predice.** `10 / 4` = 2 · `10 % 4` = 2 · `10.0 / 4` = 2.5 · `"10" + 4` = "104" · `10 + 4 + "10"` = "1410" (primero suma 10 + 4 = 14 y luego pega "10") · `"10" + 10 + 4` = "10104" (desde el principio es texto, así que todo se pega).

**Encuentra el error.** 1) Falta poner la suma entre paréntesis: se divide solo `precio3 / 3` (= 13) y se suma a los otros dos, total 68. 2) Todo es `int`, así que aunque pongas paréntesis, 95 / 3 da 31 en vez de 31.67. Debe ser `decimal promedio = (precio1 + precio2 + precio3) / 3m;` usando `decimal` para los precios.

**¿Por qué no `decimal` para todo?** Es más lento y ocupa más memoria que `double`, y para medidas físicas (distancias, temperaturas) un error minúsculo no importa.

**¿Por qué `const`?** Si el ITBIS cambia, se cambia en un solo lugar, y el nombre `Itbis` explica qué es ese 0.18. Un número suelto en el código sin explicación se llama "número mágico".

---

## Lección 3: Decisiones

**Encuentra el error (descuentos).** Una compra de 20,000 también es mayor que 1,000, así que entra en el primer `if` y nunca llega al de 5,000. La condición más exigente tiene que ir primero.

**Bonus (votar).** Usa `||` (O) en vez de `&&` (Y). Así puede votar un niño de 10 años que tenga cédula, o un adulto sin cédula.

**Tres `if` separados vs. `else if`.** Con `if` separados se revisan todas las condiciones y pueden entrar varias. Ejemplo: con el código de descuentos escrito en tres `if` separados, una compra de 6,000 recibiría primero el 10 % y después se sobrescribiría con el 5 %.

**¿Por qué un `else` o `_` final?** Porque lo que "nunca debería pasar" pasa. Sin él, el programa sigue en silencio con un valor equivocado y el error aparece mucho después, lejos de donde nació.

**Triángulo.** Con lados 1, 1, 10, si revisas el tipo primero dirías "isósceles", pero esos lados no forman ningún triángulo.

---

## Lección 4: Repetir

**Encuentra el error.** A) `i < 10` se detiene en 9: debe ser `i <= 10`. Es el error más común de la programación: pasarse por uno o quedarse corto por uno (en inglés se llama *off-by-one*). B) `n` nunca cambia, así que es un bucle infinito: falta `n--;`. C) `suma` se crea de nuevo en 0 en cada vuelta; hay que declararla **antes** del `for`.

**¿Cómo asegurar que un `while` termina?** Algo dentro del bucle tiene que cambiar la condición en cada vuelta y acercarla a ser falsa.

---

## Lección 5: Listas y arreglos

**Encuentra el error.** A) `i <= numeros.Length` intenta leer la posición 3, que no existe (van del 0 al 2): debe ser `<`. B) `productos[1]` es el **segundo** ("Aceite"); el primero es `productos[0]`. C) C# no deja cambiar una lista mientras la recorres con `foreach` (`InvalidOperationException`). Solución: recorrer con `for` desde el final hacia el principio, o crear una lista nueva solo con los que se quedan.

**¿Por qué existen los arreglos?** Son más simples y un poco más rápidos, y dejan claro que el tamaño no cambia (los 7 días de la semana).

**Listas paralelas.** Si borras de una y no de la otra, todos los precios quedan corridos una posición: cada producto muestra el precio del siguiente. Ese error es difícil de ver y es la razón por la que en la Fase 1 aprenderás clases.

---

## Lección 6: Métodos

**Encuentra el error.** A) Si `n` es 0, no llega a ningún `return`. C# exige que **todos** los caminos devuelvan un valor. B) Imprime pero no devuelve nada (`void`), así que no puedes guardar el resultado ni sumarlo con otro. C) Hace seis cosas; debería ser un método corto que llame a seis métodos pequeños.

**¿Por qué `EsPrimo` devuelve `bool`?** Para poder usarlo en cualquier lugar: en un `if`, para contar primos, para filtrar una lista. Si imprime, solo sirve para imprimir.

---

## Lección 7: El debugger

Los 3 errores del misterio están explicados en `leccion-07/Program.cs` de esta carpeta.

**¿Cuándo es mejor `Console.WriteLine` que el debugger?** Cuando el error solo aparece después de miles de vueltas, o cuando quieres ver la historia completa de cómo cambió algo. Aun así, un breakpoint condicional suele resolverlo mejor.

---

## Lección 8: Errores y validación

**Encuentra el error.** A) El `catch` vacío se traga el error: si `CalcularTotal` falla, no se muestra nada y nadie se entera de que hubo un problema. B) Se ignora lo que devuelve `TryParse`: con "abc", `edad` vale 0 y el programa dice "tendrás 1 año". C) Se usa una excepción para algo que se puede revisar antes con `TryParse`, y además `numero` solo existe dentro del `try`, así que no se puede usar después.

**¿`TryParse` o `try / catch`?** `TryParse` para lo que puedes revisar antes (lo que escribió el usuario). `try / catch` para lo que no controlas (un archivo, la red, una base de datos).
