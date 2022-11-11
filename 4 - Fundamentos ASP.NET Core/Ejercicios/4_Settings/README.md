1. En el proyecto BusBookingApi de los ejercicios anteriores, cambia el puerto del perfil que arranca el servidor web con Kestrel al 5001. Prueba que el cambio se efectua correctamente mediante peticiones con postman.
2. Cambia el puerto del perfil que arranca el servidor web con IIS Express al 5002. Prueba que el cambio se efectua correctamente mediante peticiones con postman.
3. Añade, en un proveedor de configuración apropiado, una estructura de datos que nos proporcione información sobre el proyecto:
    * Name: BusBookingApi
    * Version: v0.0.1
    * Environment: Default
4. Añade un endpoint que nos devuelva esta información extraída de la configuración.
5. Sobreescribe, en un proveedor de configuración apropiado, el valor del environment a Staging. Ejecuta el proyecto de tal manera que el endpoint del apartado enterior nos devuelva este valor.
6. Haz que podamos refrescar estos valores en caliente. Comprueba que funciona modificando los valores sin reiniciar el servidor, y comprobando el resultado del endpoint que hemos creado.
7. Añade, en un proveedor de configuración apropiado, el siguiente valor a la estructura de datos informativa, pero no lo expongas en el endpoint:
    * ExternalApiKey: DONT-PUSH-THIS-TO-THE-REPOSITORY-PLEASE
8. Haz que el endpoint de información de configuración devuelva la siguiente información en función de si el ApiKey está relleno o no:
    * ExternalApiEnabled: true/false
9. Añade, en una variable de entorno, el siguiente valor a la estructura de datos informativa, y devuelvelo en el endpoint:
    * Message: Hello from an environment value!