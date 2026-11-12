// =============================================================
//  Lección 3: Decisiones
//  Antes de programar cada ejercicio, anota los valores
//  con los que lo vas a probar. ¡Incluye los bordes! (59, 60, 61...)
// =============================================================

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

// Ejercicio 1: A (90-100), B (80-89), C (70-79), D (60-69), F (<60).
// Fuera de 0-100: "Nota inválida".
static void NotaALetra()
{
    // TODO
}

// Ejercicio 2: toda la condición del bisiesto en UN solo if,
// usando && y ||.
static void BisiestoEnUnIf()
{
    // TODO
}

// Ejercicio 3: abre de 8 a 22 (hora 0-23). Domingo (día 7) cierra a las 14.
// ¿Está abierto a las 22 en punto? Decide y escríbelo en un comentario.
static void ColmadoAbierto()
{
    // TODO
}

// Ejercicio 4: primero verifica que sea un triángulo válido
// (cada lado menor que la suma de los otros dos).
// Luego: equilátero (3 iguales), isósceles (2 iguales) o escaleno (ninguno).
static void TipoDeTriangulo()
{
    // TODO
}

// Ejercicio 5: dos números y una operación (+, -, *, /) usando switch.
// ¿Qué haces si dividen entre cero?
static void Calculadora()
{
    // TODO
}
