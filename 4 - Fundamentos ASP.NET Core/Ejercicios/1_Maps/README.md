1. Crea un proyecto .Net 6 con la plantilla de API Empty (API Vacía) que se llame BusBookingApi, dentro de una solución llamada CursoNet6
2. Añade mediante mappings los endpoints necesarios para gestionar el recurso "Clients" del ejercicio de diseño de APIs del módulo anterior.
    * De momento, los clientes dados de alta los podemos mantener en una estructura de datos en memoria del servidor
    * Piensa en qué tipo de estructura de datos sería apropiada para almacenar esta información de forma eficiente (sin importarnos la concurrencia, por el momento)
3. Crea un workspace en Postman llamado BusBookingApi, con una carpeta llamada "Clients", donde puedas probar las peticiones al API
    * Utiliza variables del workspace para almacenar la url base de tu servicio, y el path del recurso
    * Utiliza variables de la ruta de la petición para almacenar cualquier parámetro que haya en el path
