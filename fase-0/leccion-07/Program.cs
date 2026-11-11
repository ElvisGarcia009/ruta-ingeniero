// =============================================================
//  Lección 7: El misterio de las ventas
//
//  Este programa tiene 3 ERRORES escondidos.
//  Regla: NO los busques leyendo. Encuéntralos con el debugger:
//    1. Pon un breakpoint (F9) en la primera línea de cada método.
//    2. Antes de avanzar, escribe en papel qué valor esperas.
//    3. Avanza con F10 / F11 y compara con la ventana de variables.
//
//  Resultados CORRECTOS que debería mostrar:
//    Total de la semana:  RD$ 11,830.75
//    Promedio por día:    RD$ 1,690.11
//    Mejor día:           Sábado (RD$ 3,200.00)
//
//  Por cada error, anota: línea, valor esperado, valor que viste
//  y cómo lo arreglaste.
// =============================================================

string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
decimal[] ventas = { 1200.50m, 980m, 1500m, 2100.25m, 1750m, 3200m, 1100m };

decimal total = CalcularTotal(ventas);
decimal promedio = CalcularPromedio(ventas);
int posicionMejor = BuscarPosicionDelMayor(ventas);

Console.WriteLine($"Total de la semana:  RD$ {total:N2}");
Console.WriteLine($"Promedio por día:    RD$ {promedio:N2}");
Console.WriteLine($"Mejor día:           {dias[posicionMejor]} (RD$ {ventas[posicionMejor]:N2})");

static decimal CalcularTotal(decimal[] valores)
{
    decimal suma = 0m;
    for (int i = 1; i < valores.Length; i++)
    {
        suma += valores[i];
    }
    return suma;
}

static decimal CalcularPromedio(decimal[] valores)
{
    decimal suma = 0m;
    foreach (decimal v in valores)
    {
        suma += v;
    }
    int cantidad = valores.Length;
    return (int)suma / cantidad;
}

static int BuscarPosicionDelMayor(decimal[] valores)
{
    int posicion = 0;
    for (int i = 1; i < valores.Length; i++)
    {
        if (valores[i] < valores[posicion])
        {
            posicion = i;
        }
    }
    return posicion;
}
