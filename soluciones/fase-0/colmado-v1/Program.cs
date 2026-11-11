// =============================================================
//  SOLUCIÓN - Colmado v1
//  Ábrela solo después de terminar (o de pelear mucho rato) con la tuya.
//  No es "la" solución: es UNA solución. Compárala con la tuya y
//  pregúntate qué hiciste distinto y cuál se entiende mejor.
// =============================================================

const int StockBajo = 5;

// Listas paralelas: la posición i de las tres listas es el mismo producto.
List<string> nombres = new List<string> { "Arroz", "Habichuelas", "Aceite", "Salami", "Refresco" };
List<decimal> precios = new List<decimal> { 45m, 60m, 250m, 180m, 50m };
List<int> cantidades = new List<int> { 50, 30, 12, 8, 24 };

// El total de cada venta hecha hoy.
List<decimal> ventasDelDia = new List<decimal>();

int opcion;
do
{
    MostrarMenu();
    opcion = PedirEnteroEnRango("Elige una opción: ", 1, 5);
    Console.WriteLine();

    switch (opcion)
    {
        case 1: MostrarProductos(nombres, precios, cantidades); break;
        case 2: AgregarProducto(nombres, precios, cantidades); break;
        case 3: Vender(nombres, precios, cantidades, ventasDelDia); break;
        case 4: MostrarReporte(ventasDelDia, nombres, cantidades, StockBajo); break;
    }
    Console.WriteLine();
} while (opcion != 5);

MostrarReporte(ventasDelDia, nombres, cantidades, StockBajo);
Console.WriteLine("¡Hasta mañana, Don Pedro!");


// ------------------------------- Menú -------------------------------

static void MostrarMenu()
{
    Console.WriteLine("===== COLMADO DON PEDRO =====");
    Console.WriteLine("1. Ver productos");
    Console.WriteLine("2. Agregar producto");
    Console.WriteLine("3. Vender");
    Console.WriteLine("4. Reporte del día");
    Console.WriteLine("5. Salir");
}

// ----------------------------- Productos -----------------------------

static void MostrarProductos(List<string> nombres, List<decimal> precios, List<int> cantidades)
{
    Console.WriteLine($"{"#",-3} {"Producto",-15} {"Precio",10} {"Cantidad",9}");
    for (int i = 0; i < nombres.Count; i++)
    {
        Console.WriteLine($"{i + 1,-3} {nombres[i],-15} {precios[i],10:N2} {cantidades[i],9}");
    }
}

static void AgregarProducto(List<string> nombres, List<decimal> precios, List<int> cantidades)
{
    string nombre = PedirTextoNoVacio("Nombre del producto: ");
    if (BuscarPosicionPorNombre(nombres, nombre) >= 0)
    {
        Console.WriteLine($"Ya existe un producto llamado \"{nombre}\".");
        return;
    }

    decimal precio = PedirDecimalEnRango("Precio: ", 0.01m, 1_000_000m);
    int cantidad = PedirEnteroEnRango("Cantidad inicial: ", 0, 100_000);

    // Se agrega a las tres listas a la vez, para que no se desordenen.
    nombres.Add(nombre);
    precios.Add(precio);
    cantidades.Add(cantidad);
    Console.WriteLine($"\"{nombre}\" agregado.");
}

// Devuelve la posición del producto, o -1 si no existe. No importan las mayúsculas.
static int BuscarPosicionPorNombre(List<string> nombres, string nombre)
{
    for (int i = 0; i < nombres.Count; i++)
    {
        if (string.Equals(nombres[i], nombre, StringComparison.OrdinalIgnoreCase))
        {
            return i;
        }
    }
    return -1;
}

// ------------------------------- Venta -------------------------------

static void Vender(List<string> nombres, List<decimal> precios, List<int> cantidades, List<decimal> ventasDelDia)
{
    // El carrito también usa listas paralelas: qué producto (posición) y cuántos.
    List<int> carritoPosiciones = new List<int>();
    List<int> carritoCantidades = new List<int>();

    ArmarCarrito(nombres, precios, cantidades, carritoPosiciones, carritoCantidades);
    if (carritoPosiciones.Count == 0)
    {
        Console.WriteLine("Venta cancelada: no se agregó ningún producto.");
        return;
    }

    decimal total = MostrarFactura(nombres, precios, carritoPosiciones, carritoCantidades);
    Cobrar(total);
    DescontarInventario(cantidades, carritoPosiciones, carritoCantidades);
    ventasDelDia.Add(total);
}

static void ArmarCarrito(List<string> nombres, List<decimal> precios, List<int> cantidades,
                         List<int> carritoPosiciones, List<int> carritoCantidades)
{
    while (true)
    {
        MostrarProductos(nombres, precios, cantidades);
        int numero = PedirEnteroEnRango("Número del producto (0 para terminar): ", 0, nombres.Count);
        if (numero == 0)
        {
            return;
        }

        int posicion = numero - 1;   // el usuario ve 1, 2, 3...; la lista empieza en 0
        int yaEnCarrito = CantidadEnCarrito(posicion, carritoPosiciones, carritoCantidades);
        int disponible = cantidades[posicion] - yaEnCarrito;

        if (disponible == 0)
        {
            Console.WriteLine($"No queda {nombres[posicion]} disponible.");
            continue;
        }

        int cantidad = PedirEnteroEnRango($"Cantidad (máximo {disponible}): ", 1, disponible);
        AgregarAlCarrito(posicion, cantidad, carritoPosiciones, carritoCantidades);
        Console.WriteLine($"Agregado: {cantidad} x {nombres[posicion]}");
        Console.WriteLine();
    }
}

static int CantidadEnCarrito(int posicion, List<int> carritoPosiciones, List<int> carritoCantidades)
{
    for (int i = 0; i < carritoPosiciones.Count; i++)
    {
        if (carritoPosiciones[i] == posicion)
        {
            return carritoCantidades[i];
        }
    }
    return 0;
}

// Si el producto ya está en el carrito, suma la cantidad; si no, crea una línea nueva.
static void AgregarAlCarrito(int posicion, int cantidad, List<int> carritoPosiciones, List<int> carritoCantidades)
{
    for (int i = 0; i < carritoPosiciones.Count; i++)
    {
        if (carritoPosiciones[i] == posicion)
        {
            carritoCantidades[i] += cantidad;
            return;
        }
    }
    carritoPosiciones.Add(posicion);
    carritoCantidades.Add(cantidad);
}

// Muestra la factura y DEVUELVE el total, para poder cobrarlo y registrarlo.
static decimal MostrarFactura(List<string> nombres, List<decimal> precios,
                              List<int> carritoPosiciones, List<int> carritoCantidades)
{
    const decimal Itbis = 0.18m;
    decimal subtotal = 0m;

    Console.WriteLine();
    Console.WriteLine("---------------- FACTURA ----------------");
    for (int i = 0; i < carritoPosiciones.Count; i++)
    {
        int p = carritoPosiciones[i];
        decimal subtotalLinea = precios[p] * carritoCantidades[i];
        subtotal += subtotalLinea;
        Console.WriteLine($"{nombres[p],-15} {carritoCantidades[i],4} x {precios[p],8:N2} = {subtotalLinea,10:N2}");
    }

    decimal itbis = Math.Round(subtotal * Itbis, 2);
    decimal total = subtotal + itbis;

    Console.WriteLine("-----------------------------------------");
    Console.WriteLine($"{"Subtotal:",-30} {subtotal,10:N2}");
    Console.WriteLine($"{"ITBIS (18 %):",-30} {itbis,10:N2}");
    Console.WriteLine($"{"TOTAL:",-30} {total,10:N2}");
    Console.WriteLine();
    return total;
}

static void Cobrar(decimal total)
{
    decimal pagado = PedirDecimalEnRango("¿Con cuánto paga el cliente? ", 0.01m, 10_000_000m);
    while (pagado < total)
    {
        Console.WriteLine($"Faltan RD$ {total - pagado:N2}.");
        pagado = PedirDecimalEnRango("¿Con cuánto paga el cliente? ", 0.01m, 10_000_000m);
    }

    decimal cambio = pagado - total;
    Console.WriteLine($"Cambio: RD$ {cambio:N2}");
    MostrarDesglose(cambio);
}

// Regla para los centavos: en RD casi no circulan monedas de centavos,
// así que se desglosan solo los pesos enteros y los centavos se indican aparte.
static void MostrarDesglose(decimal cambio)
{
    int[] denominaciones = { 2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1 };
    int pesos = (int)Math.Floor(cambio);
    decimal centavos = cambio - pesos;

    foreach (int d in denominaciones)
    {
        int cantidad = pesos / d;
        if (cantidad > 0)
        {
            Console.WriteLine($"  {cantidad} de RD$ {d}");
        }
        pesos = pesos % d;
    }

    if (centavos > 0)
    {
        Console.WriteLine($"  y RD$ {centavos:F2} en centavos");
    }
}

static void DescontarInventario(List<int> cantidades, List<int> carritoPosiciones, List<int> carritoCantidades)
{
    for (int i = 0; i < carritoPosiciones.Count; i++)
    {
        cantidades[carritoPosiciones[i]] -= carritoCantidades[i];
    }
}

// ------------------------------ Reporte ------------------------------

static void MostrarReporte(List<decimal> ventasDelDia, List<string> nombres, List<int> cantidades, int stockBajo)
{
    Console.WriteLine("========== REPORTE DEL DÍA ==========");
    MostrarResumenDeVentas(ventasDelDia);
    MostrarStockBajo(nombres, cantidades, stockBajo);
}

static void MostrarResumenDeVentas(List<decimal> ventasDelDia)
{
    Console.WriteLine($"Ventas realizadas: {ventasDelDia.Count}");

    if (ventasDelDia.Count > 0)
    {
        decimal total = 0m;
        decimal mayor = ventasDelDia[0];
        foreach (decimal venta in ventasDelDia)
        {
            total += venta;
            if (venta > mayor)
            {
                mayor = venta;
            }
        }
        Console.WriteLine($"Total vendido:     RD$ {total:N2}");
        Console.WriteLine($"Venta más alta:    RD$ {mayor:N2}");
    }
}

static void MostrarStockBajo(List<string> nombres, List<int> cantidades, int stockBajo)
{
    Console.WriteLine($"Productos con menos de {stockBajo} unidades:");
    bool hayAlguno = false;
    for (int i = 0; i < nombres.Count; i++)
    {
        if (cantidades[i] < stockBajo)
        {
            Console.WriteLine($"  - {nombres[i]} ({cantidades[i]})");
            hayAlguno = true;
        }
    }
    if (!hayAlguno)
    {
        Console.WriteLine("  (ninguno)");
    }
}

// ----------------------------- Entradas -----------------------------
// Estos métodos son la "cajera que revisa los billetes": nada malo pasa de aquí.

// Caso borde escondido: si la entrada se cierra (Ctrl+Z en Windows, Ctrl+D en Linux/Mac),
// ReadLine devuelve null PARA SIEMPRE. Sin este control, los bucles de abajo
// pedirían el dato una y otra vez sin terminar nunca.
static string LeerLinea()
{
    string? texto = Console.ReadLine();
    if (texto == null)
    {
        Console.WriteLine();
        Console.WriteLine("Se cerró la entrada. Terminando el programa.");
        Environment.Exit(0);
    }
    return texto;
}

static int PedirEnteroEnRango(string mensaje, int min, int max)
{
    while (true)
    {
        Console.Write(mensaje);
        string texto = LeerLinea();

        if (!int.TryParse(texto, out int numero))
        {
            Console.WriteLine("Eso no es un número entero. Intenta otra vez.");
        }
        else if (numero < min || numero > max)
        {
            Console.WriteLine($"El número debe estar entre {min} y {max}.");
        }
        else
        {
            return numero;
        }
    }
}

static decimal PedirDecimalEnRango(string mensaje, decimal min, decimal max)
{
    while (true)
    {
        Console.Write(mensaje);
        string texto = LeerLinea();

        if (!decimal.TryParse(texto, out decimal numero))
        {
            Console.WriteLine("Eso no es un número válido. Intenta otra vez.");
        }
        else if (numero < min || numero > max)
        {
            Console.WriteLine($"El valor debe estar entre {min:N2} y {max:N2}.");
        }
        else
        {
            return numero;
        }
    }
}

static string PedirTextoNoVacio(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string texto = LeerLinea().Trim();

        if (texto.Length > 0)
        {
            return texto;
        }
        Console.WriteLine("No puede estar vacío.");
    }
}
