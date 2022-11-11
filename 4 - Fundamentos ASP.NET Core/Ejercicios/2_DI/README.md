1. Dentro de la solución CursoNet6 del ejercicio anterior, crea un projecto .Net 6 con la plantilla de API Empty que se llame ServiceLifetimeExamples
  1.1 Dentro de este proyecto webapi, expón un endpoint para obtener un recurso llamado Random con la siguiente estructura:
  Random { number1: number, number2: number }
  1.2 Registra un servicio con el tiempo de vida adecuado (singleton, scoped, y/o transient) para que pasando un parámetro en el querystring podamos obtener:
    * Dos números aleatorios iguales, y siempre los mismos en todas las peticiones (RandomKind: PerServerInstance)
    * Dos números aleatorios iguales entre sí, pero distintos en cada petición (RandomKind: PerRequest)
    * Dos números aletorios distintos entre sí, y distintos en cada petición (RandomKind: PerNumber)
    * Documentación clase Random: https://docs.microsoft.com/es-es/dotnet/api/system.random?view=net-6.0

2. Actualiza el proyecto BusBookingApi del ejercicio anterior anterior, moviendo la lógica de la gestión del recuso Cliente.
  * Registra el servicio con un tiempo de vida adecuado para que podamos obtener un cliente que hemos creado en una petición anterior
  * Reflexiona sobre si es necesario gestionar la concurrencia
  * Si es así, intenta buscar documentación sobre como actualizar tu servicio para gestione la concurrencia adecuadamente


