// =============================================================
//  Lección 8: Errores y validación
//  Meta: que NADA tumbe tus programas, escriba lo que escriba el usuario.
// =============================================================

Console.WriteLine("Lección 8 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("1. PedirDecimalPositivo");
Console.WriteLine("2. Menú con PedirOpcion");
Console.WriteLine("3. Calculadora a prueba de todo");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "1":
        decimal precio = PedirDecimalPositivo("Precio: ");
        Console.WriteLine($"Precio aceptado: RD$ {precio:F2}");
        break;
    case "2":
        // TODO: muestra un menú de 4 opciones y usa PedirOpcion(1, 4)
        break;
    case "3":
        CalculadoraAPruebaDeTodo();
        break;
    default:
        Console.WriteLine("Opción no válida.");
        break;
}

// Ejemplo de la guía: úsalo como modelo.
static int PedirEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? texto = Console.ReadLine();

        if (int.TryParse(texto, out int numero))
        {
            return numero;
        }

        Console.WriteLine("Eso no es un número entero. Intenta otra vez.");
    }
}

// Ejercicio 1: como PedirEntero, pero decimal y > 0.
// Un mensaje distinto para "no es número", "es negativo" y "es cero".
static decimal PedirDecimalPositivo(string mensaje)
{
    // TODO
    return 0m;
}

// Ejercicio 2: solo acepta números entre min y max (ambos incluidos).
static int PedirOpcion(int min, int max)
{
    // TODO
    return min;
}

// Ejercicio 3: tu calculadora de la Lección 3, pero que nada la tumbe:
// ni letras, ni división entre cero, ni operaciones que no existen.
static void CalculadoraAPruebaDeTodo()
{
    // TODO
}
