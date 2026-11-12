// =============================================================
//  Lección 1: Cómo pensar un problema
//  Antes de escribir código, piensa el ejercicio: Entrada -> Proceso -> Salida
//  y pseudocódigo (puedes escribirlo como comentarios aquí mismo).
//  Para correr: abre la terminal en esta carpeta y escribe  dotnet run
// =============================================================

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

// -------------------------------------------------------------
// Ejercicio 2: Cambio simple
// Pide el total y lo que pagó el cliente. Muestra el cambio.
// Si pagó menos, muestra cuánto falta.
// -------------------------------------------------------------
static void CambioSimple()
{
    // TODO: pide el total de la compra (usa decimal para el dinero)

    // TODO: pide cuánto pagó el cliente

    // TODO: si pagó menos que el total, muestra cuánto falta
    //       si no, muestra el cambio
}

// -------------------------------------------------------------
// Ejercicio 3: Año bisiesto
// Bisiesto = divisible entre 4, EXCEPTO si es divisible entre 100,
// A MENOS QUE también sea divisible entre 400.
// Pruébalo con: 2024 (sí), 1900 (no), 2000 (sí), 2023 (no).
// Pista: "a es divisible entre b" en C# se escribe  a % b == 0
// -------------------------------------------------------------
static void AnioBisiesto()
{
    // TODO: pide un año

    // TODO: decide si es bisiesto y muestra el resultado
}
