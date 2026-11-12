# Fase 0 — Pensar como programador (C#)

> Guía de la Fase 0 de [Ruta del ingeniero](../README.md). Los ejercicios de cada lección están en esta misma carpeta (`leccion-01` … `leccion-08` y `colmado-v1`).

## Cómo usar esta guía

Esta fase no te enseña cosas nuevas raras: te enseña a **pensar** antes de escribir código. Es la base de todo lo que viene después (bases de datos, APIs, arquitectura). Si esta parte está floja, todo lo demás se cae, como una casa sin zapata.

### Las 6 reglas de oro

1. **Papel primero.** Antes de tocar el teclado, escribe en una hoja los pasos para resolver el problema, en español normal. Si no lo puedes explicar en papel, todavía no lo entiendes.
2. **Predice antes de ejecutar.** Antes de darle a *Run*, escribe qué crees que va a salir en pantalla. Después compara. Cuando fallas una predicción, ahí aprendes de verdad.
3. **20 minutos solo.** Cuando te trabes, intenta 20 minutos por tu cuenta antes de pedir ayuda: relee el problema, usa el debugger (Lección 7), busca en la documentación oficial.
4. **Nada de IA para escribir código en esta fase.** La IA es como una calculadora: muy útil cuando ya sabes sumar, peligrosa cuando no. Puedes usarla solo al final, para que *revise* algo que ya hiciste tú y te explique por qué está mal, nunca para que te lo haga.
5. **Pregúntate siempre "¿y si…?"** ¿Y si el usuario escribe letras en vez de números? ¿Y si la lista está vacía? Esos casos raros se llaman *casos borde* y son donde se rompen los programas de verdad.
6. **Explica en voz alta.** Cuando algo no funcione, explícale el código línea por línea a alguien (o a un objeto). Se llama *método del patito de goma* y funciona sorprendentemente bien: al explicarlo, tú mismo ves el error.

### Cómo está armada cada lección

| Parte | Para qué sirve |
| --- | --- |
| El problema | Una situación real que necesita este tema |
| La analogía | Una comparación con la vida diaria para entenderlo sin código |
| El concepto | La idea explicada paso a paso |
| El código | Ejemplos cortos en C# |
| Ejercicios | Para practicar, de fácil a difícil |
| Encuentra el error | Código con fallos escondidos que tú debes descubrir |
| Preguntas de "¿por qué?" | Para pensar, no para memorizar |

### Cómo usar el repositorio

El repositorio `ruta-ingeniero` tiene una carpeta por lección dentro de `fase-0`. Cada una trae un proyecto de consola con los ejercicios empezados (busca los comentarios `// TODO`). Las soluciones están en la carpeta `soluciones`: ábrelas **solo** después de haberlo intentado de verdad.

Para correr un ejercicio, abre la terminal en su carpeta y escribe `dotnet run`. Necesitas tener instalado el SDK de .NET 8 o superior.

**Ritmo sugerido:** una lección cada 3 o 4 días, y el proyecto del colmado en una semana. No corras: entender bien una lección vale más que pasar por tres.

## Lección 1: Cómo pensar un problema

Programar no es escribir código: es **partir un problema grande en pasos pequeños y exactos**. El código es solo el idioma en que escribes esos pasos al final.

### El problema

Don Pedro tiene un colmado. Un cliente compra RD$ 385 y paga con RD$ 1,000. Don Pedro quiere un programa que le diga cuánto devolver y **con qué billetes y monedas**. ¿Por dónde empiezas? Si abres Visual Studio y empiezas a escribir, te vas a perder. Primero hay que pensar.

### La analogía: el robot que todo lo toma literal

Imagínate que le explicas a un robot cómo hacer un sandwich. Le dices "pon mantequilla en el pan". El robot pone la barra entera de mantequilla encima de la funda de pan cerrada. ¿Por qué? Porque no le dijiste que abriera la funda, que sacara un pan, que usara un cuchillo…

La computadora es ese robot. **Hace exactamente lo que le dices, no lo que quisiste decir.** Por eso tus pasos tienen que ser precisos y no saltarse nada.

### El concepto: Entrada → Proceso → Salida

Casi todo programa se puede ver así:

1. **Entrada:** ¿qué datos tengo o me van a dar? (el total y lo que pagó el cliente)
2. **Proceso:** ¿qué tengo que hacer con esos datos? (restar, y luego repartir en billetes)
3. **Salida:** ¿qué tengo que mostrar o devolver? (el cambio y el desglose)

Cuando el proceso es complicado, lo partes en pedazos más pequeños, y esos pedazos en otros más pequeños, hasta que cada paso sea tan simple que ya sepas escribirlo. Eso se llama **descomposición**.

Para escribir esos pasos usamos **pseudocódigo**: código "de mentira", en español, sin preocuparnos por puntos y comas. Sirve para pensar sin pelear con el lenguaje.

### El código: del papel a C#

Primero, un ejemplo sencillo: el promedio de tres notas.

**Pseudocódigo:**

```
PEDIR nota1, nota2, nota3
suma = nota1 + nota2 + nota3
promedio = suma / 3
MOSTRAR promedio
```

**En C#:**

```csharp
Console.Write("Nota 1: ");
double nota1 = double.Parse(Console.ReadLine()!);
Console.Write("Nota 2: ");
double nota2 = double.Parse(Console.ReadLine()!);
Console.Write("Nota 3: ");
double nota3 = double.Parse(Console.ReadLine()!);

double suma = nota1 + nota2 + nota3;
double promedio = suma / 3;

Console.WriteLine($"Tu promedio es {promedio:F2}");
```

Fíjate que cada línea del pseudocódigo se convirtió en una o dos líneas de C#. **Ese es el truco: si el pseudocódigo está bien, traducirlo es fácil.**

Ahora el problema del colmado, descompuesto:

```
PEDIR total, pagado
SI pagado < total ENTONCES
    MOSTRAR "Falta dinero"
    TERMINAR
cambio = pagado - total
PARA CADA billete en [2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1] (de mayor a menor)
    cantidad = cambio / billete   (división entera: cuántos caben)
    SI cantidad > 0 ENTONCES MOSTRAR cantidad, "de", billete
    cambio = lo que sobra después de usar esos billetes
```

Todavía no tienes que saber escribir el `PARA CADA` en C# (eso es la Lección 4). Lo importante es que **ya sabes qué hay que hacer**.

### Ejercicios

Hazlos **en papel**, en pseudocódigo. Los marcados con 💻 pásalos también a C# en `leccion-01`.

- [ ] **1. El robot y el sandwich.** Escribe las instrucciones para hacer un sandwich de jamón y queso como si fuera para el robot literal. Después pídele a alguien que las siga al pie de la letra y anota dónde se rompen.
- [ ] **2. 💻 Cambio simple.** Pide el total y lo que pagó el cliente. Muestra el cambio. Si pagó menos, muestra cuánto falta.
- [ ] **3. 💻 Año bisiesto.** Un año es bisiesto si es divisible entre 4, **excepto** si es divisible entre 100, **a menos que** también sea divisible entre 400. Escribe los pasos. Prueba tu pseudocódigo a mano con 2024, 1900, 2000 y 2023.
- [ ] **4. Identifica E-P-S.** Para cada uno, escribe la Entrada, el Proceso y la Salida: un cajero automático que retira dinero; una app que te dice si llueve mañana; el sistema de notas de tu universidad.
- [ ] **5. Descompón.** "Hacer una app para que un colmado lleve su inventario." Parte ese problema en al menos 6 tareas más pequeñas. Luego toma una de ellas y pártela otra vez.

### Encuentra el error

Este pseudocódigo debería decir si un número es positivo, negativo o cero. Tiene un fallo. ¿Cuál es? Prueba con distintos números a mano.

```
PEDIR numero
SI numero > 0 ENTONCES MOSTRAR "Positivo"
SI numero < 0 ENTONCES MOSTRAR "Negativo"
SI NO MOSTRAR "Cero"
```

### Preguntas de "¿por qué?"

1. ¿Por qué el desglose de billetes va de **mayor a menor**? ¿Qué pasaría si fuera de menor a mayor?
2. En el promedio, ¿qué pasa si el usuario escribe "ocho" en vez de "8"? (No lo arregles todavía: solo predice qué pasa y luego pruébalo.)
3. ¿Por qué crees que es más rápido escribir pseudocódigo primero, aunque parezca un paso extra?

## Lección 2: Variables y tipos en C#

Una variable es un lugar con nombre donde guardas un dato, y el **tipo** dice qué clase de dato cabe ahí. Elegir mal el tipo produce errores que no se ven a simple vista, sobre todo con dinero.

### El problema

El programa del colmado suma un refresco de RD$ 0.10 y un chicle de RD$ 0.20 y dice que el total es `0.30000000000000004`. Don Pedro piensa que la computadora está dañada. No lo está: alguien eligió el tipo equivocado.

### La analogía: los envases de la cocina

En una cocina tienes envases distintos: un pote para el arroz, una botella para el aceite, un cartón para los huevos. No echas aceite en el cartón de huevos. Cada envase tiene una **etiqueta** (el nombre de la variable) y una **forma** (el tipo) que decide qué puede guardar.

### El concepto: los tipos que más vas a usar

| Tipo | Guarda | Ejemplo | Úsalo para |
| --- | --- | --- | --- |
| `int` | Números enteros | `int cantidad = 3;` | Cantidades, edades, contadores |
| `double` | Números con decimales (aproximados) | `double peso = 2.5;` | Medidas, ciencia, cosas donde un error minúsculo no importa |
| `decimal` | Números con decimales (exactos) | `decimal precio = 25.50m;` | **Dinero, siempre** |
| `string` | Texto | `string nombre = "Arroz";` | Nombres, mensajes |
| `bool` | Verdadero o falso | `bool hayStock = true;` | Sí/no, encendido/apagado |
| `char` | Una sola letra | `char letra = 'A';` | Un carácter suelto |

**¿Por qué `double` falla con el dinero?** La computadora guarda los números en binario (solo ceros y unos). Algunos números como 0.1 no se pueden escribir exactos en binario, igual que 1/3 no se puede escribir exacto en decimal (0.3333… para siempre). `decimal` guarda los números en base 10, como tú los escribes, por eso es exacto. La `m` al final de `25.50m` le dice a C# "esto es decimal".

### El código: tres trampas que debes conocer

**Trampa 1: la división entera.**

```csharp
int a = 7;
int b = 2;
Console.WriteLine(a / b);          // 3, no 3.5
Console.WriteLine(a % b);          // 1  (el % da el residuo, lo que sobra)
Console.WriteLine((double)a / b);  // 3.5
```

Cuando divides dos `int`, C# bota los decimales. No redondea: los corta. El `(double)` delante convierte `a` a double antes de dividir. Eso se llama **cast** (conversión forzada).

**Trampa 2: números que en realidad son texto.**

```csharp
string x = "5";
string y = "3";
Console.WriteLine(x + y);                       // "53", no 8
Console.WriteLine(int.Parse(x) + int.Parse(y)); // 8
```

Con texto, el `+` **pega** en vez de sumar. Todo lo que lee `Console.ReadLine()` es texto, aunque el usuario escriba números. Por eso hay que convertirlo con `int.Parse`, `decimal.Parse`, etc.

**Trampa 3: el dinero con double.**

```csharp
double d = 0.1 + 0.2;
decimal m = 0.1m + 0.2m;
Console.WriteLine(d == 0.3);   // False
Console.WriteLine(m == 0.3m);  // True
```

**Extras útiles:**

```csharp
const decimal Itbis = 0.18m;   // const: un valor que nunca cambia
var total = 100m;              // var: C# adivina el tipo (aquí, decimal)
Console.WriteLine($"Total con ITBIS: {total * (1 + Itbis):F2}");  // $"" mete variables dentro del texto
```

### Ejercicios

Predice el resultado en papel **antes** de ejecutarlo. Los 💻 van en `leccion-02`.

- [ ] **1. Elige el tipo.** ¿Qué tipo usarías para: la edad de una persona, el precio de un producto, el nombre de un cliente, si un cliente es VIP, la temperatura, la cantidad de productos en inventario, la cédula (¡cuidado!)?
- [ ] **2. Predice.** ¿Qué imprime cada línea? `10 / 4`, `10 % 4`, `10.0 / 4`, `"10" + 4`, `10 + 4 + "10"`, `"10" + 10 + 4`.
- [ ] **3. 💻 Factura con ITBIS.** Pide el precio y la cantidad de un producto. Muestra subtotal, ITBIS (18 %) y total, con 2 decimales. Usa el tipo correcto para el dinero.
- [ ] **4. 💻 Convertidor de tiempo.** Pide una cantidad de segundos (por ejemplo 3,725) y muestra cuántas horas, minutos y segundos son (1 h, 2 min, 5 s). Pista: `/` y `%` son tus amigos.
- [ ] **5. 💻 Intercambio.** Tienes `int a = 5; int b = 9;`. Intercambia sus valores para que `a` valga 9 y `b` valga 5. Hazlo primero con una variable extra y después piensa si se puede sin ella.

### Encuentra el error

Este código debería calcular el precio promedio de 3 productos. Da un resultado raro. ¿Por qué? (Hay dos problemas.)

```csharp
int precio1 = 25;
int precio2 = 30;
int precio3 = 40;
int promedio = precio1 + precio2 + precio3 / 3;
Console.WriteLine(promedio);
```

### Preguntas de "¿por qué?"

1. ¿Por qué la cédula o un número de teléfono se guardan como `string` aunque solo tengan números? Pista: ¿vas a sumar cédulas? ¿Qué pasa con un teléfono que empieza con 0?
2. Si `decimal` es exacto, ¿por qué no usamos `decimal` para todo?
3. ¿Qué ventaja tiene escribir `const decimal Itbis = 0.18m;` en vez de escribir `0.18` en cada cálculo?

## Lección 3: Decisiones

Un programa toma caminos distintos según los datos, y casi todos los errores de lógica viven en **las condiciones mal escritas o en el orden equivocado**.

### El problema

Don Pedro quiere dar descuentos: 5 % si la compra pasa de RD$ 1,000 y 10 % si pasa de RD$ 5,000. Un empleado programó esto y ahora nadie recibe el 10 %, aunque compre RD$ 20,000. ¿Qué pasó? Lo vas a descubrir en esta lección.

### La analogía: el portero de la discoteca

El portero revisa en orden: ¿tienes cédula? ¿eres mayor de edad? ¿estás en la lista VIP? En cuanto una respuesta decide qué hacer contigo (entras por la VIP, entras normal o no entras), deja de preguntar. **El orden de las preguntas cambia el resultado.** Si primero pregunta "¿eres mayor de edad?" y te deja pasar, nunca llega a preguntar si eres VIP.

### El concepto

**Comparadores** (preguntas que responden `true` o `false`):

| Símbolo | Significa | Ejemplo |
| --- | --- | --- |
| `==` | igual a | `edad == 18` |
| `!=` | distinto de | `nombre != ""` |
| `>` `<` | mayor / menor que | `total > 1000` |
| `>=` `<=` | mayor o igual / menor o igual | `nota >= 70` |

**Operadores lógicos** (para unir preguntas):

- `&&` (Y): las dos cosas deben ser verdad. "Tengo dinero **y** está abierto" → voy al colmado.
- `||` (O): basta con que una sea verdad. "Llueve **o** hace mucho sol" → llevo sombrilla.
- `!` (NO): invierte. `!hayStock` significa "no hay stock".

**`if / else if / else`**: C# revisa las condiciones de arriba hacia abajo y **entra solo en la primera que sea verdad**. Las demás ni las mira.

### El código

```csharp
decimal total = 6000m;
decimal descuento;

if (total > 5000m)
{
    descuento = total * 0.10m;
}
else if (total > 1000m)
{
    descuento = total * 0.05m;
}
else
{
    descuento = 0m;
}

Console.WriteLine($"Descuento: RD$ {descuento:F2}");
```

Cuando comparas **una sola variable con varios valores fijos**, `switch` queda más limpio:

```csharp
int opcion = 2;

string mensaje = opcion switch
{
    1 => "Vender",
    2 => "Ver inventario",
    3 => "Salir",
    _ => "Opción no válida"   // _ significa "cualquier otra cosa"
};

Console.WriteLine(mensaje);
```

**Los límites importan.** ¿Una compra de exactamente RD$ 1,000 tiene descuento? Con `>` no; con `>=` sí. Siempre prueba tu código con el valor justo en el borde: 999, 1000 y 1001.

### Ejercicios

Todos van en `leccion-03` 💻. Antes de programar cada uno, escribe en papel qué valores vas a usar para probarlo (incluyendo los bordes).

- [ ] **1. Nota a letra.** Pide una nota de 0 a 100 y muestra la letra: A (90–100), B (80–89), C (70–79), D (60–69), F (menos de 60). Si la nota es menor que 0 o mayor que 100, muestra "Nota inválida".
- [ ] **2. Año bisiesto en C#.** Pasa a C# el pseudocódigo que hiciste en la Lección 1. Intenta escribir la condición completa en un solo `if` usando `&&` y `||`.
- [ ] **3. ¿Está abierto el colmado?** El colmado abre de 8 a 22 (hora de 0 a 23), pero los domingos cierra a las 14. Pide la hora y el día (1 = lunes … 7 = domingo) y di si está abierto.
- [ ] **4. Tipo de triángulo.** Pide 3 lados. Primero verifica que formen un triángulo (cada lado debe ser menor que la suma de los otros dos). Luego di si es equilátero, isósceles o escaleno.
- [ ] **5. Calculadora con switch.** Pide dos números y una operación (`+`, `-`, `*`, `/`). Usa `switch`. ¿Qué haces si dividen entre cero?

### Encuentra el error

Este es el código del empleado de Don Pedro. ¿Por qué nadie recibe el 10 %?

```csharp
if (total > 1000m)
{
    descuento = total * 0.05m;
}
else if (total > 5000m)
{
    descuento = total * 0.10m;
}
else
{
    descuento = 0m;
}
```

**Bonus:** este otro código debería decir si alguien puede votar (18 años o más y con cédula). ¿Qué está mal?

```csharp
if (edad >= 18 || tieneCedula)
{
    Console.WriteLine("Puede votar");
}
```

### Preguntas de "¿por qué?"

1. ¿Qué diferencia hay entre escribir tres `if` separados y escribir `if / else if / else`? Inventa un caso donde den resultados distintos.
2. ¿Por qué es buena idea tener siempre un `else` o un `_` al final, aunque "nunca debería pasar"?
3. En el ejercicio 4, ¿por qué hay que verificar primero si es un triángulo válido y después el tipo, y no al revés?

## Lección 4: Repetir

Los bucles repiten un bloque de código sin que tengas que copiarlo. La clave es saber **cuándo debe parar**: si te equivocas, el bucle se pasa por uno, se queda corto o no termina nunca.

### El problema

Don Pedro quiere registrar todas las ventas del día, una por una, y al cerrar ver el total y cuántas ventas hubo. No sabe cuántas ventas va a haber: pueden ser 3 o 300. No puedes escribir 300 veces el mismo código.

### La analogía: lavar platos y dar vueltas a la cancha

- **Dar 10 vueltas a la cancha:** sabes desde el principio cuántas veces. Eso es un `for`.
- **Lavar platos mientras queden sucios:** no sabes cuántos son; paras cuando se acaben. Eso es un `while`.
- **Probar la sopa y echarle sal hasta que esté buena:** la pruebas al menos una vez. Eso es un `do-while`.

### El concepto

| Bucle | Úsalo cuando | Ejemplo de la vida real |
| --- | --- | --- |
| `for` | Sabes cuántas veces repetir | Imprimir la tabla del 7 (10 filas) |
| `while` | Repites mientras algo sea verdad; puede que ni entre | Leer ventas hasta que escriban 0 |
| `do-while` | Igual que while, pero entra al menos una vez | Mostrar un menú hasta que elijan "Salir" |
| `foreach` | Quieres pasar por cada elemento de una lista | Revisar cada billete (Lección 5) |

Dos patrones que vas a usar toda tu vida:

- **Contador:** una variable que empieza en 0 y suma 1 cada vuelta (`cantidad++`).
- **Acumulador:** una variable que empieza en 0 y va sumando valores (`total += venta`).

Y dos palabras especiales: `break` sale del bucle de inmediato; `continue` salta al siguiente giro sin terminar el actual.

### El código

**`for`: la tabla del 7.**

```csharp
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"7 x {i} = {7 * i}");
}
```

Se lee así: "empieza con `i` en 1; mientras `i` sea menor o igual a 10, repite; al final de cada vuelta, suma 1 a `i`".

**`while` con contador y acumulador: las ventas del día.**

```csharp
decimal total = 0m;
int cantidad = 0;

Console.Write("Venta (0 para cerrar): ");
decimal venta = decimal.Parse(Console.ReadLine()!);

while (venta != 0m)
{
    total += venta;      // acumulador
    cantidad++;          // contador

    Console.Write("Venta (0 para cerrar): ");
    venta = decimal.Parse(Console.ReadLine()!);
}

Console.WriteLine($"Ventas: {cantidad}. Total: RD$ {total:F2}");
```

Fíjate en el detalle: se lee la primera venta **antes** del bucle y la siguiente **al final** de cada vuelta. Si olvidas la segunda lectura, `venta` nunca cambia y el bucle no termina jamás. Eso es un **bucle infinito**.

**El desglose de billetes de la Lección 1, por fin en C#:**

```csharp
int cambio = 615;
int[] denominaciones = { 2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1 };

foreach (int d in denominaciones)
{
    int cantidad = cambio / d;
    if (cantidad > 0)
    {
        Console.WriteLine($"{cantidad} de RD$ {d}");
    }
    cambio = cambio % d;
}
```

Compara este código con el pseudocódigo de la Lección 1: es casi línea por línea. Así de útil es pensar primero.

### Ejercicios

Todos en `leccion-04` 💻. Antes de ejecutar, haz una **prueba de escritorio**: una tabla en papel con una columna por variable y una fila por vuelta, anotando cómo cambian los valores.

- [ ] **1. Suma del 1 al N.** Pide N y muestra la suma 1 + 2 + … + N. Prueba con N = 5 (debe dar 15).
- [ ] **2. FizzBuzz.** Imprime del 1 al 100. Si el número es múltiplo de 3, imprime "Fizz"; si es de 5, "Buzz"; si es de los dos, "FizzBuzz". Es una pregunta clásica de entrevista. Pista: piensa en el orden de los `if` (Lección 3).
- [ ] **3. Adivina el número.** El programa elige un número al azar del 1 al 100 (`Random.Shared.Next(1, 101)`). El usuario intenta adivinar y el programa dice "más alto" o "más bajo" hasta que acierte. Al final muestra cuántos intentos usó.
- [ ] **4. Contar dígitos.** Pide un número entero positivo y di cuántos dígitos tiene, **sin convertirlo a texto**. Pista: ¿qué le pasa a 4,582 si lo divides entre 10 una y otra vez?
- [ ] **5. Ventas del día mejoradas.** Toma el ejemplo de las ventas y añade: la venta más alta, la más baja y el promedio. ¿Qué pasa con el promedio si no hubo ninguna venta?

### Encuentra el error

Cada uno de estos tiene un fallo distinto. Haz la prueba de escritorio para encontrarlo.

```csharp
// A) Debería imprimir del 1 al 10
for (int i = 1; i < 10; i++)
{
    Console.WriteLine(i);
}

// B) Debería contar del 10 al 1
int n = 10;
while (n > 0)
{
    Console.WriteLine(n);
}

// C) Debería sumar los números del 1 al 5
for (int i = 1; i <= 5; i++)
{
    int suma = 0;
    suma += i;
    Console.WriteLine(suma);
}
```

### Preguntas de "¿por qué?"

1. Cualquier `for` se puede escribir como `while`. Reescribe la tabla del 7 con `while`. ¿Cuál se lee mejor y por qué?
2. En el error C, ¿por qué importa **dónde** declaras la variable `suma`?
3. ¿Cómo te aseguras de que un `while` siempre va a terminar? ¿Qué tiene que cambiar dentro del bucle?

## Lección 5: Listas y arreglos

Cuando tienes muchos datos del mismo tipo, no creas una variable para cada uno: los guardas juntos en una **colección**. Lo más importante es recordar que **se cuenta desde 0**.

### El problema

El colmado tiene 50 productos. Crear `producto1`, `producto2`, … `producto50` es una locura, y si mañana llega el producto 51 hay que cambiar el código. Necesitas un solo lugar que guarde todos los productos y pueda crecer.

### La analogía: el cartón de huevos y la funda del súper

- Un **arreglo** (*array*) es un cartón de huevos: tiene un tamaño fijo (30 huecos) y cada hueco tiene un número. No le puedes añadir un hueco 31.
- Una **lista** (`List`) es una funda del supermercado: empieza vacía y le vas metiendo y sacando cosas. Crece sola.

En los dos casos, cada lugar tiene un número llamado **índice**, y el primero es el **0**, no el 1. Es como los pisos de algunos edificios: planta baja (0), primer piso (1), segundo piso (2).

### El concepto

|  | Arreglo `int[]` | Lista `List<int>` |
| --- | --- | --- |
| Tamaño | Fijo desde que se crea | Crece y se encoge |
| Cuántos hay | `.Length` | `.Count` |
| Añadir | No se puede | `.Add(x)` |
| Quitar | No se puede | `.Remove(x)` o `.RemoveAt(i)` |
| ¿Está? | `Array.IndexOf(a, x) >= 0` | `.Contains(x)` |
| Úsalo para | Datos que no cambian de tamaño (los días de la semana) | Casi todo lo demás |

Si una colección tiene 5 elementos, sus índices van del **0 al 4**. Pedir el índice 5 hace que el programa explote con un error llamado `IndexOutOfRangeException` (o `ArgumentOutOfRangeException` en las listas): "pediste un hueco que no existe".

### El código

**Arreglo:**

```csharp
string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

Console.WriteLine(dias[0]);           // Lunes
Console.WriteLine(dias[dias.Length - 1]); // Domingo (el último es Length - 1)
```

**Lista:**

```csharp
List<string> productos = new List<string>();
productos.Add("Arroz");
productos.Add("Habichuelas");
productos.Add("Aceite");

Console.WriteLine(productos.Count);              // 3
Console.WriteLine(productos.Contains("Arroz"));  // True

productos.Remove("Habichuelas");
Console.WriteLine(productos.Count);              // 2
```

**Recorrer: `foreach` vs `for`.** Usa `foreach` cuando solo necesitas cada elemento. Usa `for` cuando también necesitas su posición.

```csharp
foreach (string p in productos)
{
    Console.WriteLine(p);
}

for (int i = 0; i < productos.Count; i++)
{
    Console.WriteLine($"{i + 1}. {productos[i]}");   // muestra 1., 2., ... aunque el índice empiece en 0
}
```

**Buscar el mayor (un patrón clásico):**

```csharp
List<decimal> precios = new List<decimal> { 45m, 120m, 30m, 85m };

decimal mayor = precios[0];      // supongo que el primero es el mayor
foreach (decimal precio in precios)
{
    if (precio > mayor)
    {
        mayor = precio;          // encontré uno más grande, lo guardo
    }
}
Console.WriteLine($"El más caro cuesta RD$ {mayor}");
```

¿Por qué empezar con `precios[0]` y no con `0`? Piensa qué pasaría si todos los precios fueran negativos (por ejemplo, una lista de deudas).

### Ejercicios

Todos en `leccion-05` 💻. **No uses** funciones ya hechas como `.Max()`, `.Sum()`, `.Reverse()` o `.Distinct()`: la idea es que sepas hacerlas tú.

- [ ] **1. Notas del curso.** Pide notas hasta que escriban -1 y guárdalas en una lista. Muestra el promedio, la mayor, la menor y cuántas están por encima del promedio.
- [ ] **2. Al revés.** Dado un arreglo `{ 1, 2, 3, 4, 5 }`, crea otro con los elementos al revés. Después intenta hacerlo sobre el mismo arreglo, sin crear otro.
- [ ] **3. Buscar producto.** Ten una lista de productos. Pide un nombre y di en qué posición está, o "No encontrado". ¿Qué pasa si escriben "arroz" y en la lista dice "Arroz"?
- [ ] **4. Sin repetidos.** Dada una lista con números repetidos, crea una nueva sin repetidos, manteniendo el orden: `{ 3, 1, 3, 2, 1 }` → `{ 3, 1, 2 }`.
- [ ] **5. Productos y precios.** Usa dos listas: una de nombres y otra de precios, donde la posición `i` de una corresponde a la posición `i` de la otra. Muestra el producto más caro con su nombre. (Esto se ve incómodo a propósito: en la Fase 1 aprenderás una forma mucho mejor.)

### Encuentra el error

```csharp
// A) Debería imprimir todos los elementos
int[] numeros = { 10, 20, 30 };
for (int i = 0; i <= numeros.Length; i++)
{
    Console.WriteLine(numeros[i]);
}

// B) Debería imprimir el primer producto
List<string> productos = new List<string> { "Arroz", "Aceite" };
Console.WriteLine(productos[1]);

// C) Debería quitar los precios mayores a 100 (este explota; ¿por qué?)
List<decimal> precios = new List<decimal> { 50m, 150m, 80m, 200m };
foreach (decimal p in precios)
{
    if (p > 100m)
    {
        precios.Remove(p);
    }
}
```

### Preguntas de "¿por qué?"

1. Si las listas pueden hacer todo lo que hacen los arreglos y más, ¿por qué existen los arreglos?
2. En el error C, ¿por qué crees que C# no te deja cambiar una lista mientras la recorres con `foreach`? Piensa en contar personas en una fila mientras algunas se salen.
3. En el ejercicio 5, ¿qué pasa si alguien borra un nombre de la primera lista pero olvida borrar su precio de la segunda?

## Lección 6: Métodos

Un método es un pedazo de código con nombre que hace **una sola cosa** y que puedes usar las veces que quieras. Es la herramienta número uno para que un programa grande se pueda entender.

### El problema

Tu programa del colmado ya tiene 200 líneas seguidas. El código para pedir un número al usuario está copiado 8 veces. Encuentras un error en ese código y tienes que arreglarlo en 8 lugares… y se te olvida uno. Además, para entender qué hace el programa hay que leerlo todo.

### La analogía: la licuadora

Una licuadora recibe algo (fruta, leche, azúcar), hace su trabajo por dentro y te devuelve algo (un batido). No necesitas saber cómo funciona el motor: solo qué le echas y qué te da.

- Lo que le echas = **parámetros**.
- Lo que te devuelve = **valor de retorno**.
- El botón con nombre ("Licuar") = **el nombre del método**.

Algunas máquinas no devuelven nada: un bombillo recibe electricidad y solo hace algo (alumbra). Esos métodos se marcan con `void` ("vacío").

### El concepto

```csharp
static decimal CalcularItbis(decimal monto)
//     ^tipo     ^nombre       ^parámetro (tipo y nombre)
//     que devuelve
{
    return monto * 0.18m;   // return entrega el resultado y termina el método
}
```

Reglas para métodos buenos:

1. **Una sola responsabilidad.** Si para describir lo que hace necesitas decir "y", probablemente son dos métodos.
2. **Nombre con verbo que diga lo que hace:** `CalcularTotal`, `PedirNumero`, `EsBisiesto`. Si devuelve `bool`, que suene a pregunta: `EsPrimo`, `HayStock`, `EstaAbierto`.
3. **Cortos.** Si no cabe en la pantalla, probablemente hace demasiado.
4. **No repitas código.** Si copiaste algo dos veces, a la tercera hazlo método. Esta idea se llama **DRY** (*Don't Repeat Yourself*, "no te repitas").

### El código

**Antes:** todo mezclado.

```csharp
Console.Write("Precio: ");
decimal precio = decimal.Parse(Console.ReadLine()!);
Console.Write("Cantidad: ");
decimal cantidad = decimal.Parse(Console.ReadLine()!);
decimal subtotal = precio * cantidad;
decimal itbis = subtotal * 0.18m;
Console.WriteLine($"Total: {subtotal + itbis:F2}");
```

**Después:** el código de arriba se lee como una historia y los detalles están abajo.

```csharp
decimal precio = PedirDecimal("Precio: ");
decimal cantidad = PedirDecimal("Cantidad: ");
decimal total = CalcularTotalConItbis(precio * cantidad);
MostrarTotal(total);

static decimal PedirDecimal(string mensaje)
{
    Console.Write(mensaje);
    return decimal.Parse(Console.ReadLine()!);
}

static decimal CalcularTotalConItbis(decimal subtotal)
{
    const decimal Itbis = 0.18m;
    return subtotal + subtotal * Itbis;
}

static void MostrarTotal(decimal total)
{
    Console.WriteLine($"Total: RD$ {total:F2}");
}
```

Ahora, si mañana el ITBIS cambia, lo cambias en **un** lugar. Y si `PedirDecimal` tiene un error, lo arreglas una vez y queda arreglado en todo el programa.

**Detalle importante: calcular no es lo mismo que mostrar.** `CalcularTotalConItbis` devuelve el número y no imprime nada. Así lo puedes usar para mostrarlo en consola, guardarlo en un archivo o enviarlo a otra parte. Un método que calcula **y** imprime solo sirve para imprimir.

### Ejercicios

Todos en `leccion-06` 💻.

- [ ] **1. `EsPrimo(int n)`.** Devuelve `true` si `n` es primo (solo se divide exacto entre 1 y sí mismo). Usa ese método para imprimir todos los primos del 1 al 100. ¿Qué devuelve tu método con 0, 1 y 2?
- [ ] **2. `EsBisiesto(int anio)`.** Convierte tu solución de la Lección 3 en un método que devuelva `bool`.
- [ ] **3. `Mayor(List<decimal> numeros)`.** Devuelve el mayor de la lista. ¿Qué debería pasar si la lista está vacía? Decide y escríbelo en un comentario.
- [ ] **4. Desglose como método.** Convierte el desglose de billetes de la Lección 4 en `static void MostrarDesglose(int cambio)`.
- [ ] **5. Refactorizar.** Toma tu ejercicio de "ventas del día mejoradas" (Lección 4, ejercicio 5) y divídelo en métodos. El código de arriba no debería tener más de 10 líneas. *Refactorizar* es cambiar cómo está escrito el código sin cambiar lo que hace.

### Encuentra el error

```csharp
// A) No compila. ¿Por qué? (Pista: ¿qué devuelve si n es 0?)
static string Signo(int n)
{
    if (n > 0) return "Positivo";
    if (n < 0) return "Negativo";
}

// B) Compila, pero no se puede usar para sumar dos totales. ¿Por qué?
static void CalcularTotal(decimal precio, int cantidad)
{
    Console.WriteLine(precio * cantidad);
}

// C) ¿Qué problema de diseño tiene este método?
static void ProcesarVenta()
{
    // pide el producto, busca el precio, calcula el ITBIS,
    // imprime la factura, actualiza el inventario
    // y guarda la venta en el historial (90 líneas)
}
```

### Preguntas de "¿por qué?"

1. Los métodos hacen el programa más largo en líneas totales. ¿Por qué aun así lo hacen más fácil de entender?
2. ¿Por qué `EsPrimo` debería devolver `bool` en vez de imprimir "Es primo"?
3. Mira un ejercicio tuyo de la Lección 3 o 4. Si tuvieras que explicárselo a alguien solo leyendo los nombres de los métodos, ¿se entendería?

## Lección 7: El debugger

El debugger (depurador) te deja **pausar el programa en cualquier línea y ver el valor de cada variable en ese momento**. Es la herramienta que más te va a independizar: en vez de adivinar o preguntar, miras qué está pasando de verdad.

### El problema

Tu programa da un resultado incorrecto. Lo lees diez veces y "todo se ve bien". Empiezas a llenar el código de `Console.WriteLine` para ver valores, y después se te olvida borrarlos. O peor: copias el código en una IA y aceptas lo que te diga sin entender qué estaba mal. Así nunca aprendes a encontrar errores solo.

### La analogía: el video en cámara lenta

En el béisbol, cuando hay una jugada dudosa, el árbitro no adivina: mira la repetición cuadro por cuadro. El debugger hace eso con tu programa. Pones una **pausa** donde quieras y avanzas **una línea a la vez**, mirando cómo cambia cada variable.

### El concepto: el vocabulario básico

| Término | Qué es | Tecla (Visual Studio y VS Code) |
| --- | --- | --- |
| **Breakpoint** (punto de interrupción) | Un punto rojo en una línea donde el programa se pausa | F9 o clic en el margen izquierdo |
| **Iniciar depuración** | Correr el programa con el debugger activo | F5 |
| **Step Over** (paso por encima) | Ejecuta la línea actual y pasa a la siguiente | F10 |
| **Step Into** (paso a dentro) | Si la línea llama a un método, entra en él | F11 |
| **Step Out** (paso afuera) | Termina el método actual y vuelve a quien lo llamó | Shift + F11 |
| **Continuar** | Sigue corriendo hasta el próximo breakpoint | F5 |
| **Locals / Variables** | Ventana con el valor actual de cada variable | Aparece sola al pausar |
| **Watch** (inspección) | Ventana donde escribes una expresión para vigilarla, como `total / cantidad` | Clic derecho → *Add Watch* |
| **Breakpoint condicional** | Solo pausa si se cumple una condición, como `i == 50` | Clic derecho sobre el punto rojo → *Conditions* |

También puedes pasar el mouse por encima de cualquier variable mientras el programa está pausado y ver su valor.

### El método: depurar como un científico

1. **Reproduce el error.** Encuentra una entrada exacta que siempre falle. "A veces falla" no sirve.
2. **Predice.** Antes de pausar, escribe qué valor *debería* tener cada variable en ese punto.
3. **Observa.** Pon un breakpoint antes de donde crees que está el error y avanza línea por línea.
4. **Encuentra la primera diferencia.** El error está en la primera línea donde lo que ves no coincide con lo que predijiste.
5. **Arregla y vuelve a probar** con la misma entrada, y también con los casos borde.

El paso 2 es el más importante. Si no sabes qué valor esperas, el debugger solo te muestra números sin sentido.

### El código: el misterio de las ventas

En `leccion-07` hay un programa llamado *El misterio de las ventas*. Calcula el total, el promedio y la venta más alta de una semana. Tiene **3 errores escondidos**. Los resultados que debería dar están escritos en un comentario al principio del archivo.

**La regla de esta lección:** no puedes encontrar los errores leyendo. Tienes que encontrarlos con el debugger, siguiendo el método de arriba.

### Ejercicios

- [ ] **1. Primer contacto.** Abre el ejercicio de la tabla del 7 (Lección 4). Pon un breakpoint dentro del `for`, presiona F5 y avanza con F10. Mira cómo cambia `i` en la ventana de variables.
- [ ] **2. Breakpoint condicional.** En tu FizzBuzz, pon un breakpoint que solo se detenga cuando `i == 45`. ¿Qué se va a imprimir en esa vuelta? Predice y verifica.
- [ ] **3. Entrar a un método.** En tu ejercicio de `EsPrimo` (Lección 6), pausa en la llamada al método y usa F11 para entrar. Sigue paso a paso qué pasa con `EsPrimo(9)`.
- [ ] **4. 💻 El misterio de las ventas.** Encuentra y arregla los 3 errores de `leccion-07`. Por cada uno, anota: en qué línea estaba, qué valor esperabas, qué valor viste y cómo lo arreglaste.
- [ ] **5. Tu propio misterio.** Toma un ejercicio tuyo que ya funcione, métele un error a propósito y dáselo a un compañero para que lo encuentre con el debugger.

### Preguntas de "¿por qué?"

1. ¿Qué ventajas tiene el debugger sobre llenar el código de `Console.WriteLine`? ¿Hay algún caso donde el `WriteLine` sea mejor?
2. ¿Por qué es tan importante poder **reproducir** un error antes de intentar arreglarlo?
3. Si una IA te dice "el error está en la línea 12", ¿cómo usarías el debugger para comprobar si tiene razón?

## Lección 8: Errores y validación

Los usuarios **siempre** van a escribir cosas que no esperas. Un programa profesional no se cae: revisa lo que le dan, avisa con un mensaje claro y deja intentar otra vez.

### El problema

El empleado de Don Pedro escribe "veinte" en el precio y el programa se cierra de golpe con un mensaje en inglés lleno de letras raras. Se perdieron todas las ventas que llevaba. Don Pedro dice que el programa "no sirve".

### La analogía: la cajera y los billetes falsos

Una buena cajera no acepta cualquier papel que le den. Antes de meterlo en la caja, lo revisa: ¿es un billete de verdad? ¿es de la cantidad correcta? Si algo está mal, lo devuelve y dice "este no te lo puedo aceptar", pero **no cierra el colmado**. Validar es eso: revisar en la puerta antes de que el dato malo entre.

### El concepto: tres tipos de errores

| Tipo | Cuándo aparece | Ejemplo | Quién lo encuentra |
| --- | --- | --- | --- |
| **De compilación** | Antes de correr | Falta un `;`, tipo equivocado | El compilador (subrayado rojo) |
| **De ejecución** (excepciones) | Mientras corre | Convertir "veinte" a número, índice fuera de rango | El programa explota |
| **De lógica** | Nunca "aparece" | El descuento se calcula mal | Solo tú, probando (y el debugger) |

Los de lógica son los más peligrosos, porque el programa funciona "bien" pero da resultados malos.

Una **excepción** es la forma en que C# grita "¡no puedo seguir!". Hay dos estrategias para manejarlas:

1. **Prevenir (mejor):** revisar el dato antes de usarlo. Para convertir texto a número, se usa `TryParse`.
2. **Atrapar:** usar `try / catch` para cosas que no puedes revisar antes, como un archivo que alguien borró o una conexión a internet que se cae.

### El código

**`Parse` vs `TryParse`:**

```csharp
int a = int.Parse("veinte");   // EXPLOTA: FormatException

bool pudo = int.TryParse("veinte", out int b);
// pudo = false, b = 0, y el programa sigue vivo
```

`TryParse` intenta convertir y te devuelve `true` o `false`. Si pudo, deja el número en la variable que pusiste después de `out`. La palabra `out` significa "este parámetro es una salida: el método lo va a llenar".

**El método que vas a usar en todos tus programas de consola:**

```csharp
static int PedirEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? texto = Console.ReadLine();

        if (int.TryParse(texto, out int numero))
        {
            return numero;   // dato válido: sale del método (y del bucle)
        }

        Console.WriteLine("Eso no es un número entero. Intenta otra vez.");
    }
}
```

El `string?` con signo de pregunta significa que la variable podría quedar sin valor (`null`). Pasa, por ejemplo, si la entrada se cierra. `TryParse` sabe manejar ese caso y simplemente devuelve `false`.

**`try / catch`, para lo que no se puede prevenir:**

```csharp
try
{
    string contenido = File.ReadAllText("ventas.txt");
    Console.WriteLine(contenido);
}
catch (FileNotFoundException)
{
    Console.WriteLine("No encontré el archivo de ventas. ¿Se movió de lugar?");
}
```

**Lanzar tus propias excepciones con `throw`:** cuando alguien usa mal tu método, es mejor avisar de inmediato que devolver un resultado falso.

```csharp
static decimal AplicarDescuento(decimal precio, decimal porcentaje)
{
    if (porcentaje < 0 || porcentaje > 100)
    {
        throw new ArgumentException("El porcentaje debe estar entre 0 y 100.");
    }
    return precio - precio * porcentaje / 100;
}
```

### Ejercicios

Todos en `leccion-08` 💻.

- [ ] **1. `PedirDecimalPositivo(string mensaje)`.** Como `PedirEntero`, pero para `decimal` y que además rechace los números negativos y el cero, con un mensaje distinto para cada caso.
- [ ] **2. `PedirOpcion(int min, int max)`.** Pide un número y solo lo acepta si está entre `min` y `max`. Úsalo para un menú de 4 opciones.
- [ ] **3. Calculadora a prueba de todo.** Toma tu calculadora de la Lección 3 y haz que nada la tumbe: ni letras, ni división entre cero, ni operaciones que no existen.
- [ ] **4. Rompe tu propio programa.** Elige un ejercicio tuyo anterior e intenta tumbarlo de todas las formas posibles: texto vacío, letras, números gigantes como 99999999999, negativos, espacios. Anota cada forma que funcionó y arréglala.
- [ ] **5. Lista de "¿y si…?".** En papel: escribe al menos 10 cosas que podrían salir mal en el programa del colmado (la Lección 9). Esa lista será tu guía de pruebas.

### Encuentra el error

```csharp
// A) Este programa "nunca falla". ¿Por qué eso es un problema?
try
{
    decimal total = CalcularTotal(productos);
    Console.WriteLine(total);
}
catch
{
    // nada
}

// B) ¿Qué pasa si el usuario escribe "abc"?
int.TryParse(Console.ReadLine(), out int edad);
Console.WriteLine($"El año que viene tendrás {edad + 1} años");

// C) Esto funciona, pero ¿por qué es mala idea?
try
{
    int numero = int.Parse(Console.ReadLine()!);
}
catch (FormatException)
{
    Console.WriteLine("Número inválido");
}
```

### Preguntas de "¿por qué?"

1. ¿Por qué se dice que un `catch` vacío es peor que dejar que el programa explote?
2. ¿Cuándo usarías `TryParse` y cuándo `try / catch`? Da un ejemplo de cada uno.
3. ¿Por qué un mensaje como "Eso no es un número entero" es mejor que "Error"? ¿Quién lee esos mensajes?

## Proyecto: Colmado v1 en consola

Aquí juntas todo lo de la Fase 0 en un programa de verdad: un sistema de ventas para el colmado de Don Pedro. Es la primera versión de un proyecto que va a ir creciendo contigo en las próximas fases.

### Lo que Don Pedro necesita

Un programa de consola con este menú, que se repite hasta que elijan salir:

| Opción | Qué hace |
| --- | --- |
| 1. Ver productos | Muestra cada producto con su número, nombre, precio y cantidad en inventario |
| 2. Agregar producto | Pide nombre, precio y cantidad inicial. No permite nombres repetidos ni precios menores o iguales a 0 |
| 3. Vender | Arma una venta con uno o más productos, muestra la factura con ITBIS, cobra y da el cambio con su desglose |
| 4. Reporte del día | Cantidad de ventas, total vendido, venta más alta y productos con poco inventario (menos de 5) |
| 5. Salir | Muestra el reporte del día y termina |

**La venta en detalle:**

1. Se muestra la lista de productos.
2. El empleado elige un producto por su número y la cantidad.
3. Si no hay suficiente inventario, se avisa y no se agrega.
4. Se repite hasta que el empleado escriba 0 para terminar la venta.
5. Se muestra la factura: cada línea (producto, cantidad, precio, subtotal), el subtotal general, el ITBIS (18 %) y el total.
6. Se pide con cuánto paga el cliente. Si paga menos, se vuelve a pedir.
7. Se muestra el cambio y su desglose en billetes y monedas.
8. Se descuenta el inventario y la venta queda registrada para el reporte.

El programa arranca con estos productos ya cargados: Arroz (RD$ 45, 50 unidades), Habichuelas (RD$ 60, 30), Aceite (RD$ 250, 12), Salami (RD$ 180, 8) y Refresco (RD$ 50, 24).

### Las reglas

- Usa solo lo que aprendiste en la Fase 0: variables, condiciones, bucles, listas, métodos y validación.
- Guarda los productos en **listas paralelas**: una de nombres, una de precios y una de cantidades, donde la posición `i` de las tres habla del mismo producto. Va a sentirse incómodo, y eso es parte de la lección.
- Todo el dinero en `decimal`.
- **Nada puede tumbar el programa**, escriba lo que escriba el usuario.
- Nada de IA para escribir el código. Puedes usarla al final para que revise tu solución terminada y te diga qué mejoraría, y después tú decides si tiene razón.

### Pasos guiados

En `colmado-v1` tienes un esqueleto con los métodos vacíos y comentarios `// TODO`. Hazlo en este orden y **prueba cada paso antes de pasar al siguiente**:

- [ ] **Paso 1. Papel.** Escribe en pseudocódigo el menú principal y la opción "Vender" completa.
- [ ] **Paso 2. El menú.** Haz que el menú se muestre, lea la opción con `PedirEnteroEnRango` y se repita hasta elegir 5. Por ahora cada opción solo imprime su nombre.
- [ ] **Paso 3. Ver productos.** Muestra la tabla de productos. Pista: `{nombre,-15}` en un texto con `$` rellena con espacios hasta 15 caracteres, y así las columnas quedan alineadas.
- [ ] **Paso 4. Agregar producto.** Con todas sus validaciones.
- [ ] **Paso 5. Vender, primera versión.** Un solo producto por venta, sin desglose.
- [ ] **Paso 6. Vender completo.** Varios productos, factura, cobro, cambio y desglose (reutiliza tu método de la Lección 6).
- [ ] **Paso 7. Reporte del día.**
- [ ] **Paso 8. Romperlo.** Usa tu lista de "¿y si…?" de la Lección 8 y prueba cada caso. Arregla todo lo que falle.

### Criterios de terminado

Tu colmado está listo cuando todo esto es verdad:

- [ ] El programa no se cae con ninguna entrada (letras, vacío, negativos, números enormes, opciones que no existen).
- [ ] Una venta de 2 arroces y 1 aceite da subtotal RD$ 340.00, ITBIS RD$ 61.20 y total RD$ 401.20.
- [ ] Si el cliente paga RD$ 500 por esa venta, el cambio es RD$ 98.80. (Piensa: ¿cómo desglosas los 80 centavos? Decide una regla y escríbela en un comentario.)
- [ ] No se puede vender más de lo que hay en inventario.
- [ ] El inventario baja después de cada venta.
- [ ] Ningún método pasa de unas 25 líneas y el código de arriba se entiende leyendo solo los nombres de los métodos.
- [ ] No hay código copiado y pegado: lo que se repite está en un método.

### Retos extra (opcionales)

- Buscar un producto escribiendo parte de su nombre ("arr" encuentra "Arroz"), sin importar mayúsculas.
- Opción para cancelar una venta a mitad de camino sin que se descuente el inventario.
- Mostrar en el reporte cuál fue el producto más vendido.

### Para pensar cuando termines

1. ¿Qué fue lo más incómodo de usar listas paralelas? ¿Qué errores te causaron?
2. Cierra el programa y ábrelo otra vez. ¿Qué pasó con las ventas y los productos nuevos? ¿Cómo crees que se podría resolver eso?
3. Si Don Pedro te pide ahora descuentos para clientes fijos, ¿cuántas partes de tu código tendrías que tocar?

Estas tres preguntas no tienen que quedar resueltas ahora. Son exactamente los problemas que resuelven las próximas fases.

## Autoevaluación y qué viene después

Estás listo para la Fase 1 cuando puedes hacer todo esto **sin ayuda y sin IA**. Sé honesto: marcar algo que no dominas solo te hace daño a ti.

### ¿Puedo hacerlo solo?

- [ ] Ante un problema nuevo, escribo primero Entrada, Proceso y Salida, y luego el pseudocódigo.
- [ ] Explico por qué el dinero va en `decimal` y no en `double`.
- [ ] Predigo el resultado de `7 / 2`, `7 % 2` y `"7" + 2` sin ejecutar.
- [ ] Sé por qué importa el orden de los `else if` y pruebo siempre los valores del borde.
- [ ] Elijo entre `for`, `while` y `foreach` y explico por qué.
- [ ] Hago una prueba de escritorio de un bucle en papel.
- [ ] Recorro una lista y encuentro el mayor, el menor y el promedio sin funciones ya hechas.
- [ ] Divido un programa en métodos con nombres claros, y separo calcular de mostrar.
- [ ] Uso el debugger con breakpoints, paso a paso y breakpoints condicionales para encontrar un error.
- [ ] Ningún programa mío se cae porque el usuario escribió letras.
- [ ] Terminé el Colmado v1 y cumple todos los criterios de terminado.

Si te faltan dos o más, repasa esas lecciones y repite sus ejercicios antes de seguir. No hay prisa.

### Lo que viene en la Fase 1: programar bien

Las preguntas que quedaron abiertas en el colmado son el punto de partida:

| Problema que sentiste | Lo que vas a aprender |
| --- | --- |
| Las listas paralelas se desordenan | Clases y objetos: un `Producto` que guarda su nombre, precio y cantidad juntos |
| Se pierde todo al cerrar el programa | Guardar en archivos (y en la Fase 3, en bases de datos) |
| Agregar descuentos obliga a tocar muchas partes | Código limpio y responsabilidades claras |
| "Lo cambié y se rompió otra cosa" | Tus primeras pruebas automáticas (unit tests) |
| "Ya no sé qué cambié ayer" | Git: guardar versiones de tu código y volver atrás |

Cada tema nuevo va a llegar igual que aquí: primero el problema, después la solución. Así nunca vas a aprender algo sin saber para qué sirve.
