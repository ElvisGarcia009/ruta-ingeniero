// SOLUCIÓN - Lección 6

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
        for (int i = 1; i <= 100; i++)
        {
            if (EsPrimo(i)) Console.Write($"{i} ");
        }
        Console.WriteLine();
        break;
    case "2":
        foreach (int anio in new[] { 2024, 1900, 2000, 2023 })
        {
            Console.WriteLine($"{anio}: {(EsBisiesto(anio) ? "bisiesto" : "no bisiesto")}");
        }
        break;
    case "3":
        List<decimal> precios = new List<decimal> { 45m, 120m, 30m, 85m };
        Console.WriteLine($"Mayor: {Mayor(precios)}");
        break;
    case "4":
        MostrarDesglose(615);
        break;
    case "5":
        List<decimal> ventas = LeerVentas();
        MostrarResumen(ventas);
        break;
    default:
        Console.WriteLine("Opción no válida.");
        break;
}

static bool EsPrimo(int n)
{
    if (n < 2) return false;   // 0 y 1 no son primos (y los negativos tampoco)

    // Basta probar divisores hasta la raíz cuadrada de n:
    // si n = a x b, uno de los dos tiene que ser <= raíz de n.
    for (int divisor = 2; divisor * divisor <= n; divisor++)
    {
        if (n % divisor == 0) return false;
    }
    return true;
}

static bool EsBisiesto(int anio)
{
    return (anio % 4 == 0 && anio % 100 != 0) || anio % 400 == 0;
}

// Decisión: con una lista vacía no existe "el mayor", así que se avisa
// con una excepción en vez de inventar un valor como 0 (que podría confundirse con un precio real).
static decimal Mayor(List<decimal> numeros)
{
    if (numeros.Count == 0)
    {
        throw new ArgumentException("La lista está vacía: no tiene mayor.");
    }

    decimal mayor = numeros[0];
    foreach (decimal n in numeros)
    {
        if (n > mayor) mayor = n;
    }
    return mayor;
}

static void MostrarDesglose(int cambio)
{
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
}

// ---- Ejercicio 5: ventas del día, divididas en métodos ----

static List<decimal> LeerVentas()
{
    List<decimal> ventas = new List<decimal>();
    decimal venta = PedirDecimal("Venta (0 para cerrar): ");
    while (venta != 0m)
    {
        ventas.Add(venta);
        venta = PedirDecimal("Venta (0 para cerrar): ");
    }
    return ventas;
}

static void MostrarResumen(List<decimal> ventas)
{
    Console.WriteLine($"Ventas: {ventas.Count}. Total: RD$ {Sumar(ventas):F2}");
    if (ventas.Count == 0)
    {
        Console.WriteLine("No hubo ventas.");
        return;
    }
    Console.WriteLine($"Más alta: RD$ {Mayor(ventas):F2}. Más baja: RD$ {Menor(ventas):F2}.");
    Console.WriteLine($"Promedio: RD$ {Sumar(ventas) / ventas.Count:F2}");
}

static decimal PedirDecimal(string mensaje)
{
    Console.Write(mensaje);
    return decimal.Parse(Console.ReadLine()!);
}

static decimal Sumar(List<decimal> numeros)
{
    decimal suma = 0m;
    foreach (decimal n in numeros) suma += n;
    return suma;
}

static decimal Menor(List<decimal> numeros)
{
    decimal menor = numeros[0];
    foreach (decimal n in numeros)
    {
        if (n < menor) menor = n;
    }
    return menor;
}
