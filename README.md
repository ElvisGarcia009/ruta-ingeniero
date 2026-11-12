# Ruta del ingeniero

Material de estudio para aprender lo que no siempre se enseña en la universidad: desde pensar un problema hasta la arquitectura y la infraestructura. Todo en C#.

Cada fase tiene una **guía escrita** (`GUIA.md`, con la teoría, las analogías y los ejercicios) y el código para practicar en la misma carpeta.

👉 **Empieza aquí: [Guía de la Fase 0](fase-0/GUIA.md)**

## Fases

| Fase | Tema | Estado |
| --- | --- | --- |
| 0 | [Pensar como programador](fase-0/GUIA.md) | Lista |
| 1 | Programar bien (POO, código limpio, Git, tests) | Próximamente |
| 2 | Diseño (SOLID, patrones) | Próximamente |
| 3 | Datos (SQL, Entity Framework) | Próximamente |
| 4 | Web (HTTP, APIs con ASP.NET Core) | Próximamente |
| 5 | Arquitectura | Próximamente |
| 6 | Infraestructura (Docker, CI/CD, nube) | Próximamente |
| 7 | Mundo laboral | Próximamente |

## Cómo está organizado

```
ruta-ingeniero/
├── fase-0/
│   ├── GUIA.md                       ← la guía de la fase: léela primero
│   ├── leccion-01/ ... leccion-08/   ← ejercicios para completar (busca los // TODO)
│   └── colmado-v1/                   ← el proyecto final de la fase
└── soluciones/
    └── fase-0/                       ← soluciones y respuestas.md
```

## Antes de empezar

1. Instala el **SDK de .NET 8 o superior**: https://dotnet.microsoft.com/download
2. Usa **Visual Studio 2022** (Community es gratis) o **VS Code** con la extensión *C# Dev Kit*.
3. Para correr un ejercicio, abre la terminal en su carpeta y escribe:

   ```
   dotnet run
   ```

   O abre `RutaIngeniero.sln` en Visual Studio y elige el proyecto que quieres correr.

**Ojo con los decimales:** los programas usan la configuración regional de tu computadora. Si tu Windows está configurado para usar coma decimal (por ejemplo, "España"), tendrás que escribir `25,50` en vez de `25.50`. En "República Dominicana" se usa el punto.

## Las reglas de oro

1. Papel primero.
2. Predice antes de ejecutar.
3. 20 minutos solo antes de pedir ayuda.
4. Nada de IA para escribir el código. Solo para revisar algo que ya hiciste tú.
5. Pregúntate siempre "¿y si…?".
6. Explica tu código en voz alta.

Las soluciones están para comparar, no para copiar. Ábrelas solo después de haberlo intentado de verdad.
