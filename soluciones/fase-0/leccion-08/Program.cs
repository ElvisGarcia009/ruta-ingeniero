// SOLUCIÓN - Lección 8

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
        Console.WriteLine("1. Ver productos");
        Console.WriteLine("2. Vender");
        Console.WriteLine("3. Reporte");
        Console.WriteLine("4. Salir");
        int elegida = PedirOpcion(1, 4);
        Console.WriteLine($"Elegiste la opción {elegida}");
        break;
    case "3":
        CalculadoraAPruebaDeTodo();
        break;
    default:
        Console.WriteLine("Opción no válida.");
        break;
}

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

static decimal PedirDecimalPositivo(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? texto = Console.ReadLine();

        if (!decimal.TryParse(texto, out decimal numero))
        {
            Console.WriteLine("Eso no es un número. Intenta otra vez.");
        }
        else if (numero < 0)
        {
            Console.WriteLine("No puede ser negativo.");
        }
        else if (numero == 0)
        {
            Console.WriteLine("No puede ser cero.");
        }
        else
        {
            return numero;
        }
    }
}

// Reutiliza PedirEntero: la validación de "¿es un número?" ya está resuelta allí.
static int PedirOpcion(int min, int max)
{
    while (true)
    {
        int numero = PedirEntero($"Elige una opción ({min}-{max}): ");
        if (numero >= min && numero <= max)
        {
            return numero;
        }
        Console.WriteLine($"La opción debe estar entre {min} y {max}.");
    }
}

static void CalculadoraAPruebaDeTodo()
{
    decimal x = PedirDecimal("Primer número: ");
    string operacion = PedirOperacion();
    decimal y = PedirDecimal("Segundo número: ");

    if (operacion == "/" && y == 0)
    {
        Console.WriteLine("No se puede dividir entre cero.");
        return;
    }

    // decimal puede desbordarse con números gigantes (por ejemplo 1e28 * 1e28).
    // Eso no se puede revisar fácilmente antes, así que se atrapa.
    try
    {
        decimal resultado = operacion switch
        {
            "+" => x + y,
            "-" => x - y,
            "*" => x * y,
            _ => x / y
        };
        Console.WriteLine($"Resultado: {resultado}");
    }
    catch (OverflowException)
    {
        Console.WriteLine("El resultado es demasiado grande para calcularlo.");
    }
}

static decimal PedirDecimal(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (decimal.TryParse(Console.ReadLine(), out decimal numero))
        {
            return numero;
        }
        Console.WriteLine("Eso no es un número. Intenta otra vez.");
    }
}

static string PedirOperacion()
{
    while (true)
    {
        Console.Write("Operación (+ - * /): ");
        string texto = (Console.ReadLine() ?? "").Trim();
        if (texto == "+" || texto == "-" || texto == "*" || texto == "/")
        {
            return texto;
        }
        Console.WriteLine("Operación no válida. Usa +, -, * o /.");
    }
}
