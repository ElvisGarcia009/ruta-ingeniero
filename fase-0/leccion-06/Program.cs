// =============================================================
//  Lección 6: Métodos
//  Recuerda: un método = una sola cosa. Calcular no es lo mismo que mostrar.
// =============================================================

Console.WriteLine("Lección 6 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("1. Primos del 1 al 100");
Console.WriteLine("2. EsBisiesto");
Console.WriteLine("3. Mayor de una lista");
Console.WriteLine("4. Desglose de billetes");
Console.WriteLine("5. Ventas del día refactorizadas");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "1":
        // TODO: usa EsPrimo para imprimir todos los primos del 1 al 100
        break;
    case "2":
        // TODO: prueba EsBisiesto con 2024, 1900, 2000 y 2023
        break;
    case "3":
        List<decimal> precios = new List<decimal> { 45m, 120m, 30m, 85m };
        // TODO: muestra el resultado de Mayor(precios)
        break;
    case "4":
        MostrarDesglose(615);
        break;
    case "5":
        // TODO: llama aquí a tus métodos de ventas del día
        break;
    default:
        Console.WriteLine("Opción no válida.");
        break;
}

// Ejercicio 1: true si n es primo. ¿Qué devuelve con 0, 1 y 2?
static bool EsPrimo(int n)
{
    // TODO
    return false;
}

// Ejercicio 2
static bool EsBisiesto(int anio)
{
    // TODO
    return false;
}

// Ejercicio 3: ¿qué debería pasar si la lista está vacía?
// Decide y escríbelo aquí en un comentario.
static decimal Mayor(List<decimal> numeros)
{
    // TODO
    return 0m;
}

// Ejercicio 4: el desglose de la Lección 4 convertido en método.
static void MostrarDesglose(int cambio)
{
    // TODO
}

// Ejercicio 5: crea aquí abajo los métodos de "ventas del día"
// (Lección 4, ejercicio 5). El case "5" de arriba no debería pasar de 10 líneas.
