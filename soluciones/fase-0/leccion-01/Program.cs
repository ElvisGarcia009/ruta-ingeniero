// SOLUCIÓN - Lección 1. Compárala con la tuya: ¿qué hiciste distinto?

Console.WriteLine("Lección 1 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("2. Cambio simple");
Console.WriteLine("3. Año bisiesto");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "2": CambioSimple(); break;
    case "3": AnioBisiesto(); break;
    default: Console.WriteLine("Opción no válida."); break;
}

static void CambioSimple()
{
    Console.Write("Total de la compra: ");
    decimal total = decimal.Parse(Console.ReadLine()!);
    Console.Write("¿Cuánto pagó el cliente? ");
    decimal pagado = decimal.Parse(Console.ReadLine()!);

    if (pagado < total)
    {
        Console.WriteLine($"Faltan RD$ {total - pagado:F2}");
    }
    else
    {
        Console.WriteLine($"Cambio: RD$ {pagado - total:F2}");
    }
}

static void AnioBisiesto()
{
    Console.Write("Año: ");
    int anio = int.Parse(Console.ReadLine()!);

    // Se sigue la regla en el mismo orden en que está escrita:
    // primero la excepción más fuerte (400), luego la del 100, luego la del 4.
    bool esBisiesto;
    if (anio % 400 == 0)
    {
        esBisiesto = true;
    }
    else if (anio % 100 == 0)
    {
        esBisiesto = false;
    }
    else if (anio % 4 == 0)
    {
        esBisiesto = true;
    }
    else
    {
        esBisiesto = false;
    }

    Console.WriteLine(esBisiesto ? $"{anio} es bisiesto" : $"{anio} no es bisiesto");
}
