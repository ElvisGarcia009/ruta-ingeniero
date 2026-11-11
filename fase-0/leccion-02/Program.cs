// =============================================================
//  Lección 2: Variables y tipos
//  Regla: antes de ejecutar, escribe en papel qué esperas que salga.
// =============================================================

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

// -------------------------------------------------------------
// Ejercicio 3: Factura con ITBIS
// Pide precio y cantidad. Muestra subtotal, ITBIS (18 %) y total
// con 2 decimales. ¿Qué tipo se usa para el dinero?
// -------------------------------------------------------------
static void FacturaConItbis()
{
    // TODO: declara una constante para el ITBIS

    // TODO: pide el precio y la cantidad

    // TODO: calcula subtotal, itbis y total

    // TODO: muéstralos con 2 decimales. Pista: {valor:F2}
}

// -------------------------------------------------------------
// Ejercicio 4: Convertidor de tiempo
// 3725 segundos -> 1 h, 2 min, 5 s
// Pista: / te dice cuántos caben, % te dice cuánto sobra.
// -------------------------------------------------------------
static void ConvertidorDeTiempo()
{
    // TODO: pide la cantidad de segundos (int)

    // TODO: calcula horas, minutos y segundos restantes

    // TODO: muestra el resultado
}

// -------------------------------------------------------------
// Ejercicio 5: Intercambio
// Al final, a debe valer 9 y b debe valer 5.
// -------------------------------------------------------------
static void Intercambio()
{
    int a = 5;
    int b = 9;
    Console.WriteLine($"Antes:   a = {a}, b = {b}");

    // TODO: intercambia los valores de a y b

    Console.WriteLine($"Después: a = {a}, b = {b}");
}
