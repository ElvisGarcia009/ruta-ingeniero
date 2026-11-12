// =============================================================
//  Lección 4: Repetir
//  Antes de ejecutar, haz la PRUEBA DE ESCRITORIO (en notas o en Excel):
//  una columna por variable, una fila por vuelta del bucle.
// =============================================================

Console.WriteLine("Lección 4 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("1. Suma del 1 al N");
Console.WriteLine("2. FizzBuzz");
Console.WriteLine("3. Adivina el número");
Console.WriteLine("4. Contar dígitos");
Console.WriteLine("5. Ventas del día mejoradas");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "1": SumaHastaN(); break;
    case "2": FizzBuzz(); break;
    case "3": AdivinaElNumero(); break;
    case "4": ContarDigitos(); break;
    case "5": VentasDelDia(); break;
    default: Console.WriteLine("Opción no válida."); break;
}

// Ejercicio 1: 1 + 2 + ... + N. Con N = 5 debe dar 15.
static void SumaHastaN()
{
    // TODO
}

// Ejercicio 2: del 1 al 100. Múltiplo de 3 -> "Fizz", de 5 -> "Buzz",
// de ambos -> "FizzBuzz", si no, el número. Ojo con el orden de los if.
static void FizzBuzz()
{
    // TODO
}

// Ejercicio 3: el programa elige un número del 1 al 100 y el usuario adivina.
// Responde "más alto" o "más bajo". Al final, cuántos intentos usó.
static void AdivinaElNumero()
{
    int secreto = Random.Shared.Next(1, 101);   // número al azar del 1 al 100

    // TODO
}

// Ejercicio 4: cuántos dígitos tiene un número entero positivo,
// SIN convertirlo a texto. Pista: ¿qué le pasa a 4582 al dividirlo entre 10?
static void ContarDigitos()
{
    // TODO
}

// Ejercicio 5: lee ventas hasta que escriban 0.
// Muestra: cantidad, total, venta más alta, más baja y promedio.
// ¿Qué pasa con el promedio si no hubo ventas?
static void VentasDelDia()
{
    // TODO
}
