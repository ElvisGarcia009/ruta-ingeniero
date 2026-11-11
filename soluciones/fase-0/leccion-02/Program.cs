// SOLUCIÓN - Lección 2

Console.WriteLine("Lección 2 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("3. Factura con ITBIS");
Console.WriteLine("4. Convertidor de tiempo");
Console.WriteLine("5. Intercambio de valores");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "3": FacturaConItbis(); break;
    case "4": ConvertidorDeTiempo(); break;
    case "5": Intercambio(); break;
    default: Console.WriteLine("Opción no válida."); break;
}

static void FacturaConItbis()
{
    const decimal Itbis = 0.18m;

    Console.Write("Precio: ");
    decimal precio = decimal.Parse(Console.ReadLine()!);
    Console.Write("Cantidad: ");
    int cantidad = int.Parse(Console.ReadLine()!);

    decimal subtotal = precio * cantidad;
    decimal itbis = subtotal * Itbis;
    decimal total = subtotal + itbis;

    Console.WriteLine($"Subtotal: RD$ {subtotal:F2}");
    Console.WriteLine($"ITBIS:    RD$ {itbis:F2}");
    Console.WriteLine($"Total:    RD$ {total:F2}");
}

static void ConvertidorDeTiempo()
{
    Console.Write("Segundos: ");
    int totalSegundos = int.Parse(Console.ReadLine()!);

    int horas = totalSegundos / 3600;          // cuántas horas completas caben
    int resto = totalSegundos % 3600;          // lo que sobra después de quitar las horas
    int minutos = resto / 60;
    int segundos = resto % 60;

    Console.WriteLine($"{horas} h, {minutos} min, {segundos} s");
}

static void Intercambio()
{
    int a = 5;
    int b = 9;
    Console.WriteLine($"Antes:   a = {a}, b = {b}");

    // Como pasar el agua de dos vasos: necesitas un tercer vaso vacío.
    int temporal = a;
    a = b;
    b = temporal;

    Console.WriteLine($"Después: a = {a}, b = {b}");

    // ¿Sin variable extra? Con sumas y restas:
    //   a = a + b;  b = a - b;  a = a - b;
    // Funciona, pero se entiende peor y puede desbordarse con números enormes.
    // En C# moderno también existe:  (a, b) = (b, a);
}
