// SOLUCIÓN - Lección 5

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

static void NotasDelCurso()
{
    List<double> notas = new List<double>();

    Console.Write("Nota (-1 para terminar): ");
    double nota = double.Parse(Console.ReadLine()!);
    while (nota != -1)
    {
        notas.Add(nota);
        Console.Write("Nota (-1 para terminar): ");
        nota = double.Parse(Console.ReadLine()!);
    }

    if (notas.Count == 0)
    {
        Console.WriteLine("No se escribió ninguna nota.");
        return;
    }

    double suma = 0;
    double mayor = notas[0];
    double menor = notas[0];
    foreach (double n in notas)
    {
        suma += n;
        if (n > mayor) mayor = n;
        if (n < menor) menor = n;
    }
    double promedio = suma / notas.Count;

    // Hace falta un segundo recorrido: el promedio no se conoce hasta terminar el primero.
    int porEncima = 0;
    foreach (double n in notas)
    {
        if (n > promedio) porEncima++;
    }

    Console.WriteLine($"Promedio: {promedio:F2}  Mayor: {mayor}  Menor: {menor}");
    Console.WriteLine($"Notas por encima del promedio: {porEncima}");
}

static void AlReves()
{
    int[] numeros = { 1, 2, 3, 4, 5 };

    // Versión 1: un arreglo nuevo
    int[] invertido = new int[numeros.Length];
    for (int i = 0; i < numeros.Length; i++)
    {
        invertido[i] = numeros[numeros.Length - 1 - i];
    }
    Console.WriteLine(string.Join(", ", invertido));

    // Versión 2: en el mismo arreglo, intercambiando las puntas hacia el centro
    for (int i = 0; i < numeros.Length / 2; i++)
    {
        int j = numeros.Length - 1 - i;
        int temporal = numeros[i];
        numeros[i] = numeros[j];
        numeros[j] = temporal;
    }
    Console.WriteLine(string.Join(", ", numeros));
}

static void BuscarProducto()
{
    List<string> productos = new List<string> { "Arroz", "Habichuelas", "Aceite", "Salami", "Refresco" };

    Console.Write("Producto a buscar: ");
    string buscado = (Console.ReadLine() ?? "").Trim();

    int posicion = -1;
    for (int i = 0; i < productos.Count; i++)
    {
        // ToLower() pasa todo a minúsculas para que "arroz" encuentre "Arroz".
        if (productos[i].ToLower() == buscado.ToLower())
        {
            posicion = i;
            break;   // ya lo encontré, no tiene sentido seguir buscando
        }
    }

    if (posicion >= 0) Console.WriteLine($"Está en la posición {posicion} (el producto #{posicion + 1})");
    else Console.WriteLine("No encontrado");
}

static void SinRepetidos()
{
    List<int> conRepetidos = new List<int> { 3, 1, 3, 2, 1 };
    List<int> sinRepetidos = new List<int>();

    foreach (int n in conRepetidos)
    {
        if (!sinRepetidos.Contains(n))
        {
            sinRepetidos.Add(n);
        }
    }

    Console.WriteLine(string.Join(", ", sinRepetidos));
}

static void ProductosYPrecios()
{
    List<string> nombres = new List<string> { "Arroz", "Habichuelas", "Aceite", "Salami", "Refresco" };
    List<decimal> precios = new List<decimal> { 45m, 60m, 250m, 180m, 50m };

    // Se guarda la POSICIÓN del más caro, no solo el precio,
    // porque con la posición se consigue también el nombre.
    int posicionMasCaro = 0;
    for (int i = 1; i < precios.Count; i++)
    {
        if (precios[i] > precios[posicionMasCaro])
        {
            posicionMasCaro = i;
        }
    }

    Console.WriteLine($"El más caro es {nombres[posicionMasCaro]}: RD$ {precios[posicionMasCaro]}");
}
