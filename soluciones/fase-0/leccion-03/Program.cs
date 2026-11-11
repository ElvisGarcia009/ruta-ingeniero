// SOLUCIÓN - Lección 3

Console.WriteLine("Lección 3 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("1. Nota a letra");
Console.WriteLine("2. Año bisiesto en un solo if");
Console.WriteLine("3. ¿Está abierto el colmado?");
Console.WriteLine("4. Tipo de triángulo");
Console.WriteLine("5. Calculadora con switch");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "1": NotaALetra(); break;
    case "2": BisiestoEnUnIf(); break;
    case "3": ColmadoAbierto(); break;
    case "4": TipoDeTriangulo(); break;
    case "5": Calculadora(); break;
    default: Console.WriteLine("Opción no válida."); break;
}

static void NotaALetra()
{
    Console.Write("Nota (0-100): ");
    int nota = int.Parse(Console.ReadLine()!);

    // Primero se descarta lo inválido; después se va de mayor a menor.
    if (nota < 0 || nota > 100) Console.WriteLine("Nota inválida");
    else if (nota >= 90) Console.WriteLine("A");
    else if (nota >= 80) Console.WriteLine("B");
    else if (nota >= 70) Console.WriteLine("C");
    else if (nota >= 60) Console.WriteLine("D");
    else Console.WriteLine("F");
}

static void BisiestoEnUnIf()
{
    Console.Write("Año: ");
    int anio = int.Parse(Console.ReadLine()!);

    if ((anio % 4 == 0 && anio % 100 != 0) || anio % 400 == 0)
    {
        Console.WriteLine("Bisiesto");
    }
    else
    {
        Console.WriteLine("No bisiesto");
    }
}

static void ColmadoAbierto()
{
    Console.Write("Hora (0-23): ");
    int hora = int.Parse(Console.ReadLine()!);
    Console.Write("Día (1 = lunes ... 7 = domingo): ");
    int dia = int.Parse(Console.ReadLine()!);

    // Decisión: "abre de 8 a 22" significa que a las 22:00 ya cerró.
    int horaDeCierre = dia == 7 ? 14 : 22;
    bool abierto = hora >= 8 && hora < horaDeCierre;

    Console.WriteLine(abierto ? "Está abierto" : "Está cerrado");
}

static void TipoDeTriangulo()
{
    Console.Write("Lado a: ");
    double a = double.Parse(Console.ReadLine()!);
    Console.Write("Lado b: ");
    double b = double.Parse(Console.ReadLine()!);
    Console.Write("Lado c: ");
    double c = double.Parse(Console.ReadLine()!);

    bool esValido = a < b + c && b < a + c && c < a + b;

    if (!esValido) Console.WriteLine("No forma un triángulo");
    else if (a == b && b == c) Console.WriteLine("Equilátero");
    else if (a == b || b == c || a == c) Console.WriteLine("Isósceles");
    else Console.WriteLine("Escaleno");
}

static void Calculadora()
{
    Console.Write("Primer número: ");
    double x = double.Parse(Console.ReadLine()!);
    Console.Write("Operación (+ - * /): ");
    string operacion = Console.ReadLine() ?? "";
    Console.Write("Segundo número: ");
    double y = double.Parse(Console.ReadLine()!);

    string resultado = operacion switch
    {
        "+" => $"{x + y}",
        "-" => $"{x - y}",
        "*" => $"{x * y}",
        "/" => y == 0 ? "No se puede dividir entre cero" : $"{x / y}",
        _ => "Operación no válida"
    };

    Console.WriteLine(resultado);
}
