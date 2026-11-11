// =============================================================
//  Lección 5: Listas y arreglos
//  PROHIBIDO usar .Max(), .Min(), .Sum(), .Average(), .Reverse(),
//  .Distinct() o .IndexOf(). La idea es que sepas hacerlos tú.
// =============================================================

Console.WriteLine("Lección 5 - ¿Qué ejercicio quieres correr?");
Console.WriteLine("1. Notas del curso");
Console.WriteLine("2. Al revés");
Console.WriteLine("3. Buscar producto");
Console.WriteLine("4. Sin repetidos");
Console.WriteLine("5. Productos y precios");
Console.Write("Opción: ");
string opcion = Console.ReadLine() ?? "";

switch (opcion)
{
    case "1": NotasDelCurso(); break;
    case "2": AlReves(); break;
    case "3": BuscarProducto(); break;
    case "4": SinRepetidos(); break;
    case "5": ProductosYPrecios(); break;
    default: Console.WriteLine("Opción no válida."); break;
}

// Ejercicio 1: pide notas hasta -1 y guárdalas en una List<double>.
// Muestra promedio, mayor, menor y cuántas están por encima del promedio.
static void NotasDelCurso()
{
    List<double> notas = new List<double>();

    // TODO
}

// Ejercicio 2: crea otro arreglo con los elementos al revés.
// Reto: hazlo sobre el MISMO arreglo, sin crear otro.
static void AlReves()
{
    int[] numeros = { 1, 2, 3, 4, 5 };

    // TODO
}

// Ejercicio 3: pide un nombre y di en qué posición está o "No encontrado".
// ¿Qué pasa si escriben "arroz" en minúsculas?
static void BuscarProducto()
{
    List<string> productos = new List<string> { "Arroz", "Habichuelas", "Aceite", "Salami", "Refresco" };

    // TODO
}

// Ejercicio 4: nueva lista sin repetidos, manteniendo el orden.
// { 3, 1, 3, 2, 1 } -> { 3, 1, 2 }
static void SinRepetidos()
{
    List<int> conRepetidos = new List<int> { 3, 1, 3, 2, 1 };

    // TODO
}

// Ejercicio 5: listas paralelas. La posición i de cada lista es el mismo producto.
// Muestra el nombre y el precio del producto más caro.
static void ProductosYPrecios()
{
    List<string> nombres = new List<string> { "Arroz", "Habichuelas", "Aceite", "Salami", "Refresco" };
    List<decimal> precios = new List<decimal> { 45m, 60m, 250m, 180m, 50m };

    // TODO
}
