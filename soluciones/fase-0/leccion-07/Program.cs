// =============================================================
//  SOLUCIÓN - Lección 7: El misterio de las ventas
//
//  Error 1 - CalcularTotal: el for empezaba en i = 1, así que se saltaba
//            el lunes (posición 0). Total salía 10,630.25 en vez de 11,830.75.
//  Error 2 - CalcularPromedio: (int)suma cortaba los decimales ANTES de dividir,
//            y además int / int hace división entera. Salía 1,690.00.
//  Error 3 - BuscarPosicionDelMayor: comparaba con < en vez de >,
//            así que encontraba el MENOR (Martes, 980) en vez del mayor.
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
    for (int i = 0; i < valores.Length; i++)   // arreglado: empieza en 0
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
    return suma / cantidad;                     // arreglado: sin (int)
}

static int BuscarPosicionDelMayor(decimal[] valores)
{
    int posicion = 0;
    for (int i = 1; i < valores.Length; i++)
    {
        if (valores[i] > valores[posicion])     // arreglado: > en vez de <
        {
            posicion = i;
        }
    }
    return posicion;
}
