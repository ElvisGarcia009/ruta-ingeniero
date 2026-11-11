// SOLUCIÓN - Lección 4

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

static void SumaHastaN()
{
    Console.Write("N: ");
    int n = int.Parse(Console.ReadLine()!);

    int suma = 0;
    for (int i = 1; i <= n; i++)
    {
        suma += i;
    }
    Console.WriteLine($"Suma: {suma}");
    // Dato curioso: también se puede calcular sin bucle con n * (n + 1) / 2
}

static void FizzBuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        // El caso "de los dos" va PRIMERO; si no, nunca se llegaría a él.
        if (i % 15 == 0) Console.WriteLine("FizzBuzz");
        else if (i % 3 == 0) Console.WriteLine("Fizz");
        else if (i % 5 == 0) Console.WriteLine("Buzz");
        else Console.WriteLine(i);
    }
}

static void AdivinaElNumero()
{
    int secreto = Random.Shared.Next(1, 101);
    int intentos = 0;
    int intento;

    do
    {
        Console.Write("Tu número: ");
        intento = int.Parse(Console.ReadLine()!);
        intentos++;

        if (intento < secreto) Console.WriteLine("Más alto");
        else if (intento > secreto) Console.WriteLine("Más bajo");
    } while (intento != secreto);

    Console.WriteLine($"¡Correcto! Lo lograste en {intentos} intentos.");
}

static void ContarDigitos()
{
    Console.Write("Número entero positivo: ");
    int numero = int.Parse(Console.ReadLine()!);

    int digitos = 0;
    do
    {
        numero /= 10;   // 4582 -> 458 -> 45 -> 4 -> 0
        digitos++;
    } while (numero > 0);
    // Se usa do-while para que el 0 cuente como 1 dígito.

    Console.WriteLine($"Tiene {digitos} dígito(s)");
}

static void VentasDelDia()
{
    decimal total = 0m;
    int cantidad = 0;
    decimal mayor = 0m;
    decimal menor = 0m;

    Console.Write("Venta (0 para cerrar): ");
    decimal venta = decimal.Parse(Console.ReadLine()!);

    while (venta != 0m)
    {
        total += venta;
        cantidad++;

        // La primera venta es, a la vez, la mayor y la menor hasta ahora.
        if (cantidad == 1 || venta > mayor) mayor = venta;
        if (cantidad == 1 || venta < menor) menor = venta;

        Console.Write("Venta (0 para cerrar): ");
        venta = decimal.Parse(Console.ReadLine()!);
    }

    Console.WriteLine($"Ventas: {cantidad}. Total: RD$ {total:F2}");
    if (cantidad > 0)
    {
        Console.WriteLine($"Más alta: RD$ {mayor:F2}. Más baja: RD$ {menor:F2}.");
        Console.WriteLine($"Promedio: RD$ {total / cantidad:F2}");
    }
    else
    {
        // Sin este if, total / cantidad dividiría entre 0 y el programa explotaría.
        Console.WriteLine("No hubo ventas, así que no hay promedio.");
    }
}
