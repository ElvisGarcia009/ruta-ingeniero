// =============================================================
//  PROYECTO: Colmado v1
//  Lee los requisitos completos en la guía (sección "Proyecto").
//  Sigue los pasos en orden y PRUEBA cada uno antes del siguiente.
//
//  Reglas:
//   - Solo lo de la Fase 0: variables, if, bucles, listas, métodos, validación.
//   - Todo el dinero en decimal.
//   - Nada puede tumbar el programa.
//   - Nada de IA para escribir el código.
// =============================================================

const int StockBajo = 5;

// Listas paralelas: la posición i de las tres listas es el mismo producto.
List<string> nombres = new List<string> { "Arroz", "Habichuelas", "Aceite", "Salami", "Refresco" };
List<decimal> precios = new List<decimal> { 45m, 60m, 250m, 180m, 50m };
List<int> cantidades = new List<int> { 50, 30, 12, 8, 24 };

// Aquí se guarda el total de cada venta hecha hoy (para el reporte).
List<decimal> ventasDelDia = new List<decimal>();

// TODO (Paso 2): el menú principal.
//  - Muéstralo con MostrarMenu()
//  - Lee la opción con PedirEnteroEnRango(...)
//  - Repite hasta que elijan 5 (¿qué bucle entra al menos una vez?)
//  - Usa un switch para llamar al método de cada opción
//  - Al salir, muestra el reporte del día


// ------------------------------- Menú -------------------------------

static void MostrarMenu()
{
    // TODO (Paso 2)
}

// ----------------------------- Productos -----------------------------

// Paso 3: tabla con número, nombre, precio y cantidad.
// Pista: $"{nombre,-15}" rellena con espacios hasta 15 caracteres.
static void MostrarProductos(List<string> nombres, List<decimal> precios, List<int> cantidades)
{
    // TODO
}

// Paso 4: pide nombre, precio y cantidad inicial.
// No permitas nombres repetidos ni precios <= 0.
// Ojo: hay que agregar a LAS TRES listas.
static void AgregarProducto(List<string> nombres, List<decimal> precios, List<int> cantidades)
{
    // TODO
}

// ------------------------------- Venta -------------------------------

// Pasos 5 y 6: arma el carrito, muestra la factura, cobra, da el cambio,
// descuenta el inventario y registra la venta en ventasDelDia.
// Pista: divide esto en varios métodos más pequeños (¡no uno de 80 líneas!).
static void Vender(List<string> nombres, List<decimal> precios, List<int> cantidades, List<decimal> ventasDelDia)
{
    // TODO
}

// Paso 6: el desglose de billetes. Reutiliza lo que hiciste en la Lección 6.
// ¿Qué haces con los centavos? Decide una regla y escríbela aquí.
static void MostrarDesglose(decimal cambio)
{
    // TODO
}

// ------------------------------ Reporte ------------------------------

// Paso 7: cantidad de ventas, total vendido, venta más alta
// y productos con menos de stockBajo unidades.
static void MostrarReporte(List<decimal> ventasDelDia, List<string> nombres, List<int> cantidades, int stockBajo)
{
    // TODO
}

// ----------------------------- Entradas -----------------------------
// Tus "cajeras que revisan los billetes". Hazlas primero: las vas a usar en todo.

// Solo acepta enteros entre min y max (ambos incluidos).
static int PedirEnteroEnRango(string mensaje, int min, int max)
{
    // TODO
    return min;
}

// Solo acepta decimales entre min y max (ambos incluidos).
static decimal PedirDecimalEnRango(string mensaje, decimal min, decimal max)
{
    // TODO
    return min;
}

// No acepta texto vacío ni solo espacios. Pista: .Trim() quita los espacios de los bordes.
static string PedirTextoNoVacio(string mensaje)
{
    // TODO
    return "";
}
